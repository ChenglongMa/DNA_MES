// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/09 13:47
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Threading;
using System.Windows.Forms;
using DnaLib.Helper;

namespace DnaMesUi
{
    internal static class Program
    {
        /// <summary>
        ///     应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            #region 全局异常处理
            //TODO:项目完结后启用
            ////设置应用程序处理异常方式：ThreadException处理  
            //Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            ////处理UI线程异常  
            //Application.ThreadException += Application_ThreadException;
            ////处理非UI线程异常  
            //AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            #endregion
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form1());
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = (Exception)e.ExceptionObject;
            MessageBoxHelper.ShowError(ex.Message);
            LogHelper.WriteErrorLog(ex, "non-UI Exception", $"Runtime terminating: {e.IsTerminating}");
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var ex = e.Exception;
            MessageBoxHelper.ShowError(ex.Message);
            LogHelper.WriteErrorLog(ex,"UI Exception");
        }
    }
}