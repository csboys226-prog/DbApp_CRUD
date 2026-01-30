using System.ComponentModel.DataAnnotations;

namespace DbApp_CRUD.Models
{
    public class Employee
    {
        public int Id { get; set; } // Primary Key
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string Designation { get; set; } = string.Empty;
    }
}