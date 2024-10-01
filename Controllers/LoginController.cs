using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using SQL_MVC.Models;

public class LoginController : Controller{
    public LoginController(){

    }

    public IActionResult Sign(){
        SqlLINQ();
        return View(new UsersViewModel());
    }

    [HttpPost]
    public IActionResult Sign(UsersViewModel model){
        SqlLINQ();
        for (int i = 0; i < users.Count(); i++)
        if(model.UserName == users[i].UserName && model.Password == users[i].Password){
            return View("../Home/Index", users);
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
                UserName = dr["UserName"].ToString(),
                Password = dr["Password"].ToString()
            });
        }
        
    }
}