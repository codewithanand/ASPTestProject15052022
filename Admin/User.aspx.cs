using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _15052022.Admin
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.PreRender += new EventHandler(GridView1_PreRender);
            bind();
        }

        private void bind()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
            con.Open();
            string selectQry = "select * from [userinfo]";
            SqlCommand selectCmd = new SqlCommand(selectQry, con);
            SqlDataAdapter selectAdapter = new SqlDataAdapter(selectCmd);
            DataSet ds = new DataSet();
            selectAdapter.Fill(ds);
            con.Close();
            GridView1.DataSource= ds.Tables[0];
            GridView1.DataBind();
        }

        private void GridView1_PreRender(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count > 0)
            {
                GridView1.UseAccessibleHeader = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}