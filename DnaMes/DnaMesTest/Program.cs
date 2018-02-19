using System;
using System.Reflection;
using DnaLib;
using DnaMesDal.Link;
using DnaMesModel.BasicInfo;
using SqlSugar;

namespace DnaMesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildUserTable("L_UserDomain", typeof(UserDomain));
            BuildUserTable("BasicInfo_Domain", typeof(Domain));

            var u = new User
            {
                ObjId = 1,
                EmpId = "100001",
                Name = "admin",
                Password = "admin",
            };
            #region 插入新数据

            //for (int i = 0; i < 5; i++)
            //{
            //    var d = new Domain
            //    {
            //        FunctionCode = 10001+i,
            //        Name = "临时权限"+i,
            //        Description = "临时权限"+i,
            //    };
            //    var dal = new BaseDal<Domain>();
            //    if (dal.Insert(d))
            //    {
            //        var link = new UserDomain(u, d);
            //        var dal2 = new BaseDal<UserDomain>();
            //        dal2.Insert(link);
            //    }

            //}

            #endregion

            Console.ReadKey();

            //Console.WriteLine(u.IsExist());
            //u.Insert();
            //Console.WriteLine(u.ObjId + ";" + u.Name + ";" + u.Password);
            //Console.WriteLine(u.IsExist());
            ////Console.WriteLine(u.ObjId + ";" + u.Name + ";" + u.Password);
            ////Console.WriteLine("成功");
            //Console.ReadKey();
        }

        private static void BuildUserTable(string tableName, Type classType)
        {
            {
                var hasTable = GetDb().DbMaintenance.IsAnyTable(tableName);
                if (hasTable) return;
                Console.WriteLine(tableName + ":可以建表，要继续吗？（y/n）");
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