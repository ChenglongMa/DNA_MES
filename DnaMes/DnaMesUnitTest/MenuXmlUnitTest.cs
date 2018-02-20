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
        public void TestMethod1()
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
                Items = new List<ControlItem>
                {
                    new Menu
                    {
                        Name = "mainMenu",
                        Text = "主菜单",
                        Dock = "Top",
                        PopMenus = new List<PopMenu>
                        {
                            new PopMenu
                            {
                                Name = "BasicInfoPop",
                                Text = "基础信息管理",
                                ShortCut = "J",
                                MenuItems = new List<MenuItem>
                                {
                                    new FormMenuItem
                                    {
                                        Name = "MaterialManagement",
                                        Text = "物料管理",
                                        ShortCut = "W",
                                        FormPath = "MaterialManagementForm",
                                        Type = FormType.ChildForm,
                                        DomainId = 10001,
                                    },
                                    new FormMenuItem
                                    {
                                        Name = "ProcessManagement",
                                        Text = "工艺管理",
                                        ShortCut = "G",
                                        FormPath = "ProcessManagementForm",
                                        Type = FormType.ChildForm,
                                        DomainId = 10002,
                                    },
                                }
                            },
                            new PopMenu
                            {
                                Name = "OrderInfo",
                                Text = "订单信息管理",
                                ShortCut = "D",
                                MenuItems = new List<MenuItem>
                                {
                                    new FormMenuItem
                                    {
                                        Name = "PlanManagement",
                                        Text = "计划管理",
                                        ShortCut = "H",
                                        FormPath = "PlanManagementForm",
                                        Type = FormType.ChildForm,
                                        DomainId = 10003,
                                    },
                                    new FormMenuItem
                                    {
                                        Name = "WorkOrderManagement",
                                        Text = "工单管理",
                                        ShortCut = "D",
                                        FormPath = "WorkOrderManagementForm",
                                        Type = FormType.ChildForm,
                                        DomainId = 10004,
                                    },
                                }
                            },
                        }
                    }
                }
            };
        }
    }
}
