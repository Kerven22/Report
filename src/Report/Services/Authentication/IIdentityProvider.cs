namespace Report.Services.Authentication
{
    public interface IIdentityProvider
    {
        IIdentity Current { get; set; }
    }

    public class IdentityProvider : IIdentityProvider
    {
        public IIdentity Current { get; set; } 
    }
}
