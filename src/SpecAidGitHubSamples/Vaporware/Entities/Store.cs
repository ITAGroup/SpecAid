namespace SpecAidGitHubSamples.Vaporware.Entities
{
    public class Store : IVaporEntity
    {
        public string Id { get { return StoreId.ToString(); } set { StoreId = int.Parse(value); } }

        public int StoreId { get; set; }

        public string Name { get; set; }
    }
}
