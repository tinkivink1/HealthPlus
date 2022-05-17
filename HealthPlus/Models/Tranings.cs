using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthPlus.Models

{
    public class Trainings
    {
       [Key]
        public int Id_training { get; set; }
        public string training_name { get; set; }
        public string exercise_list { get; set; }

        public int  UserId { get; set; }
        public Users? users { get; set; }
    }
}
