// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/11 22:36
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.IO;
using System.Text;

namespace DnaLib.Helper
{
    /// <summary>
    ///     日志帮助类
    /// </summary>
    public static class LogHelper
    {
        private static readonly string RootPath = AppDomain.CurrentDomain.BaseDirectory + "Log";

        /// <summary>
        ///     创建日志文件夹
        /// </summary>
        /// <returns></returns>
        private static void CreateLogDirectory(string path, string strfile)
        {
            try
            {
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                if (!File.Exists(path + strfile)) File.Create(path + strfile).Dispose();
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
        }

        public static void WriteErrorLog(Exception ex, string fileName,  string description = null)
        {
            var path = RootPath;
            var strFile = "\\ErrorLog_" + fileName + DateTime.Now.ToString("yyyyMMdd") + ".log";
            CreateLogDirectory(path, strFile);
            using (var sw = new StreamWriter(path + strFile, true, Encoding.Default))
            {
                sw.WriteLine("*****************************************【"
                             + DateTime.Now
                             + "】*****************************************");
                if (ex != null)
                {
                    //sw.WriteLine("【FunctionName】" + functionName);
                    sw.WriteLine("【ErrorType】" + ex.GetType());
                    sw.WriteLine("【TargetSite】" + ex.TargetSite);
                    sw.WriteLine("【Message】" + ex.Message);
                    sw.WriteLine("【Source】" + ex.Source);
                    sw.WriteLine("【StackTrace】" + ex.StackTrace);
                    if (!description.IsNullOrEmpty()) sw.WriteLine("【Extras】" + description);
                }
                else
                {
                    sw.WriteLine("Exception is NULL");
                }

                sw.WriteLine();
            }
        }

        public static void WriteWarningLog(string message,string fileName)
        {
            var path = RootPath;
            var strFile = "\\WarningLog_" + fileName + DateTime.Now.ToString("yyyyMMdd") + ".log";
            CreateLogDirectory(path, strFile);
            using (var sw = new StreamWriter(path + strFile, true, Encoding.Default))
            {
                sw.WriteLine("*****************************************【"
                             + DateTime.Now
                             + "】*****************************************");
                //sw.WriteLine("【FunctionName】" + functionName);
                sw.WriteLine("【WraningMessage】" + message);
                sw.WriteLine();
            }
        }
    }
}