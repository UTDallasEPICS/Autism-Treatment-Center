using System;
using Amazon.DynamoDBv2.DataModel;

namespace ATS.Database.DataModel.ModelRelation
{
    [DynamoDBTable("Patient-Domain")]
    public class PatientDomain
    {
        [DynamoDBHashKey]
        public int PatientId { get; set; }
        public int DomainId { get; set; }
    }
}
