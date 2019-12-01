using System;
using ATS.Models;
using ATS.Database;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Xamarin.Forms;

    public class PassFailTaskCreatorViewModel
{
    public ICommand SavePassFailCommand { get; private set; }
    //  Fields
    private string _behaviorID;
    public string BehaviorID
    {
        get { return _behaviorID; }
        set { _behaviorID = value; }
    }
    private string _opportunities;
    public string Opportunities
    {
        get { return _opportunities; }
        set { _opportunities = value; }
    }
    private string _successes;
    public string Successes
    {
        get { return _successes; }
        set { _successes = value; }
    }


    public PassFailTaskCreatorViewModel()
    {

        SavePassFailCommand = new Command(async () => await SavePassFailTaskAsync());
    }

    async Task SavePassFailTaskAsync()
    {
        PassFailTaskModel PassFailTask_To_Add = new PassFailTaskModel
        {
            Id = Guid.NewGuid().ToString(),
           //BehaviorID = BehaviorID,
            Opportunities = Opportunities,
            Successes = Successes
        };

        //  Clears the input so that user doesn't have to delete characters to add
        //  another occurence of behavior
        Opportunities = "";
        Successes = "";
    }
}