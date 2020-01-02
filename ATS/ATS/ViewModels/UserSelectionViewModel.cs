using System;
using System.Collections.ObjectModel;
using ATS.Models;
using ATS.Database;

namespace ATS.ViewModels
{
    public class UserSelectionViewModel
    {
        private ObservableCollection<User> users;
        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                users = value;
            }
        }
        public UserSelectionViewModel()
        {
            Users = new ObservableCollection<User>();

            UserData _context = new UserData();

            foreach (var user in _context.Users)
            {
                Users.Add(user);
            }
        }
    }
}
