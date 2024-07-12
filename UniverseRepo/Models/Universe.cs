using System.ComponentModel.DataAnnotations;

namespace UniverseRepo.Models
{
    public class Universe
    {

        public int Id { get; set; }
        public string universe_Name { get; set; } 
        public string created_by { get; set;}
        public string description { get; set;}
    }
}
