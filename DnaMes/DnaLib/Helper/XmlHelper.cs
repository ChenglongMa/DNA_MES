// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/11 22:36
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DnaLib.Helper
{
    public static class XmlHelper
    {
        private static void XmlSerializeInternal(Stream stream, object o, Encoding encoding)
        {
            if (o == null)
                throw new ArgumentNullException(nameof(o));
            if (encoding == null)
                throw new ArgumentNullException(nameof(encoding));

            var serializer = new XmlSerializer(o.GetType());

            var settings = new XmlWriterSettings
            {
                Indent = true,
                NewLineChars = "\r\n",
                Encoding = encoding,
                IndentChars = "    ",
                //OmitXmlDeclaration = true // 不生成声明头
            };
            // 强制指定命名空间，覆盖默认的命名空间。
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var writer = XmlWriter.Create(stream, settings))
            {
                //serializer.Serialize(writer, o);
                serializer.Serialize(writer, o, namespaces);
                writer.Close();
            }
        }

        /// <summary>
        ///     将一个对象序列化为XML字符串
        /// </summary>
        /// <param name="o">要序列化的对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>序列化产生的XML字符串</returns>
        public static string XmlSerialize(object o, Encoding encoding)
        {
            using (var stream = new MemoryStream())
            {
                XmlSerializeInternal(stream, o, encoding);

                stream.Position = 0;
                using (var reader = new StreamReader(stream, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        ///     将一个对象按XML序列化的方式写入到一个文件
        /// </summary>
        /// <param name="o">要序列化的对象</param>
        /// <param name="path">保存文件路径</param>
        /// <param name="encoding">编码方式</param>
        public static void XmlSerializeToFile(object o, string path, Encoding encoding = null)
        {
            if (path.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(path));
            var encode = encoding ?? Encoding.UTF8;
            using (var file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                XmlSerializeInternal(file, o, encode);
            }
        }

        /// <summary>
        ///     从XML字符串中反序列化对象
        /// </summary>
        /// <typeparam name="T">结果对象类型</typeparam>
        /// <param name="s">包含对象的XML字符串</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>反序列化得到的对象</returns>
        public static T XmlDeserialize<T>(string s, Encoding encoding)
        {
            if (s.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(s));
            if (encoding == null)
                throw new ArgumentNullException(nameof(encoding));

            var mySerializer = new XmlSerializer(typeof(T));
            MemoryStream ms = null;
            try
            {
                ms = new MemoryStream(encoding.GetBytes(s));

                using (var sr = new StreamReader(ms, encoding))
                {
                    return (T) mySerializer.Deserialize(sr);
                }
            }
            finally
            {
                ms?.Dispose(); //DisposeIfNotNull();
            }
        }

        /// <summary>
        ///     读入一个文件，并按XML的方式反序列化对象。
        /// </summary>
        /// <typeparam name="T">结果对象类型</typeparam>
        /// <param name="path">文件路径</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>反序列化得到的对象</returns>
        public static T XmlDeserializeFromFile<T>(string path, Encoding encoding = null)
        {
            if (path.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(path));
            if (encoding == null)
                encoding = Encoding.UTF8;
            if (!File.Exists(path)) throw new FileNotFoundException($"找不到指定文件：路径：{path}");
            var xml = File.ReadAllText(path, encoding);
            return xml.Trim().IsNullOrEmpty() ? Activator.CreateInstance<T>() : XmlDeserialize<T>(xml, encoding);
        }
    }
}