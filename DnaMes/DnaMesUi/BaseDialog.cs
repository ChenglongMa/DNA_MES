using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DnaMesModel;
using DnaMesUiBll.Shared;

namespace DnaMesUi
{
    public abstract partial class BaseDialog<T> : Form where T : BaseModel, new()
    {
        protected BaseDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 业务操作类
        /// </summary>
        protected abstract BaseBll<T> Bll { get; }

        /// <summary>
        /// 用于与父窗体之间传值
        /// </summary>
        public abstract T TransModel { get; }

        /// <summary>
        /// 向控件绑定值
        /// </summary>
        /// <param name="model"></param>
        protected abstract void BindingModel(T model);
    }
}