using System;
using System.Collections.Generic;
using System.Text;
using Amazon.DynamoDBv2.DataModel;

namespace ATS.Models
{
    [DynamoDBTable("Login")]
    public class Login
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
        [DynamoDBRangeKey]
        public string Username { get; set; }
        public string Password { get; set; }
        public string accessType { get; set; }
        public bool Active { get; set; }
        public string DateCreated { get; set; }
    }
}
