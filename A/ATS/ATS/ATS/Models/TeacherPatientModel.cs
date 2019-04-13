using System;
using Amazon.DynamoDBv2.DataModel;
using System.Collections.Generic;

namespace ATS.Models
{
    [DynamoDBTable("Teacher-Patient")]
    public class TeacherPatientModel : IRelationInterface
    {
        [DynamoDBHashKey]
        public int Id { get; set; }
        public string DateCreated { get; set; }
        public List<int> Ids { get; set; }
    }
}
