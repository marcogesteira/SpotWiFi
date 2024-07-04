using IdentityModel;
using IdentityServer4.Validation;
using SpotiWiFi.STS.Data;
using System.Security.Cryptography;
using System.Text;

namespace SpotiWiFi.STS.GrantType
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IIdentityRepository _identityRepository;

        public ResourceOwnerPasswordValidator(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var password = context.Password;
            var email = context.UserName;

            var user = await this._identityRepository.FindByEmailAndPasswordAsync(email, HashSHA256(password));

            if (user is not null)
            {
                context.Result = new GrantValidationResult(user.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
            }
        }

        public string HashSHA256(string plainText)
        {
            SHA256 criptoProvider = SHA256.Create();
            byte[] btexto = Encoding.UTF8.GetBytes(plainText);
            var criptoResultado = criptoProvider.ComputeHash(btexto);
            return Convert.ToHexString(criptoResultado);
        }
    }
}
