using System;
using Amazon;

namespace ATS.Database
{
    public class DatabaseInfo
    {
        //  This class will hold database credential information

        public const string COGNITO_IDENTITY_POOL_ID = "us-east-1:53023a07-dd5b-4e18-812b-4c2dce0a1881";
        public static RegionEndpoint COGNITO_REGION_ENDPOINT = RegionEndpoint.USEast1;
        public static RegionEndpoint DYNAMO_REGION_ENDPOINT = RegionEndpoint.USEast1;
    }
}
