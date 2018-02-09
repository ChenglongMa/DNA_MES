using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DnaLib
{
    /// <summary>
    /// 加密工具类
    /// </summary>
    public class Encrypt
    {
        /// <summary>
        /// 使用DES加密指定字符串
        /// </summary>
        /// <param name="encryptStr">待加密的字符串</param>
        /// <param name="key">密钥(最大长度8)</param>
        /// <param name="IV">初始化向量(最大长度8)</param>
        /// <returns>加密后的字符串</returns>
        public static string DesEncrypt(string encryptStr, string key, string IV)
        {
            //将key和IV处理成8个字符
            key += "12345678";
            IV += "12345678";
            key = key.Substring(0, 8);
            IV = IV.Substring(0, 8);

            SymmetricAlgorithm sa = new DESCryptoServiceProvider();
            sa.Key = Encoding.UTF8.GetBytes(key);
            sa.IV = Encoding.UTF8.GetBytes(IV);
            var ict = sa.CreateEncryptor();

            var byt = Encoding.UTF8.GetBytes(encryptStr);

            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, ict, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();

            cs.Close();

            //加上一些干扰字符
            var retVal = Convert.ToBase64String(ms.ToArray());
            var ra = new Random();

            for (var i = 0; i < 8; i++)
            {
                var radNum = ra.Next(36);
                var radChr = Convert.ToChar(radNum + 65);//生成一个随机字符

                retVal = retVal.Substring(0, 2 * i + 1) + radChr + retVal.Substring(2 * i + 1);
            }

            return retVal;
        }

        /// <summary>
        /// 使用DES解密指定字符串
        /// </summary>
        /// <param name="encryptedValue">待解密的字符串</param>
        /// <param name="key">密钥(最大长度8)</param>
        /// <param name="IV">初始化向量(最大长度8)</param>
        /// <returns>解密后的字符串</returns>
        public static string DesDecrypt(string encryptedValue, string key, string IV)
        {
            //去掉干扰字符
            var tmp = encryptedValue;
            if (tmp.Length < 16)
            {
                return "";
            }

            for (var i = 0; i < 8; i++)
            {
                tmp = tmp.Substring(0, i + 1) + tmp.Substring(i + 2);
            }
            encryptedValue = tmp;

            //将key和IV处理成8个字符
            key += "12345678";
            IV += "12345678";
            key = key.Substring(0, 8);
            IV = IV.Substring(0, 8);

            try
            {
                SymmetricAlgorithm sa = new DESCryptoServiceProvider();
                sa.Key = Encoding.UTF8.GetBytes(key);
                sa.IV = Encoding.UTF8.GetBytes(IV);
                var ict = sa.CreateDecryptor();

                var byt = Convert.FromBase64String(encryptedValue);

                var ms = new MemoryStream();
                var cs = new CryptoStream(ms, ict, CryptoStreamMode.Write);
                cs.Write(byt, 0, byt.Length);
                cs.FlushFinalBlock();

                cs.Close();

                return Encoding.UTF8.GetString(ms.ToArray());
            }
            catch (Exception)
            {
                return "";
            }

        }

    }
}
