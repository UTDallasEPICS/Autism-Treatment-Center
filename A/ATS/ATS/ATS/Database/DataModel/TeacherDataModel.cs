using System;
using Amazon.DynamoDBv2.DataModel;

namespace ATS.Database.DataModel
{
    [DynamoDBTable("Teachers")]
    public class TeacherDataModel
    {
        [DynamoDBHashKey]
        public int TeacherId { get; set; }
        [DynamoDBRangeKey]
        public string TeacherName { get; set; }
        public int TeacherAge { get; set; }
        public string TeacherGender { get; set; }
        public bool TeacherActive { get; set; }
    }
}
