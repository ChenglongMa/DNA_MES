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
            var isAvailable = db.DbMaintenance.IsAnyTable("BasicInfo_User");
            if (!isAvailable)
            {
                Console.WriteLine("可以建表");
                db.CodeFirst.InitTables(typeof(User));
            }
            db=new SqlSugarClient(new ConnectionConfig
            {
                ConnectionString = dbInfo.ToString(),
                DbType = dbInfo.DbType,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.SystemTable,
            });
            db.Insertable<User>(new User
            {
                EmpId = 100001.ToString(),
                Name = "admin",
                Password = "admin",

            })
            Console.WriteLine("成功！");
            Console.ReadKey();

        }
    }
}
