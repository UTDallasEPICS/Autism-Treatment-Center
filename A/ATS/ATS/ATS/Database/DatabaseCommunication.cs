using System;
using Amazon.DynamoDBv2.DataModel;
using ATS.Model;
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




        //  Async Task which will save the patient passed to it to our database,
        //  Dbugging and exception calling will be done here
        public async Task saveGenericModel<TModel>(TModel Model)
        {
            Console.WriteLine("Saving generic model...");

            await DatabaseInit.DynamoContext.SaveAsync<TModel>(Model, Config);

            Console.WriteLine("Generic model Saved.");
        }



        /*********************  Functions to GET data from the database  **********************************/




        //  This function will take a teacherId and return the teacher with that ID
        public async Task<TModel> getGenericModel<TModel>(int modelId)
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
        public async Task<List<int>> getGenericRelationIds<TRelation_Table>(int relationId) 
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
        public async Task<ObservableCollection<TTargets>> getGenericModelBatch<TRelation_Table, TTargets>(int relationId)
            where TRelation_Table : IRelationInterface
        {
            Console.WriteLine("Getting generic objects...");

            //  Create list of target objects to 
            ObservableCollection<TTargets> targetObjects = new ObservableCollection<TTargets>();

            //  Gets the ids of the targets that we want to get
            //  uses the relationId and the relation table to find the respective targets belonging to the relation
            //  id in the relation table
            List<int> targetIds = await getGenericRelationIds<TRelation_Table>(relationId);

            int target_count = targetIds.Count;

            //  For loop that gets every tar get that was found beloning to our relation id
            for(int target_index = 0; target_index < target_count; target_index++)
            {
                //  gets targets from id
                TTargets pat = await getGenericModel<TTargets>(targetIds[target_index]);
                //  adds targets
                targetObjects.Add(pat);
            }

            Console.WriteLine("Targets loaded");

            return targetObjects;
        }
    }
}
