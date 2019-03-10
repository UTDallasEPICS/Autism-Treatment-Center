using System;
using Amazon.DynamoDBv2.DataModel;

namespace ATS.Database.DataModel.ModelRelation
{
    [DynamoDBTable("Teacher-Patient")]
    public class TeacherPatient
    {
        [DynamoDBHashKey]
        public int TeacherId { get; set; }
        public int PatientId { get; set; }
    }
}
