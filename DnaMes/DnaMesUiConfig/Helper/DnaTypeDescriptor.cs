// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/25 16:27
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System.Collections.Generic;
using System.ComponentModel;
using DnaMesUiConfig.Model;

namespace DnaMesUiConfig.Helper
{
    /// <inheritdoc />
    /// <summary>
    /// 重写类型描述类
    /// </summary>
    public class DnaTypeDescriptor<T> : CustomTypeDescriptor
    {
        public DnaTypeDescriptor(List<Column> fields)
        {
            _fields = fields;
        }

        #region 私有字段

        private readonly List<Column> _fields;
        private List<PropertyDescriptor> _descriptors;

        #endregion

        #region 公有属性

        #endregion

        #region 私有方法

        #endregion

        #region 公有方法

        /// <inheritdoc />
        /// <summary>
        /// 获取属性列表
        /// </summary>
        /// <returns></returns>
        public override PropertyDescriptorCollection GetProperties()
        {
            if (_descriptors == null)
            {
                _descriptors = new List<PropertyDescriptor>();
                //得到当前对象的属性
                foreach (var col in _fields)
                {
                    var item = new DnaPropertyDescriptor<T>(col);
                    _descriptors.Add(item);
                }
            }

            //返回自定义属性集合   
            return new PropertyDescriptorCollection(_descriptors.ToArray());
        }

        #endregion
    }
}