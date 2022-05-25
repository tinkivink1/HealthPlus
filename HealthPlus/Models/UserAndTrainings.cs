namespace HealthPlus.Models
{
    public class UserAndTrainings
    {
        public UserAndTrainings(Users users, IEnumerable<HealthPlus.Models.Trainings> trainings)
        {
            this.users = new Users(users);
            this.trainings = new List<Trainings>(trainings);
        }
        public Users users { get; set; }
        public IEnumerable<HealthPlus.Models.Trainings> trainings { get; set; }
    }
}
