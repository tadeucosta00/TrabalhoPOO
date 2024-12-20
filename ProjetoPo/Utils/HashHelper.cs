using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPo.Utils
{
    public static class HashHelper
    {
        public static string GerarHashSHA256(string input)
        {
            byte[] data = Encoding.ASCII.GetBytes(input);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            return BitConverter.ToString(data).Replace("-", "").ToLower();
        }
    }
}
