using System;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using System.Threading.Tasks;

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
    }
}
