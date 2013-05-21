namespace SpecAidGitHubSamples.Vaporware.Entities
{
    public class Person : IVaporEntity
    {
        public string Id { get { return EmpId; } set { EmpId = value; } }

        public string EmpId { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }

        public int YearsOfService { get; set; }

        public Store Store { get; set; }
    }
}
