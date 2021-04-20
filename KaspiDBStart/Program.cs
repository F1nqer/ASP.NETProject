using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace KaspiDBStart
{
    class Program
    {
        static void Main(string[] args)
        {

            using (Production Production = new Production())
            {
                foreach (Product u in Production.Product)
                {
                    Console.WriteLine($"{u.Name} with number {u.ProductNumber}");
                }
            }
            Console.ReadKey();

            /*string connectionString = ConfigurationManager.ConnectionStrings[""].ConnectionString;
            string SqlExpression = "SELECT IIN, FromDate, Type, Money FROM Client c JOIN [Identity] i ON c.IdentityId = i.id JOIN Contract con ON c.ContractId = con.id JOIN IBAN iban ON con.IBANId = iban.id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand selected = new SqlCommand(SqlExpression, connection);
                SqlDataReader reader = selected.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    // выводим названия столбцов
                    Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));

                    while (reader.Read()) // построчно считываем данные
                    {
                        object IIN = reader.GetValue(0);
                        DateTime date = reader.GetDateTime(1);
                        string type = reader.GetString(2);
                        object money = reader.GetValue(3);

                        Console.WriteLine("{0} \t{1} \t{2} \t{3}", IIN, date, type, money);
                    }
                }
                reader.Close();
            }
            Console.ReadKey();
            Console.WriteLine("Подключение закрыто...");
        }*/
        }
    }
}
