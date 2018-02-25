// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/25 16:08
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.ComponentModel;
using DnaLib.Helper;
using DnaMesModel;
using DnaMesUiConfig.Model;

namespace DnaMesUiConfig.Helper
{
    /// <inheritdoc />
    /// <summary>
    /// 重写属性描述类
    /// </summary>
    public class DnaPropertyDescriptor : PropertyDescriptor
    {

        #region 构造函数

        public DnaPropertyDescriptor(Column column, Attribute[] attrs=null) : base(column.Name, attrs)
        {
            _column = column;
            var filedName = column.Name;
            if (filedName.Contains("*"))
            {
                var fields = filedName.Split('*');
                if (fields.Length == 2)
                {
                    _field1 = fields[0];
                    _field2 = fields[1];
                    _fieldType = ConfigFieldType.Reference;
                }
            }
            else if (filedName.Contains("$"))
            {
                string[] fields = filedName.Split('$');
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
        private string _field1;
        private string _field2;
        private ConfigFieldType _fieldType;
        private string _keyfield;
        private int _listIndex;

        #endregion

        #region 公有属性

        public override Type ComponentType => typeof(BaseModel);
        public override bool IsReadOnly => _column.IsReadOnly;

        public override Type PropertyType
        {
            get
            {
                var type=ComponentType.GetProperty(_column.Name)?.PropertyType;
                return type ?? typeof(string);
            }
        }

        #endregion

        #region 私有方法

        #endregion

        #region 公有方法


        public override bool CanResetValue(object component)
        {
            throw new NotImplementedException();
        }

        public override object GetValue(object component)
        {
            throw new NotImplementedException();
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
        Default,//Common,
        Reference,
        List,
        Property,
        Dict
    }
}