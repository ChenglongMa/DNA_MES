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
                EmpId = "100002",
                Name = "李宗盛",
                //Password = "admin",
            };
            //u.Insert();
            Console.WriteLine(u.ObjId + ";" + u.Name + ";" + u.Password);
            u=UserBll.GetUserByEmpId(4);
            Console.WriteLine(u.ObjId + ";" + u.Name + ";" + u.Password);
            Console.WriteLine("成功");
            Console.ReadKey();
        }

        private static void BuildUserTable()
        {
            var dbInfo = DbConfigLib.GetDbInfo();
            using (var db = new SqlSugarClient(new ConnectionConfig
            {
                ConnectionString = dbInfo.ToString(),
                DbType = dbInfo.DbType,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute,
            }))
            {
                var isAvailable = db.DbMaintenance.IsAnyTable("BasicInfo_User");
                if (!isAvailable)
                {
                    Console.WriteLine("可以建表，要继续吗？（y/n）");
                    if (Console.ReadLine()?.ToLower() == "y")
                    {
                        db.CodeFirst.InitTables(typeof(User));
                    }
                }
            }
        }
    }
}