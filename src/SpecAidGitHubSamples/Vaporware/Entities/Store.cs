namespace SpecAidGitHubSamples.Vaporware.Entities
{
    public class Store : IVaporEntity
    {
        public int Id { get; set; }

        public int StoreId { get { return Id; } set { Id = value; } }

        public string Name { get; set; }
    }
}
