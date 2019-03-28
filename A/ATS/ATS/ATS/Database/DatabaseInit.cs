using System;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace ATS.Database
{
    //  This class will hold all of the object that we need for our database,
    public class DatabaseInit
    {
        //  these are static so that we can access them without instatiating an object through our whole
        //  program, and so that we only create the objects once.

        /*********************************************************/
        /*********  Amazon cognito credentials object ************/

        //  This is the object variable for our credentials
        private static CognitoAWSCredentials _credentials;

        //  This is a property for the private variable for our credentials object
        //  It is basically a way to create get/set methods for our object
        public static CognitoAWSCredentials Credentials
        {
            get {
                if (_credentials == null) 
                {
                    // Initialize the Amazon Cognito credentials provider
                    _credentials = new CognitoAWSCredentials(
                        DatabaseInfo.COGNITO_IDENTITY_POOL_ID, // Identity pool ID
                        DatabaseInfo.COGNITO_REGION_ENDPOINT// Region
                    );
                }
                return _credentials;
            }
        }

        /*********************************************************/
        /************   Amazong Dynambodb context   ***************/
        //  This is the context object we will use for sending and getting info from the database

        //  This is the object holding the client credentials for our dynamodb database
        private static DynamoDBContext _dynamoContext;

        public static DynamoDBContext DynamoContext
        {
            get
            {
                if(_dynamoContext == null)
                {
                    //  possibly give credentials it's own get property
                    _dynamoContext = new DynamoDBContext(DynamoClient);
                }
                return _dynamoContext;
            }
        }

        /*********************************************************/
        /************   Amazong Dynambodb client   ***************/

        //  This is the client object for dynamo db, which is just used to initialize the context
       public static AmazonDynamoDBClient _dynamoClient;

        public static AmazonDynamoDBClient DynamoClient
        {
            get
            {
                if(_dynamoClient == null)
                {
                    _dynamoClient = new AmazonDynamoDBClient(Credentials, DatabaseInfo.DYNAMO_REGION_ENDPOINT);
                }

                return _dynamoClient;
            }
        }
    }
}
