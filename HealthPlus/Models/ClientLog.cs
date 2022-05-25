namespace HealthPlus.Models
{
    public class ClientLog : Users
    {
        public ClientLog() : base() { }
        public ClientLog(Users user) : base(user) 
        {
            this.client_email = user.client_email;
            this.client_name = user.client_name;
            this.client_password = user.client_password;
            this.age = user.age;
            this.Id = user.Id;
            this.trainings = new List<Trainings>(user.trainings);
        }
    }
}
