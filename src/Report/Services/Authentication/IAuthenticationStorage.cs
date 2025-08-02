using Report.Database;
using Report.Models;

namespace Report.Services.Authentication
{
    public interface IAuthenticationStorage
    {
        Task<RecognizedUser?> FindUser(string userName, CancellationToken cancellationToken); 
    }
}
