using System;
using System.ComponentModel;
using Amazon.DynamoDBv2.DataModel;

namespace ATS.Models
{
    [DynamoDBTable("Teachers")]
    public class TeacherModel : IDataModelInterface
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
        [DynamoDBRangeKey]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }
        public string DateCreated { get; set; }
    }
}
