namespace WebApiCore.DomainModel.Restaurant
{
    public class AreaInfos
    {
        public AreaInfos()
        {

        }

        public AreaInfos(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}