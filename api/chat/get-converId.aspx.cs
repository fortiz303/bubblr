using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class api_chat_get_converId : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int post_id = Convert.ToInt32(Request["post_id"]);
        string token = Request["token"];

        UserManager UM = new UserManager();

        var u = UM.CheckToken(token);

        if (u != null)
        {
            ChatManager CM = new ChatManager();
            Response.Write(CM.GetByPostId(post_id, u.Id).Id);
        }
        else
        {
            Response.Write(-1);
        }
        
    }
}