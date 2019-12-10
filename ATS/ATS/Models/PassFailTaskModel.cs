using System;
using System.ComponentModel;
using Amazon.DynamoDBv2.DataModel;

namespace ATS.Models
{
    [DynamoDBTable("PassFail")]
    public class PassFailTaskModel : IDataModelInterface
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
        public string BehaviorID { get; set; }
        public string Opportunities { get; set; }
        public string Successes { get; set; }
        public string DateCreated { get; set; }
        public string Name { get; set; }
    }
}
