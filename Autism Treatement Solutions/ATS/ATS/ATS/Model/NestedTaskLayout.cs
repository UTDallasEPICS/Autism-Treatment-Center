using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

using ATS.Tasks;

namespace ATS.Model
{
    public class NestedTaskLayout : NestedStackLayout
    {

        public enum TaskType { Duration, Frequency, Opportunity, PassFail }



        private TaskType taskType;
        private Task taskPage;

        //we default to a PassFail for testing purposes
        public NestedTaskLayout(DomainGroup dg, NestedStackLayout par, string n, TaskType t = TaskType.PassFail)
            : base(dg, par, n, NestedStackLayout.NestedTypes.Task)
        {
            
            taskType = t;
            switch(taskType)
            {
                case TaskType.Duration:
                    taskPage = new DurationTask(this, n);
                    break;
                case TaskType.Frequency:
                    taskPage = new FrequencyTask(this, n);
                    break;
                case TaskType.Opportunity:
                    taskPage = new OpportunityTask(this, n);
                    break;
                case TaskType.PassFail:
                    taskPage = new PassFailTask(this, n);
                    break;
            }
        }

        protected override void AddButtons(StackLayout buttonLayout)
        {
            Button seeTask = new Button();
            seeTask.Text = "Details";
            seeTask.Clicked += DetailsClicked;
            buttonLayout.Children.Add(seeTask);
            base.AddButtons(buttonLayout);
            
        }

        public override void CheckCompletion()
        {
            if(taskPage == null)
            {
                SetComplete(false);
            }
            else
            {
                SetComplete(taskPage.Completed && CheckChildCompletion());
            }

        }

        public override void SetName(string s)
        {
            base.SetName(s);
            taskPage.UpdateName(s);
        }

        private void DetailsClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(taskPage);
        }

        public void EditTask()
        {
            Navigation.PushAsync(taskPage.GetEditor());
        }
    }
}
