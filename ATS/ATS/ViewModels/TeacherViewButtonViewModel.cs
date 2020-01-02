/******************************************************************
* The TeacherViewButtonViewModel page displays the therpists
*
* The function for adding therapists should be tested and modified
* if needed by the Spring 2020 team. 
*********************************************************************/
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using ATS.Models;
using ATS.Database;

namespace ATS.ViewModels
{
	public class TeacherViewButtonViewModel : BaseViewModel
	{
		private bool _isbusy = false;
		public bool IsBusy
		{
			get { return _isbusy; }
			set { _isbusy = value; OnPropertyChanged(); }
		}

		private static TeacherModel _teacher;
		public static TeacherModel StaticTeacher
		{
			get { return _teacher; }
			set { _teacher = value; }
		}
		public TeacherModel Teacher1
		{
			get { return _teacher; }
			set { _teacher = value; OnPropertyChanged(); }
		}

		public TeacherModel Teacher2
		{
			get { return _teacher; }
			set { _teacher = value; OnPropertyChanged(); }
		}

		public static TeacherModel _teacher1;
		public static TeacherModel _teacher2;
		/*public static ObservableCollection<TeacherModel> StaticTeachers
        {
            get { return _teachers; }
            set { _teachers = value; }
        }
        public ObservableCollection<TeacherModel> Teachers
        {
            get { return _teachers; }
            set { _teachers = value; OnPropertyChanged(); }
        }*/

		public TeacherViewButtonViewModel()
		{
			Teacher1 = new TeacherModel
			{
				Id = "1",
				Name = "Bob",
				Age = 22,
				Gender = "Male"
			};

			Teacher2 = new TeacherModel
			{
				Id = "37d39648-7f9d-4a6e-bcf8-64ef59e47bc1",
				Name = "Eman",
				Age = 19,
				Gender = "Male"
			};

			Initialize();
		}

		private async Task Initialize()
		{
			IsBusy = true;

			//  Database communication object to interact with our database
			DatabaseCommunication database = new DatabaseCommunication();

			//foreach (var id in teacherIds)
			_teacher1 = await database.getGenericModel<TeacherModel>(Teacher1.Id);
			_teacher2 = await database.getGenericModel<TeacherModel>(Teacher2.Id);


			IsBusy = false;
		}
	}
}
