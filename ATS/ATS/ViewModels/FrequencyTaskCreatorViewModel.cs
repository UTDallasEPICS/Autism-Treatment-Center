using System;
using ATS.Models;
using ATS.Database;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Xamarin.Forms;

public class FrequencyTaskCreatorViewModel
{
    public ICommand SaveFrequencyCommand { get; private set; }
    //  Fields
    private string _behaviorID;
    public string BehaviorID
    {
        get { return _behaviorID; }
        set { _behaviorID = value; }
    }
    private string _frequency;
    public string Frequency
    {
        get { return _frequency; }
        set { _frequency = value; }
    }

    public FrequencyTaskCreatorViewModel()
    {

        SaveFrequencyCommand = new Command(async () => await SaveFrequencyTaskAsync());
    }

    async Task SaveFrequencyTaskAsync()
    {
        FrequencyTaskModel FrequencyTask_To_Add = new FrequencyTaskModel
        {
            Id = Guid.NewGuid().ToString(),
            //BehaviorID = BehaviorID,
            Frequency = Frequency
        };

        //  Clears the input so that user doesn't have to delete characters to add
        //  another occurence of behavior
        Frequency = "";
    }
}