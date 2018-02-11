using System;
using DnaLib;
using DnaLib.Global;
using DnaMesModel.BasicInfo;
using SqlSugar;

namespace DnaMesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbInfo = DbConfigLib.GetDbInfo(DbInfoName.MainDb);
            Console.WriteLine(dbInfo);
            var db = new SqlSugarClient(new ConnectionConfig
            {
                ConnectionString = dbInfo.ToString(),
                DbType = dbInfo.DbType,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute,
            });
            db.CodeFirst.InitTables(typeof(Person));
            Console.WriteLine("成功！");
            Console.ReadKey();

        }
    }
}
