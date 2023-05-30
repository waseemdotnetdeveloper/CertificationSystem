using SelectPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace BAL
{
    public class Common
    {
        public static string Encryption(string Password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[Password.ToString().Length];
            encode = Encoding.UTF8.GetBytes(Password);
            strmsg = Convert.ToBase64String(encode);
            string encrypwd = strmsg;

            return strmsg;


        }

        public static string Decryption(string Password)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(Password);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            string decryption = decryptpwd;
            return decryption;
        }
    }
}