﻿using System;
using DnaLib;
using DnaMesDal.BasicInfo;
using DnaMesModel.Model.BasicInfo;
using SqlSugar;

namespace DnaMesTest
{

    class Program
    {
        static void Main(string[] args)
        {

            //Console.ReadKey();

            //BuildUserTable();
            var u = new User
            {
                EmpId = "100001",
                Name = "admin",
                Password = "admin",
            };

            //Console.WriteLine(u.IsExist());
            //u.Insert();
            //Console.WriteLine(u.ObjId + ";" + u.Name + ";" + u.Password);
            //Console.WriteLine(u.IsExist());
            ////Console.WriteLine(u.ObjId + ";" + u.Name + ";" + u.Password);
            ////Console.WriteLine("成功");
            //Console.ReadKey();
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
                if (isAvailable) return;
                Console.WriteLine("可以建表，要继续吗？（y/n）");
                if (Console.ReadLine()?.ToLower() == "y")
                {
                    db.CodeFirst.InitTables(typeof(User));
                }
            }
        }
    }
}