using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class cart : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter ad;
    protected void Page_Load(object sender, EventArgs e)
    {
        string path = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(path);
        con.Open();
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(connectionString);
        con.Open();
        // Loop through each row in the GridView
        foreach (GridViewRow row in GridView1.Rows)
        {
            // Extract data from GridView cells
            string cake= row.Cells[0].Text; // Assuming the product name is in the first cell
            string price = row.Cells[1].Text; // Assuming the price is in the second cell
            string quantity = row.Cells[2].Text; // Assuming the quantity is in a TextBox control in the third cell
            string total_amount = row.Cells[3].Text;

            string user_email = Session["from"].ToString();
            //string address = "select address from register where email=@user_email";
            string status = "COD";
            // Insert data into the Orders table with status "COD"
            string query = "INSERT INTO Orders (cake, Price, user_email,Quantity, total_amount,status) VALUES (@cake, @Price,@user_email ,@Quantity, @total_amount,@status)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@cake", cake);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@user_email", user_email);
                    //command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@total_amount", total_amount);
                    command.Parameters.AddWithValue("@status", status);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }
        GridView1.DataSource = null; // Clear the data source
        GridView1.DataBind();
        Response.Redirect("checkout.aspx");

    //    foreach (GridViewRow row in GridView1.Rows)
    //    {
    //        CheckBox status = (row.Cells[5].FindControl("Checkbox1") as CheckBox);
    //        int id = Convert.ToInt32(row.Cells[1].Text);
    //        if (status.Checked)
    //        {
    //            updaterow(id, "True");
    //        }
    //        else
    //        {
    //            updaterow(id, "false");
    //        }
    //    }
        //Response.Redirect("checkout.aspx");
    }



    protected void SqlDataSource3_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connect"].ToString();
        con = new SqlConnection(connectionString);
        con.Open();
        // Loop through each row in the GridView
        foreach (GridViewRow row in GridView1.Rows)
        {
            // Extract data from GridView cells
            string cake= row.Cells[0].Text; // Assuming the product name is in the first cell
            string price = row.Cells[1].Text; // Assuming the price is in the second cell
            string quantity = row.Cells[2].Text; // Assuming the quantity is in a TextBox control in the third cell
            string total_amount = row.Cells[3].Text;

            string user_email = Session["from"].ToString();
            //string address = "select address from register where email=@user_email";
            string status = "Online";
            // Insert data into the Orders table with status "COD"
            string query = "INSERT INTO Orders (cake, Price, user_email,Quantity, total_amount,status) VALUES (@cake, @Price,@user_email ,@Quantity, @total_amount,@status)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@cake", cake);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@user_email", user_email);
                    //command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@total_amount", total_amount);
                    command.Parameters.AddWithValue("@status", status);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        GridView1.DataSource = null; // Clear the data source
        GridView1.DataBind();
        Response.Redirect("checkout.aspx");
    }
    
 
}