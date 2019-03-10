using System;
using Amazon.DynamoDBv2.DataModel;

namespace ATS.Database.DataModel
{
    [DynamoDBTable("Domains")]
    public class DomainDataModel
    {
        [DynamoDBHashKey]
        public int DomainId { get; set; }
        [DynamoDBRangeKey]
        public string DomainName { get; set; }
        public string DomainDescription { get; set; }
        public bool DomainActive { get; set; }
    }
}
