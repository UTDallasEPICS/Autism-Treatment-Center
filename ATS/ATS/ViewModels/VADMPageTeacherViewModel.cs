using System;
using System.Collections.ObjectModel;
using ATS.Models;
using ATS.Database;

namespace ATS.ViewModels
{
	public class VADMPageTeacherViewModel
	{
		private ObservableCollection<Option> options;
		public ObservableCollection<Option> Options
		{
			get { return options; }
			set
			{
				options = value;
			}
		}

		public VADMPageTeacherViewModel()
		{
			Options = new ObservableCollection<Option>();

			OptionData _context = new OptionData();

			foreach (var Option in _context.Options)
			{
				Options.Add(Option);
			}
		}
	}
}
