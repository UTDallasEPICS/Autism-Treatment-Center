using System;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using ATS.Database.DataModel;
using ATS.Database.DataModel.ModelRelation;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ATS.Database
{
    /*  This will be our object to act as our communication with the database
     */
       
    public class DatabaseCommunication
    {
        /*  Variable holding the configuration of our dynamo function
         */
        private DynamoDBOperationConfig config;

        /*  Constructor that initializes the configuration for the amazon services
         */
        public DatabaseCommunication()
        {
            config = new DynamoDBOperationConfig
            {
                IgnoreNullValues = false
            };
        }

        /*  Async Task which will save the patient passed to it to our database,
         * Dbugging and exception calling will be done here
         */
        public async Task SavePatient(PatientDataModel patient)
        {
            Console.WriteLine("Saving patient...");

            await DatabaseInit.DynamoContext.SaveAsync<PatientDataModel>(patient, config);

            Console.WriteLine("Patient Saved.");
        }

        /*  This function will take a teacherId and then return an ObservableList of those patient
         *  objects for that teacher
         */
        public async Task getPatients(int teacherId)
        {
            /*
            QueryOperationConfig patientQuery = new QueryOperationConfig()
            {
                IndexName = "PatientId-Index",
                Filter = new QueryFilter("PatientId", QueryOperator.Equal, teacherId)
            };
            */

            Console.WriteLine("Getting patients...");

            var search = DatabaseInit.DynamoContext.QueryAsync<PatientDataModel>(teacherId, config);

            var searchResponce = await search.GetRemainingAsync();
            searchResponce.ForEach((s) => {
                Console.WriteLine(s.ToString());
            });
        }
    }
}
