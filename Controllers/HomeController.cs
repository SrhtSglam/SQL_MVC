using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SQL_MVC.Models;

namespace SQL_MVC.Controllers;

public class HomeController : Controller
{
    public HomeController(){
        
    }

    public List<Persons> personsList = new List<Persons>();

    public IActionResult Index()
    {
        return View();
    }

    bool sortBy;

    public IActionResult DataTable()
    {
        SqlGetMethod(sortBy);
        return View("DataTable", personsList);
    }

    [HttpPost]
    public IActionResult Sort(){
        sortBy = false;
        SqlGetMethod(sortBy);
        return View("DataTable", personsList);
    }

    [HttpPost]
    public IActionResult NoSort(){
        sortBy = true;
        SqlGetMethod(sortBy);
        return View("DataTable", personsList);
    }

    string filePath = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=AdventureWorks2019;User Id=sqlsa;Password=Abc123+";

    public void SqlGetMethod(bool cmdTF){
        SqlConnection connect = new SqlConnection(filePath);
        connect.Open();
        string query = "SELECT P.[BusinessEntityID], P.[FirstName], P.[LastName], E.[EmailAddress] FROM Person.Person P " + "LEFT JOIN Person.EmailAddress E ON P.BusinessEntityID = E.BusinessEntityID ";
        SqlCommand cmd = new SqlCommand(query, connect);
        if (cmdTF == true){
            cmd.CommandText = query;
        }
        else if(cmdTF == false){
            cmd.CommandText = query + "Order By [BusinessEntityID]";
        }
        else{
            Console.WriteLine("Error Code");
        }
        SqlDataReader dr = cmd.ExecuteReader();
        personsList.Clear();
        while(dr.Read()){
            personsList.Add(new Persons(){
                Id = Convert.ToInt32(dr["BusinessEntityID"]),
                Name = dr["FirstName"].ToString(),
                Surname = dr["LastName"].ToString(),
                Email = dr["EmailAddress"].ToString()
            });
        }
        connect.Close();
    }

    public void SqlGetMethod02(){
        SqlConnection connect = new SqlConnection(filePath);
        connect.Open();
        SqlCommand cmd = new SqlCommand("SELECT [BusinessEntityID], [FirstName], [LastName] FROM Person.Person", connect);
        SqlDataReader dr = cmd.ExecuteReader();
        while(dr.Read()){
            personsList.Add(new Persons(){
                Id = Convert.ToInt32(dr["BusinessEntityID"]),
                Name = dr["FirstName"].ToString(),
                Surname = dr["LastName"].ToString()
            });
        }
        connect.Close();
    }
}
