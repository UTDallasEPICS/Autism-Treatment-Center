using System;
using System.Collections.ObjectModel;
using ATS.Models;
using ATS.Database;

namespace ATS.ViewModels
{
	public class VADMViewModel
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

		public VADMViewModel()
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
