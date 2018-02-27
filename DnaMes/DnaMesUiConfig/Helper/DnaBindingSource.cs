// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/26 10:14
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DnaMesUiConfig.Model;

namespace DnaMesUiConfig.Helper
{
    /// <inheritdoc />
    /// <summary>
    /// 自定义绑定源
    /// </summary>
    public class DnaBindingSource<T> : BindingSource
    {
        public DnaBindingSource(BindingList<T> value, List<Column> fields)
        {
            //BindingListInstance = value;
            _fields = fields;
            DataSource = value;
        }

        public DnaBindingSource(IList<T> value, List<Column> fields) : this(new BindingList<T>(value), fields)
        {
        }

        public DnaBindingSource(BindingList<T> value, List<Column> fields, List<string> specFields) : this(value,
            fields)
        {
            //BindingListInstance = value;
            _specFields = specFields;
        }

        #region 私有字段

        private readonly List<Column> _fields;
        private readonly List<string> _specFields;

        #endregion

        #region 公有属性

        //public BindingList<T> BindingListInstance { get; }

        #endregion

        #region 私有方法

        #endregion

        #region 公有方法

        public override string GetListName(PropertyDescriptor[] listAccessors)
        {
            return "";
        }

        public override PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            var typeDesc = new DnaTypeDescriptor<T>(_fields);
            var itemProperties = typeDesc.GetProperties();

            if (_specFields != null)
            {
                var orgin = TypeDescriptor.GetProperties(typeof(T));
                foreach (PropertyDescriptor item in orgin)
                {
                    foreach (var specField in _specFields)
                    {
                        if (item.Name == specField)
                        {
                            itemProperties.Add(item);
                        }
                    }
                }
            }

            return itemProperties;
        }

        #endregion
    }
}