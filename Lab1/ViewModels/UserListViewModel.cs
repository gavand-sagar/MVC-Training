namespace Lab1.ViewModels
{
    public class UserListViewModel
    {
        public List<UserViewModel> users = new List<UserViewModel>();
        
       public UserViewModel user = new UserViewModel();

        public string CurrentUser { get; set; }

    }
}
