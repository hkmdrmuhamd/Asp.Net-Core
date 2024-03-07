namespace MeetingApp.Models
{
    public static class Repository
    {
        private static List<UserInfo> _userInfo = new List<UserInfo>();

        static Repository()
        {
            _userInfo.Add(new UserInfo { Id = 1, Name = "Ali", Phone = "1234567890", Email = "abc@gmail.com", WillAttend = true });
            _userInfo.Add(new UserInfo { Id = 2, Name = "Veli", Phone = "2574865514", Email = "asd@gmail.com", WillAttend = false });
            _userInfo.Add(new UserInfo { Id = 3, Name = "Deli", Phone = "7895462130", Email = "zxc@gmail.com", WillAttend = true });
        }

        public static List<UserInfo> Users
        {
            get
            {
                return _userInfo;
            }
        }

        public static void AddUser(UserInfo user)
        {
            user.Id = Users.Count + 1;
            _userInfo.Add(user);
        }

        public static UserInfo? GetById(int id)
        {
            return _userInfo.FirstOrDefault(i => i.Id == id);
        }
    }
}