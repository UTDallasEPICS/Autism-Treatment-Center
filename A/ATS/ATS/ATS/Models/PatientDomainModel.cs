using System;
using Amazon.DynamoDBv2.DataModel;
using System.Collections.Generic;

namespace ATS.Models
{
    [DynamoDBTable("Patient-Domain")]
    public class PatientDomainModel : IRelationInterface
    {
        [DynamoDBHashKey]
        public int Id { get; set; }
        public string DateCreated { get; set; }
        public List<int> Ids { get; set; }
    }
}
