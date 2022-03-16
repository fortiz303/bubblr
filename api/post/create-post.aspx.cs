using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class api_post_create_post : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Response.AppendHeader("Access-Control-Allow-Origin", "*");
            string title = Request["title"];
            string shortdes = Request["shortdes"];
            string contdes = Request["contdes"];
            var token = Request["token"];
            string location = Request["location"];
          
            UserManager UM = new UserManager();
            user u = UM.CheckToken(token);
            if (u != null)
            {
                PostManager PM = new PostManager();
                post _post = new post();
                _post.Title = title;
                if (shortdes.Length > 80)
                {
                    _post.ShortDesc = contdes.Substring(80) + "...";
                }else
                {
                    _post.ShortDesc = contdes;
                }
                _post.ContDesc = contdes;
                _post.Status = 1;
                _post.CreatedDate = DateTime.UtcNow;
                _post.UserId = u.Id;
                _post.Picture = "pic-0.jpg";
                _post.Location = location;
                string base64 = Request["base64"];
                PM.CreatePost(_post);

                if (!string.IsNullOrEmpty(base64))
                {
                    byte[] imageBytes = Convert.FromBase64String(base64);
                    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                    
                    string fileName = "post_" + _post.Id + ".jpg";
                    image.Save(Path.Combine(Server.MapPath("~/img/post"), fileName));
                    _post.Picture = fileName;
                    PM.Save();
                }

               
                Response.Write(1);

            }
            else
            {
                Response.Write(0);
            }
        }
        catch(Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
}