using System;
using Amazon.DynamoDBv2.DataModel;

namespace ATS.Database.DataModel.ModelRelation
{
    [DynamoDBTable("Subcategory-Goal")]
    public class SubcategoryGoal
    {
        [DynamoDBHashKey]
        public int SubcategoryId { get; set; }
        public int GoalId { get; set; }
    }
}
