// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/09 14:05
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DnaLib.Helper
{
    /// <summary>
    ///     加密工具类
    /// </summary>
    public static class EncryptHelper
    {
        /// <summary>
        ///     加密，可逆
        /// </summary>
        /// <param name="encryptStr">待加密的字符串</param>
        /// <param name="key">密钥(最大长度8)</param>
        /// <param name="iv">初始化向量(最大长度8)</param>
        /// <returns>加密后的字符串</returns>
        public static string DesEncrypt(this string encryptStr, string key="12345678", string iv="12345678")
        {
            //将key和IV处理成8个字符
            key += "12345678";
            iv += "12345678";
            key = key.Substring(0, 8);
            iv = iv.Substring(0, 8);

            SymmetricAlgorithm sa = new DESCryptoServiceProvider
            {
                Key = Encoding.UTF8.GetBytes(key),
                IV = Encoding.UTF8.GetBytes(iv)
            };
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
                var radChr = Convert.ToChar(radNum + 65); //生成一个随机字符

                retVal = retVal.Substring(0, 2 * i + 1) + radChr + retVal.Substring(2 * i + 1);
            }

            return retVal;
        }

        /// <summary>
        ///     解密，可逆
        /// </summary>
        /// <param name="encryptedValue">待解密的字符串</param>
        /// <param name="key">密钥(最大长度8)</param>
        /// <param name="iv">初始化向量(最大长度8)</param>
        /// <returns>解密后的字符串</returns>
        public static string DesDecrypt(this string encryptedValue, string key="12345678", string iv="12345678")
        {
            //去掉干扰字符
            var tmp = encryptedValue;
            if (tmp.Length < 16) return "";

            for (var i = 0; i < 8; i++) tmp = tmp.Substring(0, i + 1) + tmp.Substring(i + 2);
            encryptedValue = tmp;

            //将key和IV处理成8个字符
            key += "12345678";
            iv += "12345678";
            key = key.Substring(0, 8);
            iv = iv.Substring(0, 8);

            try
            {
                SymmetricAlgorithm sa = new DESCryptoServiceProvider
                {
                    Key = Encoding.UTF8.GetBytes(key),
                    IV = Encoding.UTF8.GetBytes(iv)
                };
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
        /// <summary>
        /// 32位MD5加密，不可逆
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Md5Hash(this string source)
        {
            var md5Hasher = new MD5CryptoServiceProvider();
            var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(source));
            var sBuilder = new StringBuilder();
            foreach (var d in data)
            {
                sBuilder.Append(d.ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}