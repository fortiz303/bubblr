using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class api_user_update_pass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string code = Request["code"];
        string pass = Request["pass"];


        UserManager UM = new UserManager();
        user u = UM.CheckToken(code);
        if (u != null)
        {
            u.Password = UTIL.Encrypt(pass, true);
            UM.Save();
            Response.Write(1);
        }
        else
        {
            Response.Write(0);
        }

    }
}