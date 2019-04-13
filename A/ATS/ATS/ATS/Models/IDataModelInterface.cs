using System;
using System.ComponentModel;

namespace ATS.Models
{
    public interface IDataModelInterface
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
