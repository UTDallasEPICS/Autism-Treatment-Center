using System;
using Amazon.DynamoDBv2.DataModel;
using System.Collections.Generic;

namespace ATS.Models
{
    [DynamoDBTable("Teacher-Patient")]
    public class TeacherPatientModel : IRelationInterface
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
        public string DateCreated { get; set; }
        public List<string> Ids { get; set; }
    }
}
