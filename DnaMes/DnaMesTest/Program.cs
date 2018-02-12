using System;
using System.Collections.Generic;
using DnaLib;
using DnaLib.Global;
using DnaMesBll.BasicInfo;
using DnaMesModel.Model.BasicInfo;
using SqlSugar;

namespace DnaMesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var u = new User
            {
                EmpId = "100001",
                Name = "admin",
                Password = "admin",
            };
            Console.WriteLine(SysInfo.InterIp);
            var dbInfo = DbConfigLib.GetDbInfo();
            Console.WriteLine(dbInfo);
            Console.WriteLine(u.Password);
            Console.ReadKey();

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
                Console.WriteLine("可以建表，要继续吗？（y/n）");
                if (Console.ReadLine()?.ToLower()=="y")
                {
                    db.CodeFirst.InitTables(typeof(User));
                }
            }


            u.Insert();
            Console.WriteLine("成功");
            Console.ReadKey();

        }
    }
}
