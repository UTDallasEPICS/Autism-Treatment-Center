using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace ATS.Model
{
	public class Patient
    {

        public string PatientName { get; set; }
        public string PatientAge { get; set; }
        public string Gender { get; set; }
        public DomainGroup DGroup;

        public Patient(string name, bool fromApp = false)
        {
            PatientName = name;
            //Spring2018 Team: a user will be defining the domains
            if (fromApp)
            {
                DGroup = new DomainGroup();
                DGroup.EmptyInitialize(name);
            }
            else
            {
                //Spring2018 Team: we need to load a DomainGroup here
                DGroup = DomainGroup.LoadDomains(PatientName/*Spring2018 Team: , pathToData*/);
            }

        }

    }
}
