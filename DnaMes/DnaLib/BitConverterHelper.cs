// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/11 22:36
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DnaLib
{
    /// <summary>
    ///     值转换 帮助类
    /// </summary>
    public static class BitConverterHelper
    {


        #region 值获取

        /// <summary>
        ///     获取byte值的bit位值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="index">索引，0-7</param>
        /// <returns></returns>
        public static int GetBit(this byte value, int index) => index < 0 || index > 7 ? -1 : (value >> index) & 1;

        #endregion

        #region 值转换

        #region 大小端判断

        private static readonly bool LittleEndian;

        static BitConverterHelper()
        {
            unsafe
            {
                var tester = 1;
                LittleEndian = *(byte*) &tester == 1;
            }
        }

        private static byte[] Reverse(byte[] data)
        {
            if (LittleEndian) Array.Reverse(data);
            return data;
        }

        #endregion

        public static byte[] ToBytes(this ushort value) => Reverse(BitConverter.GetBytes(value));

        public static byte[] ToBytes(this short value) => Reverse(BitConverter.GetBytes(value));

        public static byte[] ToBytes(this int value) => Reverse(BitConverter.GetBytes(value));

        public static byte[] ToBytes(this float value) => Reverse(BitConverter.GetBytes(value));

        public static byte[] ToBytes(this double value) => Reverse(BitConverter.GetBytes(value));

        public static short ToShort(this byte[] data) => BitConverter.ToInt16(Reverse(data), 0);

        public static int ToInt(this byte[] data) => BitConverter.ToInt32(Reverse(data), 0);

        public static float ToFloat(this byte[] data) => BitConverter.ToSingle(Reverse(data), 0);

        public static double ToDouble(this byte[] data) => BitConverter.ToDouble(Reverse(data), 0);

        /// <summary>
        ///     将数组转换为ASCII字符串
        /// </summary>
        /// <param name="dataBytes"></param>
        /// <returns></returns>
        public static string ToAscii(this byte[] dataBytes)
        {
            var asciiEncoding = new ASCIIEncoding();
            return asciiEncoding.GetString(dataBytes).Trim();
        }

        /// <summary>
        ///     将byte转换为ASCII字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToAscii(this byte data)
        {
            var asciiEncoding = new ASCIIEncoding();
            var dataBytes = new[] {data};
            return asciiEncoding.GetString(dataBytes).Trim();
        }

        #endregion
    }
}