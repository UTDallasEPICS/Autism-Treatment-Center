using System;
using System.ComponentModel;
using Amazon.DynamoDBv2.DataModel;

namespace ATS.Models
{
    [DynamoDBTable("Frequency")]
    public class FrequencyTaskModel : IDataModelInterface
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
        public string BehaviorID { get; set; }
        public string Frequency { get; set; }
        public string DateCreated { get; set; }
        public string Name { get; set; }
    }
}
