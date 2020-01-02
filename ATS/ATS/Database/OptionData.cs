using System;
using System.Collections.Generic;
using ATS.Models;

namespace ATS.Database
{
    public class OptionData
    {
        public List<Option> Options = new List<Option>
        {
            new Option()
            {
                Option1 = "View                                                             >>"
            },

            new Option()
            {
                Option2 = "Add                                                               >>"
            },

            new Option()
            {
                Option3 = "Modify                                                          >>"
            },

            new Option()
            {
                Option4 = "Delete                                                           >>"
            }
        };
    }
}
