using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class api_user_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.AppendHeader("Access-Control-Allow-Origin","*");
        string email = Request["email"].ToLower();
        string pass = Request["pass"];


        UserManager UM = new UserManager();
        user u = UM.Login(email, UTIL.Encrypt(pass,true));

        if(u!=null)
        {
            Response.Write(UTIL.Encrypt(email+"@@"+pass,true) + "uid" + u.Id);
        }
        else
        {
            Response.Write("0");
        }

    }
}