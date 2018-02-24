// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/11 18:46
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DnaMesModel.Model.BasicInfo;

namespace DnaMesModel.Shared
{
    /// <summary>
    /// 系统信息
    /// </summary>
    public static class SysInfo
    {
        #region 私有字段

        #endregion

        #region 公有属性

        /// <summary>
        /// 登录员工id
        /// </summary>
        public static string EmpId { get; set; } = "100001";


        /// <summary>
        /// 登录员工姓名
        /// </summary>
        public static string UserName { get; set; } = "admin";

        /// <summary>
        /// 登录时间
        /// </summary>
        public static DateTime LoginTime { get; set; }

        /// <summary>
        /// 服务器IP地址
        /// </summary>
        public static IPAddress ServerIp { get; set; }

        /// <summary>
        /// 权限点集合
        /// </summary>
        public static List<int> Domains { get; set; } = new List<int> {-1, 10001 , 10002 }; //-1为默认权限，所有用户都拥有

        /// <summary>
        /// 输出目录
        /// </summary>
        public static string BinPath => AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// 本机内网IP地址
        /// </summary>
        public static IPAddress InterIp
        {
            get
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                return host.AddressList.FirstOrDefault(address => address.AddressFamily.ToString() == "InterNetwork");
            }
        }

        #endregion

        #region 私有方法

        #endregion

        #region 公有方法

        #endregion
    }
}