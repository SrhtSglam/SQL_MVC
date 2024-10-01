// using System.Data.SqlClient;
// using SQL_MVC.Controllers;

// public class SqlOperations : HomeController{
//     public SqlOperations()
//     {
//         SqlGetMethod();
//     }

//     string filePath = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=AdventureWorks2019;User Id=sqlsa;Password=Abc123+";

//     public void SqlGetMethod(){
//         SqlConnection connect = new SqlConnection(filePath);
//         connect.Open();
//         SqlCommand cmd = new SqlCommand("SELECT [BusinessEntityID], [FirstName], [LastName] FROM Person.Person", connect);
//         SqlDataReader dr = cmd.ExecuteReader();
//         personsList.Add(new Persons(){
//             Id = Convert.ToInt32(dr["BusinessEntityID"]),
//             Name = dr["FirstName"].ToString(),
//             Surname = dr["LastName"].ToString()
//         });
//         connect.Close();
//     }
// }