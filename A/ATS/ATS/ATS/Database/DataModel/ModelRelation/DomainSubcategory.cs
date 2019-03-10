using System;
using Amazon.DynamoDBv2.DataModel;

namespace ATS.Database.DataModel.ModelRelation
{
    [DynamoDBTable("Domain-Subcategory")]
    public class DomainSubcategory
    {
        [DynamoDBHashKey]
        public int DomainId { get; set; }
        public int SubcategoryId { get; set; }
    }
}
