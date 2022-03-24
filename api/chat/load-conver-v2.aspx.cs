using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class api_chat_load_conver_v2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string token = Request["token"];
        int post_id = Convert.ToInt32(Request["post_id"]);


        UserManager UM = new UserManager();
        var u = UM.CheckToken(token);

        if (u != null)
        {
            ChatManager CM = new ChatManager();
            var c = CM.GetConverByPostIdAndUserId(post_id, u.Id);

            // check if has conversation
            List<mess_rs> list_mess_rs = new List<mess_rs>();
            if (c!=null)
            {
                // load message
                List<mess> list_mess = c.messes.ToList();
               

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


                if(list_mess.Count>0)
                Response.Write(JsonConvert.SerializeObject(list_mess_rs));
                else
                {
                    mess_rs ms_f = new mess_rs();
                    ms_f.timespan = "-1";
                    ms_f.from_id = c.Id;

                    list_mess_rs.Add(ms_f);

                    Response.Write(JsonConvert.SerializeObject(list_mess_rs));

                }
            }
            else
            {
                // Create New Conversation

                conversation new_conver = new conversation();
                new_conver.Created_UserId = u.Id;
                new_conver.PostId = post_id;
                new_conver.CreatedDate = DateTime.UtcNow;
                new_conver.Status = 1;
                new_conver.LastUpdate = DateTime.UtcNow;
                CM.CreateConversation(new_conver);

                mess_rs ms_f = new mess_rs();
                ms_f.timespan = "-1";
                ms_f.from_id = new_conver.Id;

                list_mess_rs.Add(ms_f);

                Response.Write(JsonConvert.SerializeObject(list_mess_rs));
            }    

            // load message

        }
        else
        {
            Response.Write(-1);
        }

    }
}