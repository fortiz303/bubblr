using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PostManager
/// </summary>
public class PostManager
{
	public PostManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}


	DataClassesDataContext db = new DataClassesDataContext();
	
	public List<post> GetTopList()
    {
		return db.posts.Where(t => t.Status == 1).OrderByDescending(t=>t.Id).Take(100).ToList();
    }

	public post GetPostById(int post_id)
    {
		return db.posts.Where(t => t.Id == post_id && t.Status == 1).FirstOrDefault();
    }
    public List<post> GetListPostByIdUser(int userid)
    {
        return db.posts.Where(t => t.UserId == userid && t.Status == 1).OrderByDescending(t => t.Id).ToList();
    }
    public void CreatePost(post p)
    {
        db.posts.InsertOnSubmit(p);
        Save();
    }
    public void Save()
    {
        db.SubmitChanges();
    }
}