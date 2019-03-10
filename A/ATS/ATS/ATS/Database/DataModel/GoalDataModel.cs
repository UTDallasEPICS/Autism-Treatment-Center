using System;
using Amazon.DynamoDBv2.DataModel;

namespace ATS.Database.DataModel
{
    [DynamoDBTable("Goals")]
    public class GoalDataModel
    {
        [DynamoDBHashKey]
        public int GoalId { get; set; }
        [DynamoDBRangeKey]
        public string GoalName { get; set; }
        public string GoalDescription { get; set; }
        public bool GoalActive { get; set; }
    }
}
