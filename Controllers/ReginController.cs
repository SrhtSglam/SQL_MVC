using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using SQL_MVC.Models;

public class ReginController : Controller{
    public ReginController(){

    }

    public IActionResult Regis(){

        return View();
    }

    [HttpPost]
    public IActionResult Regis(UsersViewModel model){
        SqlLINQ();
        for (int i = 0; i < users.Count(); i++){
            if(model.UserName != users[i].UserName && model.Password != users[i].Password){
                SqlConnection connect = new SqlConnection(filePath);
                connect.Open();
                string query = "SELECT * FROM dbo.PersonLogin PL";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.CommandText = "INSERT INTO dbo.PersonLogin (UserName, Password) VALUES ('" + model.UserName + "', '" + model.Password + "')";
                cmd.ExecuteNonQuery();
                connect.Close();
                return View("../Home/Index", users);
            }
        }
        return View();
    }


    public List<Users> users = new List<Users>();

    string filePath = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=AdventureWorks2019;User Id=sqlsa;Password=Abc123+";


    private void SqlLINQ(){
        SqlConnection connect = new SqlConnection(filePath);
        connect.Open();
        string query = "SELECT * FROM dbo.PersonLogin PL";
        SqlCommand cmd = new SqlCommand(query, connect);
        SqlDataReader dr = cmd.ExecuteReader();
        users.Clear();
        while(dr.Read()){
            users.Add(new Users(){
                UserName = dr["UserName"].ToString()!,
                Password = dr["Password"].ToString()!
            });
        }
        
    }
}