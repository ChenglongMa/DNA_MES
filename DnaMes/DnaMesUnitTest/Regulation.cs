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
        //TODO: 删除时依赖关系管理
        //TODO完结：确定MDI窗体动态加载逻辑 2018/02/24
        //TODO完结：设计默认Grid格式 2018/03/02
        //TODO完结：完成数据绑定逻辑 2018/03/02

        #endregion

        #region 代码规范

        #region UI设计

        //每个模块窗体toolBar先导致默认配置再添加按钮

        /* Form命名规范：
         * Mgt:Management
         */

        /* Menu.XML文件规范：
         * FormPath：{文件夹名}.{Form名}
         */

        /* Grid.XML文件规范
         * Name为属性名称
         * 支持属性的属性($)、属性为List(#)、属性为Dictionary(!) 详见DnaPropertyDescriptor.cs
         *
         */
        //将单元格设置成中文显示
        //new Column
        //{
        //    Name = "IsMain",
        //    Text = "主项目",
        //    DataType = typeof(string).FullName,//此处用string，若为Boolean则为CheckBox显示
        //    ColumnStyle = ColumnStyle.Default, //此处用Default即可
        //    IsReadOnly = false,
        //    Visible = true,
        //    Width = 80,
        //    Format = Column.BoolFormat.BoolCHN.ToString(),//此处设置中英文显示
        //}
    #endregion

    #region Model设计

    //关系[类名]格式：{roleA.className}{roleB.className}
    //关系[表名]格式：L_{roleA.className}{roleB.className}


    #endregion

    #endregion
}
}