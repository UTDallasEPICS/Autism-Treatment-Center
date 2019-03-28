using System;
using ATS.Database.DataModel;

namespace ATS.Database.DataModel.DisplayModel
{
    public class Patient : PatientDataModel
    {
        public override string ToString()
        {
            return PatientName;
        }
    }
}
