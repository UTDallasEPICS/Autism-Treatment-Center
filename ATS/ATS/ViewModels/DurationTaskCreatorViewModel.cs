using System;
using ATS.Models;
using ATS.Database;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Xamarin.Forms;

public class DurationTaskCreatorViewModel
{
    public ICommand SaveDurationCommand { get; private set; }
    //  Fields
    private string _behaviorID;
    public string BehaviorID
    {
        get { return _behaviorID; }
        set { _behaviorID = value; }
    }
    private string _time;
    public string Time
    {
        get { return _time; }
        set { _time = value; }
    }

    public DurationTaskCreatorViewModel()
    {

        SaveDurationCommand = new Command(async () => await SaveDurationTaskAsync());
    }

    async Task SaveDurationTaskAsync()
    {
        DurationTaskModel DurationTask_To_Add = new DurationTaskModel
        {
            Id = Guid.NewGuid().ToString(),
            //BehaviorID = BehaviorID,
            Time = Time
        };

        //  Clears the input so that user doesn't have to delete characters to add
        //  another occurence of behavior
        Time = "";
    }
}