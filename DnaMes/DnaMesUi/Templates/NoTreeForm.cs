using System;
using System.Collections.Generic;
using DnaMesModel.Model.BasicInfo;
using DnaMesUiBll.Shared;

namespace DnaMesUi.Templates
{
    /// <summary>
    /// Info:迁移步骤：
    /// 1、修改namespace
    /// 2、重命名Form
    /// </summary>
    public partial class NoTreeForm : BaseForm
    {
        public NoTreeForm()
        {
            InitializeComponent();
            var list = new List<Domain>
            {
                new Domain {FunctionCode = 52, Creator = "admin", CreationTime = DateTime.Now,},
                new Domain {FunctionCode = 666, Creator = "张三", CreationTime = DateTime.Now.AddYears(-100)},
                new Domain {FunctionCode = 52, Creator = "admin", CreationTime = DateTime.Now},
                new Domain {FunctionCode = 99, Creator = "我", CreationTime = DateTime.Now.AddDays(-96)},
                new Domain {FunctionCode = -9, Creator = null, CreationTime = DateTime.Now.AddDays(-96)},
            };
            GridBindingBll<Domain>.BindingStyleAndData(ug1,list,"BasicInfo\\Domain.xml",false);
        }
    }
}