using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class api_post_get_top_post : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PostManager PM = new PostManager();
        List<post> list_post = PM.GetTopList();

        List<post_rs> list_post_rs = new List<post_rs>();
        foreach( var p in list_post)
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


}