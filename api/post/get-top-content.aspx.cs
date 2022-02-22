using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class api_post_get_top_content : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PostManager PM = new PostManager();
        int post_id = Convert.ToInt32(Request["post_id"]);
        post p = PM.GetPostById(post_id);
        var post_rs = new post_rs();
        post_rs.post_id = p.Id;
        post_rs.title = p.Title;
        post_rs.short_desc = p.ShortDesc;
        post_rs.post_content = p.ContDesc;
        post_rs.img = p.Picture;
        post_rs.user_id = Convert.ToInt32(p.UserId);
        post_rs.user_name = p.user.Name;

        List<post_rs> list_rs = new List<post_rs>();
        list_rs.Add(post_rs);

        Response.Write(JsonConvert.SerializeObject(list_rs));


    }
}