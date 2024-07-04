// //string manupulations

// public class MyClass
// {
//     public static void Main(string[] args) // Removed private modifier
//     {
//         string fname = "Thols";
//         Console.WriteLine("My name is" + fname); // Added semicolon

//         string[] pallets = { "B14", "A11", "B12", "A13" };

//         // Console.WriteLine("Sorted...");
//         Array.Sort(pallets);
//         foreach (var pallet in pallets)
//         {
//             // Console.WriteLine($"-- {pallet}");
//             // Console.WriteLine(pallet);
//         }

//          for (int i = 0;i<pallets.Length;i++)
//         {
//             // Console.WriteLine($"-- {pallet}");
//             // Console.WriteLine(i);
//         }
     

//             int[,] numbers = { {1, 4, 2}, {3, 6, 8} };

//             for (int i = 0; i < numbers.GetLength(0); i++) 
//             { 
//             for (int j = 0; j < numbers.GetLength(1); j++) 
//             { 
//                 Console.WriteLine(numbers[i, j]); 
//             } 
//             }
//     }
// }

// using System;
// using System.Text.Json;

// public partial class Form1 : Form
// {
//   public Form1()
//   {
//     InitializeComponent();
//   }

//   private void btnSave_Click(object sender, EventArgs e)
//   {
//     // Get user input from text boxes
//     string name = txtName.Text;
//     string email = txtEmail.Text;
//     string phone = txtPhone.Text;

//     // Create a user object
//     User user = new User(name, email, phone);

//     // Serialize the user object to JSON
//     string jsonData = JsonSerializer.Serialize(user);

//     // Save the JSON data in local storage
//     localStorage.setItem("userData", jsonData);

//     // Display confirmation message
//     MessageBox.Show("Data saved successfully!");
//   }
// }

// public class User
// {
//   public string Name { get; set; }
//   public string Email { get; set; }
//   public string Phone { get; set; }

//   public User(string name, string email, string phone)
//   {
//     Name = name;
//     Email = email;
//     Phone = phone;
//   }
// }


// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;

// [ApiController]
// [Route("[controller]")]
// public class UserController
// {
//   [HttpGet]
//   public IActionResult GetUsers()
//   {
//     // Simulate fetching user data (replace with actual data retrieval logic)
//     List<User> users = new List<User>()
//     {
//       new User { Id = 1, Name = "John Doe" },
//       new User { Id = 2, Name = "Jane Smith" }
//     };

//     return Ok(users); // Return a list of users as JSON
//   }
// }

// public class User
// {
//   public int Id { get; set; }
//   public string Name { get; set; }
// }


using System;
using RestSharp; // For making HTTP requests
using Newtonsoft.Json; // For JSON serialization

public class Program
{
  static void Main(string[] args)
  {
    const string apiKey = "**********"; // Replace with your actual API key
    const string baseUrl = "https://api.openweathermap.org/data/2.5/weather";

    string city = "Johannesburg"; // Replace with the city you want to query

    var client = new RestClient(baseUrl);
    var request = new RestRequest($"?q={city}&appid={apiKey}");

    // Execute the request and get the response
    var response = client.Execute(request);

    if (response.IsSuccessful)
    {
      // Parse the JSON response
      dynamic weatherData = JsonConvert.DeserializeObject(response.Content);

      string cityName = weatherData.name;
      double temperature = weatherData.main.temp - 273.15; // Convert Kelvin to Celsius

      Console.WriteLine($"Weather in {cityName}:");
      Console.WriteLine($"Temperature: {temperature:F2} °C"); // Format temperature with 2 decimal places
    }
    else
    {
      Console.WriteLine($"Error: {response.StatusCode}");
      Console.WriteLine(response.ErrorMessage);
    }
  }
}

