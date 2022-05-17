using System.ComponentModel.DataAnnotations.Schema;

namespace HealthPlus.Models
{
    public class Users
    {   
    public int Id { get; set; }
    public string client_name { get; set; }
    public string client_surname { get; set; }
    public string client_password { get; set; }
    public string client_email { get; set; }
    public int age { get; set; }
    public int Id_training { get; set; }
    public Trainings trainings { get; set; }


}

}
