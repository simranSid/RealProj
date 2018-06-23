using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;

namespace realProject.Models
{
	public class Login
	{
		public String Username
		{ get; set; }
		public string password
		{ get; set; }
		public bool Validate(string user, string pass)
		{
			SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString);
			
			conn.Open();
		SqlCommand cmd= new SqlCommand("Select count(*) from LoginDetails1 where username="+"'"+user+"'"+"and " +"password="+"'"+pass+"'", conn);
			SqlDataReader dr = cmd.ExecuteReader();
			

			if (dr.HasRows)
		 {
				return true;
			}
			return false;

		}
		public bool Register(string username, string password)
		{
			SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString);
			conn.Open();
			SqlCommand cmd = new SqlCommand("Insert into LoginDetails1(Username,Password) Values('"+username+"','"+password+"')", conn);
			int retValue =cmd.ExecuteNonQuery();
			if (retValue > 0)
			{
				return true;
			}
			return false;
		}
	
	}
}