using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

public class csvController1 : ApiController
{
    // GET api/<controller>
    public IEnumerable<string> Get()
    {


        string _connectionString = @"Data Source=.;Initial Catalog=ten;Integrated Security=True";
        var dt = new DataTable();
        string strFilePath = @"D:\2020\Home2020\WebAPI\TenTech\TenTech\files\data.csv";
        StreamReader sr = new StreamReader(strFilePath);
        string[] headers = sr.ReadLine().Split(',');
        foreach (string header in headers)
        {
            dt.Columns.Add(header);
        }
        while (!sr.EndOfStream)
        {
            string[] rows = Regex.Split(sr.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
            DataRow dr = dt.NewRow();
            for (int i = 0; i < rows.Length; i++)
            {
                dr[i] = rows[i];
            }
            dt.Rows.Add(dr);
        }

        sr.Close();
        //Used SqlBulkCopy - For More Data
        using (var sqlBulk = new SqlBulkCopy(_connectionString))
        {
            sqlBulk.DestinationTableName = "client";
            sqlBulk.WriteToServer(dt);
        }
        DataTable table = new DataTable();

        return new string[] { "value1", "value2" };
    }

    // GET api/<controller>/5
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<controller>
    public void Post([FromBody]string value)
    {
        string _connectionString = @"Data Source=.;Initial Catalog=ten;Integrated Security=True";
        var dt = new DataTable();
        string strFilePath = @"D:\2020\Home2020\WebAPI\TenTech\TenTech\files\data.csv";
        StreamReader sr = new StreamReader(strFilePath);
        string[] headers = sr.ReadLine().Split(',');
        foreach (string header in headers)
        {
            dt.Columns.Add(header);
        }
        while (!sr.EndOfStream)
        {
            string[] rows = Regex.Split(sr.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
            DataRow dr = dt.NewRow();
            for (int i = 0; i < rows.Length; i++)
            {
                dr[i] = rows[i];
            }
            dt.Rows.Add(dr);
        }

        sr.Close();
        //Used SqlBulkCopy - For More Data
        using (var sqlBulk = new SqlBulkCopy(_connectionString))
        {
            sqlBulk.DestinationTableName = "client";
            sqlBulk.WriteToServer(dt);
        }
        DataTable table = new DataTable();


    }

    // PUT api/<controller>/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/<controller>/5
    public void Delete(int id)
    {
    }
}
