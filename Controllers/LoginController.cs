using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

public class LoginController : Controller{
    public LoginController(){

    }

    public IActionResult Sign(){
        SqlLINQ();
        return View();
    }

    public IActionResult SignIn(string usr, string psw){
        for(int i=0; i < users.Count(); i++){
            if(usr == users[i].UserName){
                return View("DataList", users);
            }
            
        }
    }

    public List<Users> users = new List<Users>();

    string filePath = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=AdventureWorks2019;User Id=sqlsa;Password=Abc123+";


    private void SqlLINQ(){
        SqlConnection connect = new SqlConnection(filePath);
        connect.Open();
        string query = "SELECT * FROM dbo.PersonLogin PL";
        SqlCommand cmd = new SqlCommand(query, connect);
        SqlDataReader dr = cmd.ExecuteReader();
        while(dr.Read()){
            users.Add(new Users(){
                UserName = dr["UserName"].ToString(),
                Password = dr["Password"].ToString()
            });
        }
        
    }
}