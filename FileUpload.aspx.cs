using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Configuration;

public partial class FileUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

    }


    protected void ReadCSV(object sender, EventArgs e)
    {
        int iFailVal = 0, iRowImport=0;
        string _connectionString = @"Data Source=.;Initial Catalog=ten;Integrated Security=True";
        var dt = new DataTable();
        string strFilePath = @ConfigurationManager.AppSettings["data"];  //"D:\2020\Home2020\WebAPI\TenTech\TenTech\files\data.csv";
        StreamReader sr = new StreamReader(strFilePath);
        string[] headers = sr.ReadLine().Split(',');
        foreach (string header in headers)
        {
            dt.Columns.Add(header);
        }
        while (!sr.EndOfStream)
        {
            string[] cols = Regex.Split(sr.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
            DataRow dr = dt.NewRow();
            for (int i = 0; i < cols.Length; i++)
            {
                if (i == 3)
                {
                    //Check for eMail Validation

                    try
                    {
                        MailAddress m = new MailAddress(cols[i]);
                        //Email Valid

                    }
                    catch (FormatException ex)
                    {
                        cols[i] = "Error@TenTech.com";
                        iFailVal++;


                    }
                }
                dr[i] = cols[i];
            }
            dt.Rows.Add(dr);
            iRowImport++;
        }

        sr.Close();
        //Used SqlBulkCopy - For More Data
        using (var sqlBulk = new SqlBulkCopy(_connectionString))
        {
            sqlBulk.DestinationTableName = "client";
            sqlBulk.WriteToServer(dt);
        }
        DataTable table = new DataTable();

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {

            // write the sql statement to execute    
            string sql = "SELECT [schemeId],[firstName],[LastName],[email],[mobile] FROM client";
            // instantiate the command object to fire    
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                // get the adapter object and attach the command object to it    
                using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                {
                    // fire Fill method to fetch the data and fill into DataTable    
                    ad.Fill(table);
                }
            }
        }
        // specify the data source for the GridView    
        grdData.DataSource = table;
        // bind the data now    
        grdData.DataBind();

        lblResult.Text ="Total Import - "+ iRowImport.ToString();
        if (iFailVal>0)
        {

           
            lblResultdetails.Text = @"Email Address Validation Failed for - " + iFailVal;
            lblResultdetails.Font.Bold = true;
        }
        

    }
}