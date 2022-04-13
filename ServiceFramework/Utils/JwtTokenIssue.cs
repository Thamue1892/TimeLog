using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Jose;

namespace ServiceFramework.Utils
{
    public static class JwtTokenIssuer
    {
        public static string Issuer { get; set; }
        public static string EncryptionSecretKey { get; set; }
        private static byte[] SecretKey
        {
            get
            {
                var secretKey = Encoding.ASCII.GetBytes(EncryptionSecretKey);
                var secretKeyBytes = SHA256.Create().ComputeHash(secretKey);
                return secretKeyBytes;
            }
        }


        public static string GenerateJwtToken(TokenInfo tokenInfo)
        {
            var payload = new Dictionary<string, object>() { { "iss", tokenInfo.Iss }, { "sub", tokenInfo.Sub }, { "jti", tokenInfo.Jti }, { "aud", tokenInfo.Aud }, { "exp", tokenInfo.Exp }, { "iat", tokenInfo.Iat } };

            string token = JWT.Encode(payload, SecretKey, JweAlgorithm.A256KW, JweEncryption.A256CBC_HS512);
            return token;
        }

        public static TokenInfo IsValidToken(string token)
        {

            TokenInfo tkinfo = JWT.Decode<TokenInfo>(token, SecretKey);

            if (tkinfo.Iss == "www.tirisan.co.za") //Config Issuer
            {
                return tkinfo;
            }
            throw new InvalidOperationException("INVALID TOKEN");

        }

        public class TokenInfo
        {
            public string Iss { get; set; }
            public string Sub { get; set; }
            public string Jti { get; set; }
            public string Aud { get; set; }
            public long Exp { get; set; }
            public long Iat { get; set; }
        }
    }
}