using System;
using DAO.Enums;

namespace DAO
{
    static class Sandbox
    {
        static void Main()
        {
//
//            var type = typeof(FunkyAttributesEnum);
//            var memInfo = type.GetMember(FunkyAttributesEnum.NameWithoutSpaces1.ToString());
//            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute),
//                false);
//            var description = ((DescriptionAttribute)attributes[0]).Description;
//
//            var type = typeof (TableEntity.Fields);
//            var memInfo = type.GetMember(TableEntity.Fields.Id.ToString());
//            var attributes = memInfo[0].GetCustomAttributes(typeof (DBType),
//                                                            false);
//            var description = ((DBType) attributes[0]).Type;
//            Console.WriteLine(description);
//
//
////            
//            
//            System.Reflection.MemberInfo info = typeof(TableEntity.Fields);
//            var memInfo = info.GetMember(FunkyAttributesEnum.NameWithoutSpaces1.ToString());
//
//
//
//            object[] attributes = info.GetCustomAttributes(true);
//            for (int i = 0; i < attributes.Length; i++)
//            {
//                System.Console.WriteLine(attributes[i]);
//            }
        //    Console.ReadKey();
        //    return;

//            NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;User=postgres;Password=postgres;Database=postgres;");
//            con.Open();
////            Server=127.0.0.1;Port=5432;Database=myDataBase;User Id=myUsername;Password=myPassword;
//
////            User ID=root;Password=myPassword;Host=localhost;Port=5432;Database=myDataBase;
////Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0;
//
//            NpgsqlCommand command = new NpgsqlCommand("select * from test", con);
//            try {
//                NpgsqlDataReader dr = command.ExecuteReader();
//
//                Console.WriteLine();
//                while (dr.Read()) {
//                    var a = dr.GetValue(0).ToString();
//                    var b = dr.GetValues(new object[] {new int() , new string('l', 1)});
//                    var c = dr.GetValue(0).ToString();
//                }
//        } catch (Exception ex) {
//                Console.WriteLine(ex);
//            }
//            con.Close();   TableEntity.Fields.Id, PredicateCondition.Equal, 1
            var test = new TableEntity("test");
            var results = test
                .Select()
                .Where(new[] {
                    new FilterWhere(TableEntity.Fields.Id, PredicateCondition.Equal, 1),
                    new FilterWhere(TableEntity.Fields.Id, PredicateCondition.Equal, 1) })
                .GetData();
//            foreach (var result in results) {
//                Console.WriteLine(result.Id + " " + result.Data);
//            }
            test.Id = 55765;
            test.Data = "saved";
            test.Save();
            results = test.Select().Where(TableEntity.Fields.Id, PredicateCondition.Equal, 55).GetData();
            foreach (var result in results)
            {
                Console.WriteLine(result.Id + " " + result.Data);
            }
            Console.ReadKey();
        }
    }
}
