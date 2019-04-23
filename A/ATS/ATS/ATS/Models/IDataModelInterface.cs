using System;
using System.ComponentModel;

namespace ATS.Models
{
    public interface IDataModelInterface
    {
        string Id { get; set; }
        string Name { get; set; }
    }
}
