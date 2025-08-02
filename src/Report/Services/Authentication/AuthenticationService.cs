
using Microsoft.Extensions.Options;
using Report.Models;
using System.Security.Cryptography;

namespace Report.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationStorage _authenticationStorage;
        private readonly ISecurityManager _securityManager;
        private readonly AuthenticationConfiguration _configuration;
        private readonly Lazy<TripleDES> _tripleDES = new(TripleDES.Create); 

        public AuthenticationService(
            IAuthenticationStorage authenticationStorage, 
            ISecurityManager securitManager, 
            IOptions<AuthenticationConfiguration> options)
        {
            _authenticationStorage = authenticationStorage;
            _securityManager = securitManager;
            _configuration = options.Value; 
        }


        public async Task<(bool succcess, string Token)> SignIn(BasicSignInCredentials credentials, CancellationToken cancellationToken)
        {
            var recoginezedUser = await _authenticationStorage.FindUser(credentials.Login, cancellationToken);
            if (recoginezedUser is null)
                throw new Exception("user is null");

            var success = _securityManager.ComparePassword(credentials.Password, recoginezedUser.Salt, recoginezedUser.PasswordHash);
            var userIdBytes = recoginezedUser.UserId.ToByteArray(); 

            using var encriptedStream = new MemoryStream();
            var key = Convert.FromBase64String(_configuration.Key);
            var iv = Convert.FromBase64String(_configuration.Iv);

            await using (var stream = new CryptoStream(
                encriptedStream,
                _tripleDES.Value.CreateEncryptor(key, iv),
                CryptoStreamMode.Write))
            {
                await stream.WriteAsync(userIdBytes, cancellationToken); 
            };
            return (success, Convert.ToBase64String(encriptedStream.ToArray())); 
        }


        public async Task<IIdentity> Authenticate(string authToken, CancellationToken cancellationToken)
        {
            using var decriptStream = new MemoryStream();

            var key = Convert.FromBase64String(_configuration.Key);
            var iv = Convert.FromBase64String(_configuration.Iv);

            await using (var stream = new CryptoStream
                (decriptStream,
                _tripleDES.Value.CreateDecryptor(key, iv),
                CryptoStreamMode.Write))
            {
                var enriptodByte =  Convert.FromBase64String(authToken);
                await stream.WriteAsync(enriptodByte, cancellationToken); 
            }

            var userId = new Guid(decriptStream.ToArray());
            return new User(userId); 

        }
    }
}
