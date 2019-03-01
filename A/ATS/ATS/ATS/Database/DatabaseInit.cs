using System;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon;

namespace ATS.Database
{
    //  This class will hold all of the object that we need for our database,
    public class DatabaseInit
    {
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
        private static DynamoDBContext _dynamocontext;

        public static DynamoDBContext Dynamocontext
        {
            get
            {
                if(_dynamocontext == null)
                {
                    //  possibly give credentials it's own get property
                    _dynamocontext = new DynamoDBContext(new AmazonDynamoDBClient(Credentials, DatabaseInfo.DYNAMO_REGION_ENDPOINT));
                }
                return _dynamocontext;
            }
        }
    }
}
