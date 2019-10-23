using System;
using Amazon;

namespace ATS.Database
{
    public class DatabaseInfo
    {
        //  This class will hold database credential information

        public static string COGNITO_IDENTITY_POOL_ID = "us-east-1:2e9373a8-19b0-472c-8598-742813da80a0";
        public static RegionEndpoint COGNITO_REGION_ENDPOINT = RegionEndpoint.USEast1;
        public static RegionEndpoint DYNAMO_REGION_ENDPOINT = RegionEndpoint.USEast1;
    }
}
