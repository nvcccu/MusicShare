using System;
using Npgsql;

namespace DAO {
    public class DbAdapter {
        /// <summary>
        /// Connection string
        /// </summary>
        public readonly NpgsqlConnection Connection = new NpgsqlConnection(Connector.ConnectionString);

        /// <summary>
        /// Обращалка к базе
        /// </summary>
        public NpgsqlCommand Command;

        /// <summary>
        /// Читалка из базы
        /// </summary>
        public NpgsqlDataReader DataReader;

        /// <summary>
        /// Открытие коннекшена к базе
        /// </summary>
        public void OpenConnection() {
            try {
                Connection.Open();
            } catch (Exception ex) {
                Console.WriteLine("Error of connection opening\n" + ex);
                return;
            }
            Console.WriteLine("Connection opened");
        }

        /// <summary>
        /// Закрытие коннекшена к базе
        /// </summary>
        public void CloseConnection() {
            try {
                Connection.Close();
            } catch (Exception ex) {
                Console.WriteLine("Error of connection closing\n" + ex);
                return;
            }
            Console.WriteLine("Connection closed");
        }
    }
}
