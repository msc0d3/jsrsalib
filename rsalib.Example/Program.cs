using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rsalib;

namespace rsalib.Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // publickey to encrypt, can find it on js source in page
            // at garena, like this : D1EC51E7CEA07CB3233ADA6009006EF3EBF89EFD5CF77AAD211051D008077DC7142872B8C36EE971D4B368C79C13A6BBCB89B551A8308C68F71764C1519DEAD90B560E126B365375700CC5A2E6CF81E2A0FEEA31B53C1F8D3F3AE522DF9AB19B5C0C391D997D6DE56807328B9BBD5F6D08EA47614060177E12F65BDB95D5D6E3
            string publickey = "D1EC51E7CEA07CB3233ADA6009006EF3EBF89EFD5CF77AAD211051D008077DC7142872B8C36EE971D4B368C79C13A6BBCB89B551A8308C68F71764C1519DEAD90B560E126B365375700CC5A2E6CF81E2A0FEEA31B53C1F8D3F3AE522DF9AB19B5C0C391D997D6DE56807328B9BBD5F6D08EA47614060177E12F65BDB95D5D6E3";
            // exponent of public key, an find it on js source in page
            // at garena, like this : 10001
            string exponent = "10001";
            JavaScriptRSA jsRSA = new JavaScriptRSA(); // or JavaScriptRSA jsRSA = new JavaScriptRSA(publickey,exponent);
            jsRSA.RSASetPublic(publickey, exponent);
            // create encrypted pwd default
            string ecryptedPassword = jsRSA.RSAEncrypt("PasswordToEncrypt");
            // create encrypted pwd with timestamp
            string ecryptedPasswordTs = jsRSA.RSAEncrypt(JavaScriptRSA.AddTimeStamp("PasswordToEncrypt"));
            Console.WriteLine("without timestamp pwd : " + ecryptedPassword);
            Console.WriteLine("with timestamp pwd : " + ecryptedPasswordTs);
            Console.ReadLine();
        }
    }
}
