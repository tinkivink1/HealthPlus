using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
namespace HealthPlus.Models

{
    public class Trainings
    {
        public Trainings() { }
        public Trainings(Trainings trainings)
        {
            Id_training = trainings.Id_training;
            training_name = trainings.training_name;
            training_description = trainings.training_description;
            exercise_list = trainings.exercise_list;
            Array.Copy(trainings.image, image, trainings.image.Length);
            users = new List<Users>(trainings.users);
        }
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
