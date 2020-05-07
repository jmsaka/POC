
using Dapper;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace ConsoleTesteConexaoMySql
{
    public class Program
    {
        static void Main(string[] args)
        {
            var service = new DeptService();
            var result = service.GetDept();
            foreach (var item in result)
            {
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            Console.ReadKey();
        }
    }

    public class Dept
    {
        /// <summary>
        /// DpetNo
        /// </summary>
        public int DeptNo { get; set; }
        /// <summary>
        /// DName
        /// </summary>
        public string DName { get; set; }
        /// <summary>
        /// Location
        /// </summary>
        public string Location { get; set; }

    }


    public class DeptService
    {
        private readonly MySqlConnection _conn;

        private string _connectionString = "Server=0.0.0.0;Database=databasename;Uid=root;Pwd=dbpassword;";
        public DeptService()
        {
            _conn = new MySqlConnection(_connectionString);
        }
        public IEnumerable<Dept> GetDept()
        {
            var sql = "SELECT DeptNo,DName,Location FROM imin.Dept";
            var result = this._conn.Query<Dept>(sql).ToList();
            return result;
        }

        public Dept GetDeptByDeptNo(int deptNo)
        {
            var sql = "SELECT DeptNo,DName,Location FROM imin.Dept WHERE DeptNo = @DeptNo";
            var result = this._conn.Query<Dept>(sql, new { DeptNo = deptNo }).FirstOrDefault();
            return result;
        }
    }
}
