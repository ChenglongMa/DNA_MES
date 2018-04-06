using System;
using System.Collections.Generic;
using System.IO;
using DnaLib.Control;
using DnaLib.Helper;
using DnaMesUi.BasicInfo;
using DnaMesUi.Templetes;
using DnaMesUiBll.Shared;
using DnaMesUiConfig.Model;
using Infragistics.Win.UltraWinGrid;
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
            var path = CreateLogDirectory(RootPath, "\\Config\\Menu\\MESMenu.xml");
            XmlHelper.XmlSerializeToFile(cons, path);
            //Assert.IsTrue(path.ToUpper().Contains("UI"));
        }

        [TestMethod]
        public void TestProjectGrid()
        {
            TestGridBinding(BuildProjectGrid(), "BasicInfo\\Project.xml");
        }

        private void TestGridBinding(GridConfig cons, string fileName)
        {
            var path = CreateLogDirectory(RootPath, "\\Config\\" + fileName);
            XmlHelper.XmlSerializeToFile(cons, path);
        }

        private static readonly string
            RootPath = Directory.GetCurrentDirectory(); //AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        ///     创建日志文件夹
        /// </summary>
        /// <returns></returns>
        private static string CreateLogDirectory(string path, string strfile)
        {
            try
            {
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                if (!File.Exists(path + strfile)) File.Create(path + strfile).Dispose();
                return path + strfile;
            }
            catch (Exception ex)
            {
                MsgBoxLib.ShowError(ex.Message);
                return null;
            }
        }

        private static Menu BuildControl()
        {
            return new Menu
            {
                Name = "MainMenuBar",
                Text = "主菜单",
                IsLarge = false,
                PopMenus = new List<PopMenu>
                {
                    new PopMenu
                    {
                        Name = "FilePop",
                        Text = "文件",
                        ShortCut = "F",
                        MenuItems = new List<MenuItem>
                        {
                            new MenuItem
                            {
                                Name = "MyHome",
                                Text = "我的主页",
                                ShortCut = "H",
                                FormPath = "Shared.Sys.HomeForm",
                                FormType = FormType.ChildForm,
                                DomainId = -1,
                                CommandType = CommandType.Activate,
                            },
                            new MenuItem
                            {
                                Name = "Logout",
                                Text = "注销",
                                ShortCut = "L",
                                //FormPath = $"{nameof(DnaMesUi.BasicInfo)}.{nameof(ProcessMantForm)}",
                                FormType = FormType.Null,
                                DomainId = -1,
                                CommandType = CommandType.Logout,
                            },
                            new MenuItem
                            {
                                Name = "Exit",
                                Text = "退出",
                                ShortCut = "E",
                                //FormPath = $"{nameof(DnaMesUi.BasicInfo)}.{nameof(ProcessMantForm)}",
                                FormType = FormType.Null,
                                DomainId = -1,
                                CommandType = CommandType.Close,
                            },
                        }
                    },
                    new PopMenu
                    {
                        Name = "BasicInfoPop",
                        Text = "基础信息",
                        ShortCut = "B",
                        MenuItems = new List<MenuItem>
                        {
                            new MenuItem
                            {
                                Name = "ProjectMant",
                                Text = "项目管理",
                                ShortCut = "P",
                                FormPath = $"{nameof(DnaMesUi.Templetes)}.{nameof(NoTreeForm)}",
                                FormType = FormType.ChildForm,
                                DomainId = 10001,
                                CommandType = CommandType.Activate,
                            },
                            new MenuItem
                            {
                                Name = "ProcessMant",
                                Text = "工艺管理",
                                ShortCut = "R",
                                FormPath = $"{nameof(DnaMesUi.Templetes)}.{nameof(WithTreeForm)}",
                                FormType = FormType.ChildForm,
                                DomainId = 10002,
                                CommandType = CommandType.Activate,
                            },
                        }
                    },
                    //new PopMenu
                    //{
                    //    Name = "OrderInfo",
                    //    Text = "订单信息管理",
                    //    ShortCut = "D",
                    //    MenuItems = new List<MenuItem>
                    //    {
                    //        new MenuItem
                    //        {
                    //            Name = "PlanManagement",
                    //            Text = "计划管理",
                    //            ShortCut = "H",
                    //            //FormPath = "PlanManagementForm",
                    //            FormType = FormType.Null,
                    //            DomainId = 10001,
                    //            CommandType = CommandType.Close,
                    //        },
                    //        new MenuItem
                    //        {
                    //            Name = "WorkOrderManagement",
                    //            Text = "工单管理",
                    //            ShortCut = "D",
                    //            FormPath = "WorkOrderManagementForm",
                    //            FormType = FormType.ChildForm,
                    //            DomainId = 10004,
                    //        },
                    //    }
                    //},
                    //new PopMenu
                    //{
                    //    Name = "UserPage",
                    //    Text = "个人中心",
                    //    ShortCut = "H",
                    //    MenuItems = new List<MenuItem>
                    //    {
                    //        new MenuItem
                    //        {
                    //            Name = "Home",
                    //            Text = "我的主页",
                    //            ShortCut = "H",
                    //            FormPath = "Shared.Sys.HomeForm",
                    //            FormType = FormType.ChildForm,
                    //            DomainId = 10001,
                    //            CommandType = CommandType.Activate,
                    //        },
                    //        new MenuItem
                    //        {
                    //            Name = "Home2",
                    //            Text = "我的主页_带参数",
                    //            ShortCut = "H",
                    //            FormPath = "Shared.Sys.HomeForm",
                    //            FormType = FormType.Dialog,
                    //            DomainId = 10001,
                    //            CommandType = CommandType.Activate,
                    //            Params = new object[] {1,2},
                    //        },
                    //    }
                },
            };
        }

        private static GridConfig BuildProjectGrid()
        {
            return new GridConfig
            {
                Name = "ug",
                Text = "项目管理",
                Columns = new List<Column>
                {
                    new Column
                    {
                        Name = "Code",
                        Text = "项目编号",
                        DataType = typeof(string).FullName,
                        ColumnStyle = ColumnStyle.Default,
                        IsReadOnly = true,
                        Visible = true,
                        Width = 120,
                    },
                    new Column
                    {
                        Name = "Name",
                        Text = "项目名称",
                        DataType = typeof(string).FullName,
                        ColumnStyle = ColumnStyle.Default,
                        IsReadOnly = true,
                        Visible = true,
                        Width = 120,
                    },
                    new Column
                    {
                        Name = "StartingTime",
                        Text = "开始时间",
                        DataType = typeof(DateTime).FullName,
                        ColumnStyle = ColumnStyle.DateTime,
                        IsReadOnly = true,
                        Visible = true,
                        Width = 120,
                    },
                    new Column
                    {
                        Name = "EndingTime",
                        Text = "结束时间",
                        DataType = typeof(DateTime).FullName,
                        ColumnStyle = ColumnStyle.DateTime,
                        IsReadOnly = true,
                        Visible = true,
                        Width = 120,
                    },
                    new Column
                    {
                        Name = "IsMain",
                        Text = "主项目",
                        DataType = typeof(string).FullName,
                        ColumnStyle = ColumnStyle.Default,
                        IsReadOnly = false,
                        Visible = true,
                        Width = 80,
                        Format = Column.BoolFormat.BoolCHN.ToString(),
                    },
                }
            };
        }

        private static GridConfig BuildGrid()
        {
            return new GridConfig
            {
                Name = "ug",
                Text = "权限管理",
                Columns = new List<Column>
                {
                    new Column
                    {
                        Name = "Check",
                        Text = "选择",
                        DataType = typeof(bool).FullName,
                        ColumnStyle = ColumnStyle.CheckBox,
                        IsReadOnly = false,
                        Visible = true,
                        Width = 100,
                    },
                    new Column
                    {
                        Name = "FunctionCode",
                        Text = "功能码",
                        DataType = typeof(int).FullName,
                        ColumnStyle = ColumnStyle.Integer,
                        IsReadOnly = true,
                        Visible = true,
                        Width = 220,
                    },
                    new Column
                    {
                        Name = "Creator",
                        Text = "创建者",
                        DataType = typeof(string).FullName,
                        ColumnStyle = ColumnStyle.EditButton,
                        IsReadOnly = false,
                        Visible = true,
                        Width = 30,
                    },
                    new Column
                    {
                        Name = "CreationTime",
                        Text = "创建时间",
                        DataType = typeof(DateTime).FullName,
                        ColumnStyle = ColumnStyle.DateTime,
                        IsReadOnly = false,
                        Visible = true,
                        Width = 100,
                    },
                }
            };
        }
    }
}