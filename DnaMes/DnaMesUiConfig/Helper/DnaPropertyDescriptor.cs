// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/25 16:08
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using DnaLib.Helper;
using DnaMesModel;
using DnaMesUiConfig.Model;

namespace DnaMesUiConfig.Helper
{
    /// <inheritdoc />
    /// <summary>
    /// 重写属性描述类
    /// </summary>
    public class DnaPropertyDescriptor<T> : PropertyDescriptor
    {
        #region 构造函数

        public DnaPropertyDescriptor(Column column, Attribute[] attrs = null) : base(column.Name, attrs)
        {
            _column = column;
            var filedName = column.Name;
            if (filedName.Contains("$"))
            {
                var fields = filedName.Split('$');
                if (fields.Length == 2)
                {
                    _field1 = fields[0];
                    _field2 = fields[1];
                    _fieldType = ConfigFieldType.Property;
                }
            }
            else if (filedName.Contains("#"))
            {
                var fields = filedName.Split('#');
                if (fields.Length == 3)
                {
                    _field1 = fields[0];
                    _field2 = fields[2];
                    if (fields[1].IsInt())
                    {
                        _listIndex = Convert.ToInt32(fields[1]);
                    }

                    _fieldType = ConfigFieldType.List;
                }
            }

            else if (filedName.Contains("!"))
            {
                var fields = filedName.Split('!');
                if (fields.Length == 3 || fields.Length == 2)
                {
                    _field1 = fields[0];
                    _field2 = fields.Length == 2 ? fields[0] : fields[2];
                    _keyfield = fields[1];
                    _fieldType = ConfigFieldType.Dict;
                }
            }
        }

        public DnaPropertyDescriptor(MemberDescriptor descr) : base(descr)
        {
        }

        public DnaPropertyDescriptor(MemberDescriptor descr, Attribute[] attrs) : base(descr, attrs)
        {
        }

        #endregion

        #region 私有字段

        private readonly Column _column;

        /// <summary>
        /// 主字段
        /// 当<see cref="ConfigFieldType"/>!=<see cref="ConfigFieldType.Default"/>时适用
        /// </summary>
        private readonly string _field1;

        /// <summary>
        /// 辅字段/明细字段
        /// 当<see cref="ConfigFieldType"/>!=<see cref="ConfigFieldType.Default"/>时适用
        /// </summary>
        private readonly string _field2;

        /// <summary>
        /// 字段类型
        /// </summary>
        private readonly ConfigFieldType _fieldType = ConfigFieldType.Default;


        /// <summary>
        /// 字典中Key值
        /// 当<see cref="ConfigFieldType"/>==<see cref="ConfigFieldType.Dict"/>时适用
        /// </summary>
        private readonly string _keyfield;

        /// <summary>
        /// List中索引值
        /// 当<see cref="ConfigFieldType"/>==<see cref="ConfigFieldType.List"/>时适用
        /// </summary>
        private readonly int _listIndex;

        //private PropertyInfo propInfo;
        //private bool hasGotProp;

        #endregion

        #region 公有属性

        public override Type ComponentType => typeof(T);
        public override bool IsReadOnly => _column.IsReadOnly;

        public override Type PropertyType
        {
            get
            {
                var type = ComponentType.GetProperty(_column.Name)?.PropertyType;
                if (type == null)
                {
                    type = Type.GetType(_column.DataType);
                }

                return type ?? typeof(string);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// 字段显示名
        /// </summary>
        public override string DisplayName => _column.Text;

        #endregion

        #region 私有方法

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="component"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private dynamic GetValue(object component, string propertyName)
        {
            var propInfo = component?.GetType().GetProperty(propertyName);
            if (propInfo == null)
            {
                throw new ArgumentException($"{propertyName}不是{component}的属性", propertyName);
            }
            var value = propInfo.GetValue(component, null);
            if (_column.DataType == typeof(bool).FullName&& bool.TryParse(value?.ToString(), out var result))
            {
                return result ? "是" : "否"; //将True或False转换为“是”“否”，使之支持中文布尔值
            }

            return _column.Convert(value);
        }

        #endregion

        #region 公有方法

        public override bool CanResetValue(object component)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// 获取值
        /// 数据->窗体
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        public override object GetValue(object component)
        {
            if (!_column.Visible)
            {
                return null;
            }
            //ConfigFieldType为非默认值时适用
            PropertyInfo prop;
            object obj;
            switch (_fieldType)
            {
                case ConfigFieldType.Default:
                default:
                    return GetValue(component, Name);
                case ConfigFieldType.List:
                    prop = component.GetType().GetProperty(_field1);
                    obj = prop?.GetValue(component, null);
                    if (!(obj is IList list) || list.Count < _listIndex + 1) return null;
                    var element = list[_listIndex];
                    return GetValue(element, _field2);

                case ConfigFieldType.Property:
                    prop = component.GetType().GetProperty(_field1);
                    obj = prop?.GetValue(component, null);
                    return GetValue(obj, _field2);
                case ConfigFieldType.Dict:
                    prop = component.GetType().GetProperty(_field1);
                    obj = prop?.GetValue(component, null);
                    if (!(obj is IDictionary dic) || !dic.Contains(_keyfield)) return null;
                    var objInDic = dic[_keyfield];
                    if (objInDic.GetType().IsPrimitive || objInDic is string)
                    {
                        return objInDic;
                    }

                    return GetValue(objInDic, _field2);
            }
        }

        public override void ResetValue(object component)
        {
            throw new NotImplementedException();
        }

        public override void SetValue(object component, object value)
        {
            throw new NotImplementedException();
        }

        public override bool ShouldSerializeValue(object component)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// 配置字段类型
    /// </summary>
    public enum ConfigFieldType
    {
        /// <summary>
        /// 默认类型
        /// </summary>
        Default,

        //Reference,
        /// <summary>
        /// 集合类型，以#为分隔符
        /// 格式：{field1}#{index}{field2}
        /// </summary>
        List,

        /// <summary>
        /// 属性类型，以$为分隔符
        /// 格式：{field1}${field2}
        /// </summary>
        Property,

        /// <summary>
        /// 字典类型，以!为分隔符
        /// 格式：{field1}!{keyField}!{field2}
        /// </summary>
        Dict
    }
}