using System;
using System.ComponentModel;
using Amazon.DynamoDBv2.DataModel;

namespace ATS.Models
{
    [DynamoDBTable("Behavior")]
    public class BehaviorModel : IDataModelInterface
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
        [DynamoDBRangeKey]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string DateCreated { get; set; }
        public string Task { get; set; }
    }
}
