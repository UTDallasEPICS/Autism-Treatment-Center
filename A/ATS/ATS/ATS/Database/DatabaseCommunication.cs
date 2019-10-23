using System;
using Amazon.DynamoDBv2.DataModel;
using ATS.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace ATS.Database
{
    //  This will be our object to comminicate with the database
       
    public class DatabaseCommunication
    {
        //  Variable holding the configuration of our dynamo function
        private DynamoDBOperationConfig Config;

        //  Constructor that initializes the Congfiguration for the amazon services
        public DatabaseCommunication()
        {
            Config = new DynamoDBOperationConfig
            {
                IgnoreNullValues = false
            };
        }




        /*********************  Functions to SAVE data to the database  **********************************/




        //  Async Task which will save the generic model passed to it to our database,
        //  Dbugging and exception calling will be done here
        public async Task saveGenericModel<TModel>(TModel Model)
        {
            Console.WriteLine("Saving generic model...");

            await DatabaseInit.DynamoContext.SaveAsync<TModel>(Model, Config);

            Console.WriteLine("Generic model Saved.");
        }

        //  Async Task which will save the generic model to our database, also with the respective
        //  relational table updated aswell
        //
        //  How this function works
        //  Saves model to data base, by taking these extra steps to setup other thing in our database:
        //
        //  TModel = model to save
        //  TRelation_Table = relation table linking the parent to TModels id
        //  TNext_RelationTable = table to link TModel to it's child table id
        //
        //  Saves TModel
        //  adds the id of TModel to the ids belonging to it's parent model, in TRelation_Table
        //  creates relation table for TModel and it's children, 
        //  saves that TNext_Relation_Table to the database
        //
        //  we creates the TNext_Relation_Table, so that when we add id's to a model's relation_table,
        //  the table already exists
        //
        //  Ex: Want to save Patient
        //  Patient Parent = Teacher
        //  Patient Child = Domains
        //
        //  So, the using this function will look like...
        // 
        //  saveGenericModelUpdateRelation<Patient, Teacher-Patient-Relation-Table, Patient-Domain-Relation-Table>()
        //
        //  With Params:
        //  Model = patient model to save
        //  relation_table_id = id of parent, so we can save the patient id to the list of ids belonging to teacher
        public async Task saveGenericModelUpdateRelation<TModel, TRelation_Table, TNext_Relation_Table>(TModel Model, string relation_table_id)
            where TRelation_Table : IRelationInterface
            where TNext_Relation_Table: IRelationInterface, new()
            where TModel : IDataModelInterface
        {
            TRelation_Table Relation_Table = await getGenericModel<TRelation_Table>(relation_table_id);

            Relation_Table.Ids.Add(Model.Id);

            await saveGenericModel<TRelation_Table>(Relation_Table);

            await saveGenericModel<TModel>(Model);

            List<string> Temp_Ids = new List<string>();
            Temp_Ids.Add("Null");

            TNext_Relation_Table Next_Relation_Table = new TNext_Relation_Table
            {
                Id = Model.Id,
                DateCreated = new DateTime().Date.ToString("yyyy-MM-dd"),
                Ids = Temp_Ids
            };

            await saveGenericModel<TNext_Relation_Table>(Next_Relation_Table);
        }

        //  Async Task which will save the generic model to our database, also with the respective
        //  relational table updated aswell
        //
        //  same as last function, except we don't create a TNext_Relation table, because there will not
        //  be a child for the final table
        public async Task saveGenericModelUpdateRelationFinalTable<TModel, TRelation_Table>(TModel Model, string relation_table_id)
            where TRelation_Table : IRelationInterface
            where TModel : IDataModelInterface
        {
            TRelation_Table Relation_Table = await getGenericModel<TRelation_Table>(relation_table_id);

            Relation_Table.Ids.Add(Model.Id);

            await saveGenericModel<TRelation_Table>(Relation_Table);

            await saveGenericModel<TModel>(Model);
        }



        /*********************  Functions to GET data from the database  **********************************/




        //  This function will take a genericId and return the model with that ID
        public async Task<TModel> getGenericModel<TModel>(string modelId)
        {
            Console.WriteLine("Getting generic model...");

            var search = DatabaseInit.DynamoContext.QueryAsync<TModel>(modelId, Config);

            var searchResponse = await search.GetRemainingAsync();

            Console.WriteLine("Found generic model.");

            return searchResponse[0];
        }




        /*********************  Functions to GET RELATIONAL data from the database  **********************************/

        


        //  This function will use a generic relation table and take a relation id for that table,
        //  and then return the ids belonging to the relation id
        //  Relation_Table = relation table int the database
        //  relationId = the id to look for the in the relation table, to the get the ids belonging to it
        //  Ex:
        //      Relation_Table = TeacherPatient
        //      relationId = teacherId
        //      
        //      return = ids of patients belonging to teacher
        public async Task<List<string>> getGenericRelationIds<TRelation_Table>(string relationId) 
            where TRelation_Table : IRelationInterface
        {
            Console.WriteLine("Getting ids belonging to the generic with genericId...");

            //  Gets the List of ids in the relation_table belonging to relationId 
            var search = DatabaseInit.DynamoContext.QueryAsync<TRelation_Table>(relationId, Config);

            var searchResponse = await search.GetRemainingAsync();

            Console.WriteLine("Found generic ids.");

            return searchResponse[0].Ids;
        }




        /*********************  Functions to GET BATCH data from the database  **********************************/




        //  This function will take a gnericId and return the an observablecollection of objects
        //  belonging to that generic
        //
        //  Relation_Table = relational table model that we want to use to get our targets
        //  Targets = what objects we want to get
        //
        //  Ex: 
        //      RelationTable = TeacherPatient
        //      Targets = Patients
        //      relationId = TeacherId
        //  
        //      return = Patient objects belonging to Teacher with id TeacherId
        public async Task<ObservableCollection<TTargets>> getGenericModelBatch<TRelation_Table, TTargets>(string relationId)
            where TRelation_Table : IRelationInterface
        {
            Console.WriteLine("Getting generic objects...");

            //  Create list of target objects to 
            ObservableCollection<TTargets> targetObjects = new ObservableCollection<TTargets>();

            //  Gets the ids of the targets that we want to get
            //  uses the relationId and the relation table to find the respective targets belonging to the relation
            //  id in the relation table
            List<string> targetIds = await getGenericRelationIds<TRelation_Table>(relationId);

            int target_count = targetIds.Count;

            //  For loop that gets every tar get that was found beloning to our relation id
            for(int target_index = 0; target_index < target_count; target_index++)
            {
                if (targetIds[target_index] != "Null")
                {
                    //  gets targets from id
                    TTargets pat = await getGenericModel<TTargets>(targetIds[target_index]);
                    //  adds targets
                    targetObjects.Add(pat);
                }
            }

            Console.WriteLine("Targets loaded");

            return targetObjects;
        }
    }
}
