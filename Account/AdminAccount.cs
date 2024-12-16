using MyStoreNamespace;
public class AdminAccount : Account
{
    public AdminAccount(string userName, string password):base(userName,password)
    {
        UserName = userName;
        Password = password;
        IsAdmin = true; 
    }
}