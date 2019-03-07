using System;
using Amazon.DynamoDBv2.DataModel;

namespace ATS.Database
{
    //  This is the model for the data we will be saving for the users,

    [DynamoDBTable("PatientData")]
    public class PatientDataModel
    {
        [DynamoDBHashKey]
        public string PatientName { get; set; }
        [DynamoDBRangeKey]
        public string PatientLocation { get; set; }
    }
}
