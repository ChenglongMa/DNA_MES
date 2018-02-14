using System;
using DnaLib;
using DnaMesDal.Model;
using DnaMesModel.Link.BasicInfo;
using DnaMesModel.Model.BasicInfo;
using SqlSugar;

namespace DnaMesTest
{

    class Program
    {
        static void Main(string[] args)
        {

            //Console.ReadKey();

            BuildUserTable("Link_BasicInfo_UserDomain", typeof(UserDomain));

            var u = new User
            {
                EmpId = "100001",
                Name = "admin",
                Password = "admin",
            };
            var d = new Domain
            {
                Description = "临时权限"
            };

            var link = new UserDomain(u, d);
            GetDb().GetSimpleClient().Insert(link);


            Console.ReadKey();

            //Console.WriteLine(u.IsExist());
            //u.Insert();
            //Console.WriteLine(u.ObjId + ";" + u.Name + ";" + u.Password);
            //Console.WriteLine(u.IsExist());
            ////Console.WriteLine(u.ObjId + ";" + u.Name + ";" + u.Password);
            ////Console.WriteLine("成功");
            //Console.ReadKey();
        }
        private static void BuildUserTable(string tableName,Type classType)
        {

            {
                var hasTable = GetDb().DbMaintenance.IsAnyTable(tableName);
                if (hasTable) return;
                Console.WriteLine(tableName+":可以建表，要继续吗？（y/n）");
                if (Console.ReadLine()?.ToLower() == "y")
                {
                    GetDb().CodeFirst.InitTables(classType);
                }
            }
        }

        private static SqlSugarClient GetDb()
        {
            var dbInfo = DbConfigLib.GetDbInfo();
            return new SqlSugarClient(new ConnectionConfig
            {
                ConnectionString = dbInfo.ToString(),
                DbType = dbInfo.DbType,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute,
            });
        }
    }
}