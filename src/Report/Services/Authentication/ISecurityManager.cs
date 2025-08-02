namespace Report.Services.Authentication
{
    public interface ISecurityManager
    {
        bool ComparePassword(string paswword, string salt, string hash);
        (string Salt, string Hash) GeneratePasswordPart(string password); 
    }
}
