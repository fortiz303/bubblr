using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class api_chat_reply : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string mess = Request["mess"];
        string token = Request["token"];
        int conver_id = Convert.ToInt32(Request["conver_id"]);


        UserManager UM = new UserManager();
        user u = UM.CheckToken(token);

        if (u != null)
        {
            ChatManager CM = new ChatManager();

            mess m = new mess();
            m.SentDate = DateTime.UtcNow;
            m.Status = 1;
            m.Mess1 = mess;
            m.FromId = u.Id;
            m.ConverId = conver_id;

            CM.AddMess(m);
            m.conversation.LastUpdate = DateTime.UtcNow;
            CM.Save();
        }
    }
}