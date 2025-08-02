using Microsoft.EntityFrameworkCore;
using Report.Database;
using Report.Models;
using Report.Services.Authentication;

namespace Report.Storage
{
    public class AuthenticationStorage : IAuthenticationStorage
    {
        private readonly ReportDbContext _dbContext;
        public AuthenticationStorage(ReportDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<RecognizedUser?> FindUser(string login, CancellationToken cancellationToken)
        {
           var userEntity = _dbContext.Users.Where(u => u.Login.Equals(login))
                .FirstOrDefaultAsync(cancellationToken);

            var recogizedUser = new RecognizedUser
            {
                UserId = userEntity.Result.Id,
                PasswordHash = userEntity.Result.PasswordHash,
                Salt = userEntity.Result.Salt
            };

            return recogizedUser; 
        }   
    }
}
