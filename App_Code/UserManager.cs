using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserManager
/// </summary>
public class UserManager
{
	public UserManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

	DataClassesDataContext db = new DataClassesDataContext();

	public void AddUser(user u)
    {
		db.users.InsertOnSubmit(u);
		Save();
    }

	public user CheckUser(string email)
    {
		return db.users.Where(t => t.Email == email).FirstOrDefault();
    }
	
	public user Login(string email, string password)
    {
		return db.users.Where(u => u.Email == email && u.Password == password && u.Status == 1).FirstOrDefault();
    }

	public void Save()
    {
		db.SubmitChanges();
    }
}