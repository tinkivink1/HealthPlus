using System.ComponentModel.DataAnnotations.Schema;

namespace HealthPlus.Models
{
    public class Users
    {
        public Users() { }
        public Users(Users users)
        {
            this.Id = users.Id;
            this.client_name = users.client_name;
            this.client_surname = users.client_surname;
            this.client_password = users.client_password;
            this.client_email = users.client_email;
            this.age = users.age;
            this.information = users.information;
            this.goal = users.goal;
            trainings = new List<Trainings>(users.trainings);
        }
        public int Id { get; set; }
        public string client_name { get; set; }
        public string client_surname { get; set; }
        public string client_password { get; set; }
        public string client_email { get; set; }
        public int age { get; set; }
        public List<Trainings>? trainings { get; set; } = new();
        public string  goal { get; set; }
        public string information { get; set; }
    }

}
