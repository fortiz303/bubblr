using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class app_resetpass : System.Web.UI.Page
{
    public user u;
    protected void Page_Load(object sender, EventArgs e)
    {
        string code = Request["code"];

        UserManager UM = new UserManager();

        u = UM.CheckToken(code);
        if(u==null)
        {
            Response.Redirect("/");
        }
        else
        {

        }
        
    }
}