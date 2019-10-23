using System;
using System.ComponentModel;
using Amazon.DynamoDBv2.DataModel;

namespace ATS.Models
{
    //  This is the model for the data we will be saving for the users,

    [DynamoDBTable("Patients")]
    public class PatientModel : IDataModelInterface
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
        [DynamoDBRangeKey]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }
        public string DateCreated { get; set; }
    }
}
