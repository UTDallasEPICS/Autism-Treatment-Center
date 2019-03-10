using System;
using Amazon.DynamoDBv2.DataModel;

namespace ATS.Database.DataModel
{
    //  This is the model for the data we will be saving for the users,

    [DynamoDBTable("Patients")]
    public class PatientDataModel
    {
        [DynamoDBHashKey]
        public int PatientId { get; set; }
        [DynamoDBRangeKey]
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public string PatientGender { get; set; }
        public bool PatientActive { get; set; }
    }
}
