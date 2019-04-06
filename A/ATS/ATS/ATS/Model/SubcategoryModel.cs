﻿using System;
using Amazon.DynamoDBv2.DataModel;

namespace ATS.Model
{
    [DynamoDBTable("Subcategories")]
    public class SubcategoryModel : IDataModelInterface
    {
        [DynamoDBHashKey]
        public int Id { get; set; }
        [DynamoDBRangeKey]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set;  }
        public string DateCreated { get; set; }
    }
}
