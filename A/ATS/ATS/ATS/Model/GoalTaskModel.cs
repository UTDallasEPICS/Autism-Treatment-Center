using System;
using Amazon.DynamoDBv2.DataModel;
using System.Collections.Generic;

namespace ATS.Model
{
    [DynamoDBTable("Goal-Task")]
    public class GoalTaskModel : IRelationInterface
    {
        [DynamoDBHashKey]
        public int Id { get; set; }
        public string DateCreated { get; set; }
        public List<int> Ids { get; set; }
    }
}
