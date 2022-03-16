using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class proc_update_pass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserManager UM = new UserManager();
        List<user> list = UM.GetAllUsers();

        for(int i = 0; i < list.Count;i++)
        {
            string email = list[i].Email;
            string pass = UTIL.Decrypt(list[i].Password,true);
            string token = email + "@@" + pass;
            token = UTIL.Encrypt(token, true);

            list[i].Token = token;
            UM.Save();

        }

    }
}