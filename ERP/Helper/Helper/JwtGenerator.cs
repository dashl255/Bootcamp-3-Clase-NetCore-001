using ERP.Helper.Data;
using ERP.Helper.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ERP.Helper.Helper
{
    public class JwtGenerator<T>
    {
        string SecretKey { get; set; }
        string Name { get; set; }
        string Rol { get; set; }
        string Issuer { get; set; }
        string Audience { get; set; }
        int DurationSec { get; set; }


        public JwtGenerator(string SecretKey, string Name, string Rol, string Issuer, string Audience, int DurationSec)
        {
            this.SecretKey = SecretKey;
            this.Name = Name;
            this.Rol = Rol;
            this.Issuer = Issuer;
            this.Audience = Audience;
            this.DurationSec = DurationSec;
        }

        public ResponseGeneralModel<T> GenerateJwt(string data)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                // Definir los reclamos (Claims) para el JWT
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, Name),
                    new Claim(ClaimTypes.Role, Rol),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("data", data)
                };

                // Crear el token
                var token = new JwtSecurityToken(
                    issuer: Issuer, // Emisor
                    audience: Audience, // Audiencia
                    claims: claims,
                    expires: DateTime.UtcNow.AddSeconds(DurationSec), // Tiempo de expiración del token
                    signingCredentials: credentials
                );

                // Retornar el token como una cadena
                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                return new ResponseGeneralModel<T>(200, jwtToken);
            }catch (Exception ex)
            {
                return new ResponseGeneralModel<T>(MessageHelper.jwtErrorEncrypt, ex.ToString(), 500);
            }
        }

        public ResponseGeneralModel<T> DeserializeJwt(string jwt)
        {
            try
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                JwtSecurityToken JsonToken = handler.ReadToken(jwt) as JwtSecurityToken;

                var CompareTime = JsonToken.ValidTo.CompareTo(DateTime.UtcNow);

                if (CompareTime < 0)
                {
                    return new ResponseGeneralModel<T>(MessageHelper.jwtErrorDesencryptTime, MessageHelper.jwtErrorDesencryptTime, 401);
                }

                if (JsonToken != null)
                {
                    string dataDes = JsonToken.Claims.FirstOrDefault(x => x.Type == "data").Value;
                    return new ResponseGeneralModel<T>(200, dataDes);
                }
            }
            catch (Exception ex) {
                new ResponseGeneralModel<T>(MessageHelper.jwtErrorDesencrypt, ex.ToString(), 500);
            }

            return new ResponseGeneralModel<T>(MessageHelper.jwtErrorDesencrypt, MessageHelper.jwtErrorDesencrypt, 401);
        }
    }
}
