
    namespace MyStoreNamespace
    {
        public class Account
        {
            public int Id { get; set; }
            internal string Password { get; set; }
            private static int _nextId = 1;
            private static readonly Stack<int> ReusableIds = new Stack<int>();
            public decimal Balance { get; set; }
            public bool LoggedIn { get; private set; } 
            public string UserName { get; set; }
            public bool IsAdmin { get; protected set; } 

            protected internal Account(string userName, string password)
            {
                Id = ReusableIds.Count > 0 ? ReusableIds.Pop() : _nextId++;
                UserName = userName;
                Password = password;
                LoggedIn = false;
                IsAdmin = false;
            }
            
            public void Login()
            {
                LoggedIn = true;
            }

            public void Logout()
            {
                LoggedIn = false;
            }
            public static void ReleaseId(int id)
            {
                ReusableIds.Push(id);
            }

            
        }
    }
