using System;
using System.Collections.Generic;
using System.IO;
using DnaLib.Helper;
using DnaMesUiBll.Config.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DnaMesUnitTest
{
    [TestClass]
    public class MenuXmlUnitTest
    {
        [TestMethod]
        public void TestMenuBuilding()
        {
            var cons = BuildControl();
            CreateLogDirectory(RootPath, "\\XmlFile\\Menu.xml");
            XmlHelper.XmlSerializeToFile(cons, RootPath+"\\XmlFile\\Menu.xml");

        }
        private static readonly string RootPath = AppDomain.CurrentDomain.BaseDirectory;

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
        private static Control BuildControl()
        {
            return new Control
            {
                Items = new List<Menu>
                {
                    new Menu
                    {
                        Name = "mainMenu",
                        Text = "主菜单",
                        Dock = "Top",
                        PopMenus = new List<PopMenu>
                        {
                            //new PopMenu
                            //{
                            //    Name = "BasicInfoPop",
                            //    Text = "基础信息管理",
                            //    ShortCut = "J",
                            //    MenuItems = new List<MenuItem>
                            //    {
                            //        new MenuItem
                            //        {
                            //            Name = "MaterialManagement",
                            //            Text = "物料管理",
                            //            ShortCut = "W",
                            //            FormPath = "MaterialManagementForm",
                            //            FormType = FormType.ChildForm,
                            //            DomainId = 10001,
                            //            CommandType = CommandType.Activate,
                            //        },
                            //        new MenuItem
                            //        {
                            //            Name = "ProcessManagement",
                            //            Text = "工艺管理",
                            //            ShortCut = "G",
                            //            FormPath = "ProcessManagementForm",
                            //            FormType = FormType.ChildForm,
                            //            DomainId = 10002,
                            //            CommandType = CommandType.Activate,
                            //        },
                            //    }
                            //},
                            new PopMenu
                            {
                                Name = "OrderInfo",
                                Text = "订单信息管理",
                                ShortCut = "D",
                                MenuItems = new List<MenuItem>
                                {
                                    new MenuItem
                                    {
                                        Name = "PlanManagement",
                                        Text = "计划管理",
                                        ShortCut = "H",
                                        //FormPath = "PlanManagementForm",
                                        FormType = FormType.Null,
                                        DomainId = 10003,
                                        CommandType = CommandType.Close,
                                    },
                                    //new MenuItem
                                    //{
                                    //    Name = "WorkOrderManagement",
                                    //    Text = "工单管理",
                                    //    ShortCut = "D",
                                    //    FormPath = "WorkOrderManagementForm",
                                    //    FormType = FormType.ChildForm,
                                    //    DomainId = 10004,
                                    //},
                                }
                            },
                        }
                    }
                }
            };
        }
    }
}
