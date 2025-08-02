using Report.Models;

namespace Report.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<(bool succcess, string Token)> SignIn
            (BasicSignInCredentials credentials, CancellationToken cancellationToken);

        Task<IIdentity> Authenticate(string authToken, CancellationToken cancellationToken); 
    }
}
