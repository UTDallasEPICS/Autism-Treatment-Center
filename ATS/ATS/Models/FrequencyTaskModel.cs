using System;
using System.ComponentModel;
using Amazon.DynamoDBv2.DataModel;

namespace ATS.Models
{
    [DynamoDBTable("Frequency")]
    public class FrequencyTaskModel : TaskModel
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
        [DynamoDBRangeKey]
        public string BehaviorID { get; set; }
        public string Frequency { get; set; }
        public string DateCreated { get; set; }
    }
}
