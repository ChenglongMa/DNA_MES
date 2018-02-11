using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaMesDll;
using DnaMesModel.Global;
using SqlSugar;
using static System.Console;

namespace DnaMesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //num.TryParse(this["DbType"].ToString(), out DbType type)
            var dbInfo = DllDbConfig.GetDbInfo(DbInfoName.MainDb);
            WriteLine(dbInfo);
            //dbInfo.DbType = DbType.SqlServer;
            //dbInfo.DbName = "DnaMesDb";
            //dbInfo.Password = "sasasa";
            //dbInfo.UserId = "sa";
            //dbInfo.DataSource = "127.0.0.1";
            //DllDbConfig.SetDbInfo(dbInfo);
            var db = new SqlSugarClient(new ConnectionConfig
            {
                ConnectionString = dbInfo.ToString(),
                DbType = dbInfo.DbType,
                IsAutoCloseConnection = true
            });
            //var dt = db.Ado.GetDataTable("select * from table");
            ReadKey();

        }
    }
}
