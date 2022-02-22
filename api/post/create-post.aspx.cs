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
            var checkEmail = Request["checkEmail"];
            var checkPass = Request["checkPass"];
            var Email = UTIL.Decrypt(checkEmail, true);
            var Pass = UTIL.Decrypt(checkPass, true);
            UserManager UM = new UserManager();
            user u = UM.CheckToken(Email, Pass);
            if (u != null)
            {
                PostManager PM = new PostManager();
                post _post = new post();
                _post.Title = title;
                _post.ShortDesc = shortdes;
                _post.ContDesc = contdes;
                _post.Status = 1;
                _post.CreatedDate = DateTime.Now;
                _post.UserId = u.Id;
                _post.Picture = "";
                string base64 = Request["base64"];
                if (!string.IsNullOrEmpty(base64))
                {
                    byte[] imageBytes = Convert.FromBase64String(base64);
                    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                    PM.CreatePost(_post);
                    string fileName = "post_" + _post.Id + ".jpg";
                    image.Save(Path.Combine(Server.MapPath("~/img"), fileName));
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
        catch
        {
            Response.Write(0);
        }

    }
}