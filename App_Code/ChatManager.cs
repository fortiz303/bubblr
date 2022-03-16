using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ChatManager
/// </summary>
public class ChatManager
{
	public ChatManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}
	DataClassesDataContext db = new DataClassesDataContext();

	public void CreateConversation(conversation conver)
    {
		db.conversations.InsertOnSubmit(conver);
		Save();
    }

	public conversation GetConverByPostIdAndUserId(int post_id, int user_id)
    {
		return db.conversations.Where(t => (t.PostId == post_id && t.Created_UserId == user_id) || ( t.PostId == post_id &&t.post.UserId == user_id )  ).FirstOrDefault();
    }

	public List<conversation> GetConverRelated(int user_id)
    {
		return db.conversations.Where(t => t.post.UserId == user_id || t.Created_UserId == user_id).ToList();
    }

	public void AddMess(mess mess)
    {
		db.messes.InsertOnSubmit(mess);
		Save();
    }

	public List<mess> GetConversation(int conve_id)
    {
		return db.messes.Where(t => t.ConverId == conve_id).ToList();
    }





	public void Save()
    {
		db.SubmitChanges();
    }
}