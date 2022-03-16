using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class api_user_register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.AppendHeader("Access-Control-Allow-Origin","*");

        try
        {
            string email = Request["email"].ToLower();
            string name = Request["name"];
            string year = Request["year"];
            string city = Request["city"];
            string pass = Request["pass"];
        
            UserManager UM = new UserManager();
            if (UM.CheckUser(email) == null)
            {
                user u = new user();
                u.Email = email;
                u.City = city;
                u.Password = UTIL.Encrypt(pass,true);
                u.BirthYear = Convert.ToInt32(year);
                u.Name = name;
                u.Status = 1;
                u.CreatedDate = DateTime.UtcNow;
                u.Token = UTIL.Encrypt( email + "@@" + pass, true);


                UM.AddUser(u);
                Response.Write(UTIL.Encrypt(email+"@@"+pass,true) );
            }
            else
            {
                Response.Write(2);
            }
        }
        catch
        {
            Response.Write(0);
        }

    }
}