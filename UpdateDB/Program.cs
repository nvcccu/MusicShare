using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using CommonUtils;
using CommonUtils.Config;
using DAO;
using DAO.Attributes;

namespace UpdateDB {
    public class SchemaVersion : AbstractEntity<SchemaVersion> {
        public SchemaVersion(string tableName) : base(tableName) {}

        public SchemaVersion() : base("SchemaVersion") {}

        public enum Fields {
            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof(Int32))]
            Id = 0,

            /// <summary>
            /// Текущая основная нумерация скриптов миграции -- чтобы не было номера 2538 и более
            /// </summary>
            [DbType(typeof(int))]
            CurrentMajorVersion = 1,

            /// <summary>
            /// Минорный номер последнего примененного скрипта
            /// </summary>
            [DbType(typeof(int))]
            LastMinorUpdate = 1,
        }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short CurrentMajorVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short LastMinorUpdate { get; set; }
    }

    internal class Program {
        private static void Main(string[] args) {
            if (!args.Any()) {
                Console.WriteLine("Не указан префикс базы данных. Данные не изменены.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            var dbPrefix = args[0];
            ConfigHelper.LoadXml(dbPrefix == "test");
            Connector.ConnectionString = ConfigHelper.FirstTagWithPropertyText("db-connection", "db-name", "master");
            var schemaVersionAll = new SchemaVersion()
                .Select()
                .GetData()
                .ToList();
            var schemaVersion = new SchemaVersion();
            if (schemaVersionAll.Any()) {
                schemaVersion = schemaVersionAll.First();
            } else {
                Console.WriteLine("Нет данных об обновлении базы данных. Данные не изменены.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            var majVersion = schemaVersion.CurrentMajorVersion.ToString(CultureInfo.InvariantCulture);
            var minVersion = schemaVersion.LastMinorUpdate;
            var currentDirectory = Directory.GetCurrentDirectory();
//            var allScripts = Directory.GetFiles(Path.Combine(currentDirectory, @"Scripts\Migration"),
            var allScripts = Directory.GetFiles(@"d:\Projects\MusicShare\DBSQL\Scripts\Migration\",
                majVersion + "." + "*.sql");
            var scriptsToRun =
                allScripts.Where(
                    s => {
                        var firstDot = s.IndexOf(".", StringComparison.Ordinal) + 1;
                        var secondDot = s.IndexOf(".", firstDot, StringComparison.Ordinal);
                        return Convert.ToInt16(s.Substring(firstDot, secondDot - firstDot)) > minVersion;
                    }).ToList();

            int exitCode;
            ProcessStartInfo processInfo;
            Process process;
            string command = "\"c:\\Program Files\\PostgreSQL\\9.3\\bin\\psql.exe\" --dbname=" + dbPrefix + "_master -f d:\\Projects\\MusicShare\\DBSQL\\Scripts\\Migration\\ \"" + scriptsToRun.First() + "\" postgres";
//            string command = "\"c:\\Program Files\\PostgreSQL\\9.3\\bin\\psql.exe\\\" --dbname=" + dbPrefix + "_master -f %~dp0\\Scripts\\Migration\\\"" + scriptsToRun.First() + "\" postgres";
            processInfo = new ProcessStartInfo("cmd.exe", "/c " + "\"" + command + "\"");
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            // *** Read the streams ***
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitCode = process.ExitCode;

            Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            Console.WriteLine("ExitCode: " + exitCode, "ExecuteCommand");
            process.Close();
        }
    }
}