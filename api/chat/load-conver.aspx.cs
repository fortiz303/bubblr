using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class api_chat_load_conver : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string token = Request["token"];
        int conver_id = Convert.ToInt32(Request["conver_id"]);


        UserManager UM = new UserManager();
        user u = UM.CheckToken(token);
        if (u != null)
        {
            ChatManager CM = new ChatManager();
            conversation conver = CM.GetConverByPostIdAndUserId(post_id, u.Id);
            if (conver == null)
            {
                conversation new_conver = new conversation();
                new_conver.Created_UserId = u.Id;
                new_conver.PostId = post_id;
                new_conver.CreatedDate = DateTime.UtcNow;
                new_conver.Status = 1;
                new_conver.LastUpdate = DateTime.UtcNow;
                CM.CreateConversation(new_conver);

                Response.Write(1);
            }
            else
            {
                // load List Mess
                List <mess> list_mess = conver.messes.ToList();
                List<mess_rs> list_mess_rs = new List<mess_rs>();

                for(int i = 0; i < list_mess.Count;i++)
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
        else
        {
            Response.Write(0);
        }
    }
}