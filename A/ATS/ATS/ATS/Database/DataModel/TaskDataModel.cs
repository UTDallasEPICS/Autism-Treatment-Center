using System;
using Amazon.DynamoDBv2.DataModel;

namespace ATS.Database.DataModel
{
    [DynamoDBTable("Tasks")]
    public class TaskDataModel
    {
        [DynamoDBHashKey]
        public int TaskId { get; set; }
        [DynamoDBRangeKey]
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskType { get; set;  }
        public bool TaskActive { get; set; }
    }
}
