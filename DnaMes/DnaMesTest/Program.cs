using System;
using System.Reflection;
using DnaLib;
using DnaMesDal.Model;
using DnaMesDal.Model.BasicInfo;
using DnaMesModel.BasicInfo;
using SqlSugar;

namespace DnaMesTest
{

    class Program
    {
        static void Main(string[] args)
        {
            //BuildUserTable("Link_BasicInfo_UserDomain", typeof(UserDomain));

            var u = new User
            {
                ObjId = 55534,
                EmpId = "100001",
                Name = "admin",
                Password = "admin",
            };
            var d = new Domain
            {
                Description = "临时权限"
            };
            var udal=new UserDal();
            var link = udal.GetLinkWith(u, d);
            Console.WriteLine(link.RoleAId+";"+link.RoleBId);
            //GetDb().GetSimpleClient().Insert(link);


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