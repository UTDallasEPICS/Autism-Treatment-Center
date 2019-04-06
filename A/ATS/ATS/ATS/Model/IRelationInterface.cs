using System;
using System.Collections.Generic;

namespace ATS.Model
{
    public interface IRelationInterface
    {
        int Id { get; set; }
        string DateCreated { get; set; }
        List<int> Ids { get; set; }
    }
}
