using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
namespace HealthPlus.Models

{
    public class Trainings
    {
       [Key]
        public int Id_training { get; set; }
        public string training_name { get; set; }
        public string training_description { get; set; }
        public string? exercise_list { get; set; }
        public byte[]? image { get; set; }
        public int? UserId { get; set; }
        public List<Users>? users { get; set; } = new();    

    }
}
