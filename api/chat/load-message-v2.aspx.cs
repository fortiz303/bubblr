using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class api_chat_load_message_v2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int post_id = Convert.ToInt32(Request["post_id"]);
        int conver_id = Convert.ToInt32(Request["conver_id"]);
        string token = Request["token"];


        UserManager UM = new UserManager();
        var u = UM.CheckToken(token);
        if(u!=null)
        {
            // check conver_id
            ChatManager CM = new ChatManager();
            List<mess> list_mess =  CM.GetConversation(conver_id);

            List<mess_rs> list_mess_rs = new List<mess_rs>();

            for (int i = 0; i < list_mess.Count; i++)
            {
                mess_rs ms = new mess_rs();
                ms.from_id = Convert.ToInt32(list_mess[i].FromId);
                ms.mess = list_mess[i].Mess1;
                ms.from_name = list_mess[i].user.Name;
                ms.timespan = list_mess[i].SentDate.ToString();
                if (list_mess[i].user.Avatar != null)
                    ms.avatar = list_mess[i].user.Avatar;
                else
                    ms.avatar = "user/pic-0.jpg";
                list_mess_rs.Add(ms);
            }



            Response.Write(JsonConvert.SerializeObject(list_mess_rs));


        }


    }
}