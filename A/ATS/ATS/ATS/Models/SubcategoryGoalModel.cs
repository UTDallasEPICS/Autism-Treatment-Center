using System;
using Amazon.DynamoDBv2.DataModel;
using System.Collections.Generic;

namespace ATS.Models
{
    [DynamoDBTable("Subcategory-Goal")]
    public class SubcategoryGoalModel : IRelationInterface
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
        public string DateCreated { get; set; }
        public List<string> Ids { get; set; }
    }
}
