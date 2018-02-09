using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;
using DbType = System.Data.DbType;

namespace DnaMesDll
{
    public class Class1
    {
        public void GetData()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = Config.ConnectionString, //必填
                DbType = DbType.SqlServer, //必填
                IsAutoCloseConnection = true， //默认false
                InitKeyType = InitKeyType.SystemTable
            }); //默认SystemTable


            List<Student> list = db.Queryable<Student>().ToList();//查询所有（使用SqlSugarClient查询所有到LIST）
        }
    }
}
