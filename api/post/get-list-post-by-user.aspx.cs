using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class api_post_get_list_post_by_user : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.AppendHeader("Access-Control-Allow-Origin", "*");
        var token = Request["token"];
        UserManager UM = new UserManager();
        user u = UM.CheckToken(token);
        if (u != null)
        {

            PostManager PM = new PostManager();
            List<post> listPost = PM.GetListPostByIdUser(u.Id);

            List<post_rs> list_post_rs = new List<post_rs>();
            foreach (var p in listPost)
            {
                var post_rs = new post_rs();
                post_rs.post_id = p.Id;
                post_rs.user_id = Convert.ToInt32(p.UserId);
                post_rs.short_desc = p.ShortDesc;
                post_rs.img = p.Picture;
                post_rs.title = p.Title;
                list_post_rs.Add(post_rs);
            }

            Response.Write(JsonConvert.SerializeObject(list_post_rs));
        }

        else
        {
            Response.Write(1);
        }
    }
}