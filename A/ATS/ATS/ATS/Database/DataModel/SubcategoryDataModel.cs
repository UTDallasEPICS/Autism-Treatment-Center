using System;
using Amazon.DynamoDBv2.DataModel;

namespace ATS.Database.DataModel
{
    [DynamoDBTable("Subcategories")]
    public class SubcategoryDataModel
    {
        [DynamoDBHashKey]
        public int SubcategoryId { get; set; }
        [DynamoDBRangeKey]
        public string SubcategoryName { get; set; }
        public string SubcategoryDescription { get; set; }
        public bool SubcategoryActive { get; set;  }
    }
}
