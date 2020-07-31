using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace HungryPizzaria.SDK.Core
{

    public class SigningConfigurations
    {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfigurations()
        {

            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HECTA-0987665G4-1258744-M87YYH-99-HungryPizzaria-SIGNATURE"));

            SigningCredentials = new SigningCredentials(
                Key, SecurityAlgorithms.HmacSha256);
        }
    }

    public class GenerateTokenBearer
    {
        readonly Core.TokenConfigurations _tokenConfiguration;
        readonly SigningConfigurations _signingConfigurations;
        public GenerateTokenBearer(Core.TokenConfigurations tokenConfiguration, SigningConfigurations signingConfigurations)
        {
            _tokenConfiguration = tokenConfiguration;
            _signingConfigurations = signingConfigurations;
        }


        public string GetJwtSecurityToken(string cpf, string tokenIdentification)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(cpf, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, cpf),
                        new Claim("TokenIdentification", SDK.Core.Crypto.Encrypt(tokenIdentification, cpf))
                    }
                );

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao +
                TimeSpan.FromSeconds(_tokenConfiguration.Seconds);


            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });

            return handler.WriteToken(securityToken);

        }

        public string GetJwtContractToken(ContractLicence entityContract)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(entityContract);
            json = SDK.Utils.Base64.ConverterJsonToBase64(json);
            json = SDK.Core.Crypto.Encrypt(json, entityContract.nrCnpj);
            return json;
        }

        public ContractLicence GetObjContractToken(string token, string nrCnpj) {


            var decrypt = SDK.Core.Crypto.Decrypt(token, nrCnpj);
            decrypt = SDK.Utils.Base64.ConverterBase64toJson(decrypt);

            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<ContractLicence>(decrypt);

            return obj;
        }

    }
}
