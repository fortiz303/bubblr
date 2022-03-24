using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class api_chat_load_conversations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string token = Request["token"];

        UserManager UM = new UserManager();
        user u = UM.CheckToken(token);

        if(u!=null)
        {
            ChatManager CM = new ChatManager();

            // get list conversation by userid
            List<conversation> list_conver = CM.GetConverRelated(u.Id).OrderByDescending(t=>t.LastUpdate).ToList();

            

            List<conver_rs> list_conver_rs = new List<conver_rs>();
            for(int i = 0; i < list_conver.Count;i++)
            {
                if (list_conver[i].messes.Count > 0)
                {
                    conver_rs cr = new conver_rs();
                    cr.create_id = Convert.ToInt32(list_conver[i].Created_UserId);
                    cr.post_id = Convert.ToInt32(list_conver[i].PostId);
                    cr.post_title = list_conver[i].post.Title;
                    mess last_chat = list_conver[i].messes.OrderByDescending(t => t.SentDate).FirstOrDefault();
                    cr.last_user_id = Convert.ToInt32(last_chat.FromId);
                    cr.last_user_name = last_chat.user.Name;
                    cr.last_user_mess = last_chat.Mess1;
                    cr.conver_id = list_conver[i].Id;

                    if(last_chat.Mess1.Length>40)
                    {
                        cr.last_user_mess = last_chat.Mess1.Substring(0,40) + " ...";
                    }

                    cr.create_user_name = last_chat.conversation.user.Name;
                    cr.create_avatar = "user/pic-0.jpg";
                    if (last_chat.conversation.post.Picture !=null)
                    {
                        cr.create_avatar = "post/"+last_chat.conversation.post.Picture;
                    }

                    list_conver_rs.Add(cr);
                }

            }

            Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(list_conver_rs));
            

        }
    }
}