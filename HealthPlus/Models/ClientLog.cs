namespace HealthPlus.Models
{
    public class ClientLog
    {
        public string email { get; set; }   
        public string password { get; set; }
        public ClientLog(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
