// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/20 16:25
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

namespace DnaMesUiBll.Config.Model
{
    /// <summary>
    /// 窗体加载类型
    /// </summary>
    public enum FormType
    {
        /// <summary>
        /// 无Form加载
        /// </summary>
        Null=-1,
        /// <summary>
        /// 子窗体加载至MDI Form内
        /// </summary>
        ChildForm=0,
        /// <summary>
        /// 对话框
        /// </summary>
        Dialog=1,
    }
}