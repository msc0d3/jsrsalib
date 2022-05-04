using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace rsalib
{
    public class JavaScriptRSA
    {
        private BigInteger n;
        private int e;
        public JavaScriptRSA()
        {

        }
        public JavaScriptRSA(string publickey, string exponent)
        {
            RSASetPublic(publickey, exponent);
        }
        public void RSASetPublic(string publickey, string exponent)
        {
            if (publickey == null || exponent == null || (publickey.Length <= 0 || exponent.Length <= 0))
                throw new Exception("Invalid RSA public key");
            this.n = new BigInteger(publickey, 16);
            this.e = int.Parse(exponent, NumberStyles.HexNumber);
        }
        private BigInteger Pkcs1Pad2(string s, int n)
        {
            if (n < s.Length + 11)
                throw new Exception("Message too long for RSA");
            byte[] inData = new byte[n];
            int num1 = s.Length - 1;
            while (num1 >= 0 && n > 0)
            {
                byte num2 = Encoding.UTF8.GetBytes(s)[num1--];
                if ((int)num2 < 128)
                    inData[--n] = num2;
                else if ((int)num2 > (int)sbyte.MaxValue && (int)num2 < 2048)
                {
                    inData[--n] = (byte)((int)num2 & 63 | 128);
                    inData[--n] = (byte)((int)num2 >> 6 | 192);
                }
                else
                {
                    inData[--n] = (byte)((int)num2 & 63 | 128);
                    inData[--n] = (byte)((int)num2 >> 6 & 63 | 128);
                    inData[--n] = (byte)((int)num2 >> 12 | 224);
                }
            }
            inData[--n] = (byte)0;
            Random random = new Random();
            int num3;
            for (; n > 2; inData[--n] = (byte)num3)
            {
                num3 = 0;
                while (num3 == 0)
                    num3 = random.Next((int)byte.MaxValue);
            }
            inData[--n] = (byte)2;
            inData[--n] = (byte)0;
            return new BigInteger(inData);
        }

        private BigInteger RSADoPublic(BigInteger x)
        {
            return x.modPow((BigInteger)this.e, this.n);
        }

        public string RSAEncrypt(string text)
        {
            BigInteger x = this.Pkcs1Pad2(text, this.BitLength(this.n) + 7 >> 3);
            if (x == (BigInteger)null)
                return (string)null;
            BigInteger bigInteger = this.RSADoPublic(x);
            if (bigInteger == (BigInteger)null)
                return (string)null;
            string str = bigInteger.ToString(16).ToLower();
            if ((str.Length & 1) == 0)
                return str;
            return "0" + str;
        }

        private int BitLength(BigInteger value)
        {
            int num = 0;
            do
            {
                ++num;
                value /= (BigInteger)2;
            }
            while (value != (BigInteger)0);
            return num;
        }

        public static string AddTimeStamp(string password)
        {
            return "{\"timestamp\":" + ((long)(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds / 1000L).ToString() + ",\"password\":\"" + password + "\"}";
        }
    }
}
