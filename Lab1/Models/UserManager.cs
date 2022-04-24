using Lab1.ViewModels;

namespace Lab1.Models
{
    public static class UserManager
    {
        public static UserViewModel userData = new UserViewModel();

        public static List<UserViewModel> users = new List<UserViewModel>();

        public static void AddUser(UserViewModel userPostedFromClient)
        {
            if (userPostedFromClient.Id > 0)
            {
                // upadate previous record

                foreach (var dbEntityForUser in users)
                {
                    if (dbEntityForUser.Id == userPostedFromClient.Id)
                    {
                        dbEntityForUser.Name = userPostedFromClient.Name;
                        dbEntityForUser.Age = userPostedFromClient.Age;
                        dbEntityForUser.City = userPostedFromClient.City;
                    }
                }
            }
            else
            {
                //new entry
                int numberofusers = users.Count;
                userPostedFromClient.Id = numberofusers + 1;
                users.Add(userPostedFromClient);
            }

        }




        public static void DeleteUser(int id)
        {
            UserViewModel user = users.Where(x => x.Id == id).FirstOrDefault();

            users.Remove(user);
        }


    }
}
