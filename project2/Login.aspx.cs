﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _0225
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Iscorrect_Click(object sender, EventArgs e)
        {
         
              SqlConnection Conn = new SqlConnection("Data Source=LAPTOP-MVSLPF8J\\SQLEXPRESS;Initial Catalog=test;user id=sa;password=26428548");
            Conn.Open();
            SqlDataReader dr = null;
            SqlCommand cmd = new SqlCommand("Select * From dbo.Employee Where [account]=@acc  and [password]=@pwd ", Conn);
            cmd.Parameters.AddWithValue("@acc", account.Text);
            cmd.Parameters.AddWithValue("@pwd", password.Text);
            dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('帳號或密碼錯誤!');window.location='Login.aspx'</script>");
                    account.Text = "";
                    password.Text = "";
                
            }
            else
            {
                Session["Login"] = "OK";
                Session["Name"] = dr["name"].ToString();
                Session["Authority"] = dr["authority"].ToString();
                Session["Position"] = dr["position"].ToString();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('登入成功!');window.location='Employee.aspx'</script>");
            }
        }
    }
}