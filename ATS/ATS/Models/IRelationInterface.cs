using System;
using System.Collections.Generic;

namespace ATS.Models
{
    public interface IRelationInterface
    {
        string Id { get; set; }
        string DateCreated { get; set; }
        List<string> Ids { get; set; }
    }
}
