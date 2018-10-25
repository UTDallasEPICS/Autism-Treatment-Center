using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace ATS.Model
{
    class PatientManager
    {

        //Spring2018 Team: this needs to become something set by login
        //Spring2018 Team: and obviously edit requests will need to be validated by a server
        //Spring2018 Team: there's probably a much better place for this but I wasn't sure where
        public static bool CanUserEdit = true;

        private static PatientManager instance;
        public static PatientManager Instance
        {
            get
            {
                if (instance == null)
                    new PatientManager();
                return instance;
            }
        }

        private ObservableCollection<Patient> patients;

        public PatientManager()
        {
            if (instance != null)
                throw new Exception("There should only be one PatientManager!");
            instance = this;
            patients = new ObservableCollection<Patient>();
            //Fall2018 Team: here is where you can change the names of the default patients in the list
            patients.Add(new Patient("John Doe") {PatientAge = "18", Gender = "Male" });
            patients.Add(new Patient("Jane Doe") {PatientAge = "8", Gender = "Female" });

            //Spring2018 Team: adding a patient with real data
            //Spring2018 Team: using .LoadLayout instead of .CreateLayout because Create will ask for task information
            Patient p = new Patient("Jane", true) { PatientAge = "14", Gender = "Female" };
            DomainGroup pd = p.DGroup;
            NestedStackLayout  dl = pd.domainLayout;

            //Fall2018 Team: here is where we can change the names of the default domains
            NestedStackLayout behavior = NestedStackLayout.LoadLayout(pd, dl,
                "Behavior", NestedStackLayout.NestedTypes.Domain);
            NestedStackLayout commun = NestedStackLayout.LoadLayout(pd, dl,
                "Communication", NestedStackLayout.NestedTypes.Domain);
            NestedStackLayout play = NestedStackLayout.LoadLayout(pd, dl,
                "Play", NestedStackLayout.NestedTypes.Domain);
            NestedStackLayout visual = NestedStackLayout.LoadLayout(pd, dl,
                "Visual Performance", NestedStackLayout.NestedTypes.Domain);
            NestedStackLayout self = NestedStackLayout.LoadLayout(pd, dl,
                "Self Care", NestedStackLayout.NestedTypes.Domain);

            dl.AddSubView(behavior);
            dl.AddSubView(commun);
            dl.AddSubView(play);
            dl.AddSubView(visual);
            dl.AddSubView(self);

            //Fall2018 Team: here are the default goals and tasks and subcategory
            NestedStackLayout refrain = NestedStackLayout.LoadLayout(pd, behavior,
                "Refrain Aggression", NestedStackLayout.NestedTypes.Subcategory);
            NestedStackLayout tSelf = NestedStackLayout.LoadLayout(pd, refrain,
                "Towards Self", NestedStackLayout.NestedTypes.Goal);
            NestedStackLayout tOthers = NestedStackLayout.LoadLayout(pd, refrain,
                "Towards Others", NestedStackLayout.NestedTypes.Goal);
            NestedStackLayout restroom = NestedStackLayout.LoadLayout(pd, behavior,
                "Restroom Training", NestedStackLayout.NestedTypes.Subcategory);
            NestedStackLayout dontHit = NestedStackLayout.LoadLayout(pd, tOthers,
                "Refrain from hitting others", NestedStackLayout.NestedTypes.Task, NestedTaskLayout.TaskType.PassFail);

            behavior.AddSubView(refrain);
            behavior.AddSubView(restroom);
            refrain.AddSubView(tSelf);
            refrain.AddSubView(tOthers);
            tOthers.AddSubView(dontHit);

            pd.RegisterStack(behavior.GetStackType(), behavior);
            pd.RegisterStack(commun.GetStackType(), commun);
            pd.RegisterStack(play.GetStackType(), play);
            pd.RegisterStack(visual.GetStackType(), visual);
            pd.RegisterStack(self.GetStackType(), self);

            pd.RegisterStack(refrain.GetStackType(), refrain);
            pd.RegisterStack(restroom.GetStackType(), restroom);
            pd.RegisterStack(tSelf.GetStackType(), tSelf);
            pd.RegisterStack(tOthers.GetStackType(), tOthers);
            pd.RegisterStack(dontHit.GetStackType(), dontHit);

            patients.Add(p);
        }

        public void AddPatient(Patient p)
        {
            patients.Add(p);
        }

        public ObservableCollection<Patient> GetPatients()
        {
            return patients;
        }
    }
}
