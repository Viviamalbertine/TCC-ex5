using System;
using System.Security.Cryptography;
using System.Text;

namespace OProjeto.Infrastructure.Security.Hashing
{
    /// <summary>
    /// Classe que comporta a funcionalidade de geração de código hash
    /// Nesta aplicação, ela é utilizada para gravar e comparar o resultado da geração hash de senhas
    /// a fim de manter a senha gravada de maneira segura
    /// </summary>
    public class HashProvider
    {
        /// <summary>
        /// Efetua o cálculo de hash de uma informação
        /// </summary>
        public string ComputeHash(string data)
        {
            var encoding = Encoding.Unicode;
            var contentBytes = encoding.GetBytes(data);
            var hashProvider = SHA256.Create();

            try
            {
                var sbHash = new StringBuilder();
                byte[] hashBytes = hashProvider.ComputeHash(contentBytes);

                for (int i = 0; i < hashBytes.Length; i++)
                    sbHash.Append(hashBytes[i].ToString("x2"));

                return sbHash.ToString();
            }
            finally
            {
                hashProvider = null;
                Array.Clear(contentBytes, 0, contentBytes.Length);
            }
        }
    }
}