using System;
using Amazon.DynamoDBv2.DataModel;
using System.Collections.Generic;

namespace ATS.Models
{
    [DynamoDBTable("Domain-Subcategory")]
    public class DomainSubcategoryModel : IRelationInterface
    {
        [DynamoDBHashKey]
        public int Id { get; set; }
        public string DateCreated { get; set; }
        public List<int> Ids { get; set; }
    }
}
