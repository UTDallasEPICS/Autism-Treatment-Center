using System;
using Amazon.DynamoDBv2.DataModel;
using System.Collections.Generic;

namespace ATS.Models
{
    [DynamoDBTable("Login")]
    public class Login : IDataModelInterface
    {
        [DynamoDBHashKey]
        public string Username { get; set; }

        [DynamoDBProperty]
        public string Password { get; set; }
        public string AccessType { get; set; }
        public int Active { get; set; }
        public string DateCreated { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
