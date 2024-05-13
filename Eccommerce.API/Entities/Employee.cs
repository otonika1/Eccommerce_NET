namespace Eccommerce.API.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("emptb")]
public class Employee
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }
    [Column("first_Name")]
    public string FirstName { get; set; }
    [Column("Last_Name")]
    public string LastName { get; set; }
    [Column("phone_number")]
    public string PhoneNumber { get; set; }
    [Column("addresses")]
    public List<String> Addresses { get; set; }
    
    /*public Employee(string firstName, string lastName, string phoneNumber, List<string> addresses)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Addresses = addresses;
    }*/
}