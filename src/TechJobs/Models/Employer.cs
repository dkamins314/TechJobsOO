namespace TechJobs.Models
{
    public class Employer : JobField
    {
        public int EmployerID { get; set; }
        public int EmployerAddress { get; set; }
        public string EmployerPrimaryContact { get; set; }
        public string EmployerListOfJobs { get; set; }
    }
}
