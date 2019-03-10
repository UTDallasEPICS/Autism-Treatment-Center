using System;
using Amazon.DynamoDBv2.DataModel;

namespace ATS.Database.DataModel.ModelRelation
{
    [DynamoDBTable("Goal-Task")]
    public class GoalTask
    {
        [DynamoDBHashKey]
        public int GoalId { get; set; }
        public int TaskId { get; set; }
    }
}
