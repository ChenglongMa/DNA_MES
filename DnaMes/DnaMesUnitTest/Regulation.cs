// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/19 19:56
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

namespace DnaMesUnitTest
{
    /// <summary>
    /// 代码规范
    /// </summary>
    internal abstract class Regulation
    {
        #region ToDoList

        //TODO：完善登录窗口逻辑
        //TODO完结：确定MDI窗体动态加载逻辑 2018/02/24
        //TODO：设计默认Grid格式

        #endregion

        #region 代码规范

        #region UI设计

        //每个模块窗体toolBar先导致默认配置再添加按钮

        /* Form命名规范：
         * Mant:Management
         */

        /* Menu.XML文件规范：
         * FormPath：{文件夹名}.{Form名}
         */

        /* Grid.XML文件规范
         * Name为属性名称
         * 支持属性的属性($)、属性为List(#)、属性为Dictionary(!) 详见DnaPropertyDescriptor.cs
         *
         */
        #endregion

        #region Model设计

        //关系[类名]格式：{roleA.className}{roleB.className}
        //关系[表名]格式：L_{roleA.className}{roleB.className}

        #endregion

        #endregion
    }
}