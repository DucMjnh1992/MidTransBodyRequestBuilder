using System;
using System.Text;

namespace MidTrans.Core.Common
{
    public class Utility
    {
        public static string Base64Encode(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            string plainTextBase64 = Convert.ToBase64String(plainTextBytes);

            return plainTextBase64;
        }
    }
}
