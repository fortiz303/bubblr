using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class api_post_update_post : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string token = Request["token"];
        int post_id = Convert.ToInt32(Request["post_id"]);

        string title = Request["title"];
        string shortdes = Request["shortdes"];
        string contdes = Request["contdes"];

        PostManager PM = new PostManager();
        post p = PM.GetPostById(post_id);

        UserManager UM = new UserManager();
        user u = UM.CheckToken(token);

        if(u!=null && p.UserId == u.Id)
        {
            // allow update
            p.Title = title;
            p.ShortDesc = shortdes;
            p.ContDesc = contdes;

            string base64 = Request["base64"];
            
            if (!string.IsNullOrEmpty(base64))
            { 
                // update image
            }

            PM.Save();
            Response.Write(1);
        }
        else
        {
            Response.Write(0);
        }
    }
}