namespace CashCrew.Maui.Data.Entities
{
    public class LocationCategory
    {
        [PrimaryKey]
        public string Name { get; set; }
        public string Image { get; set; }

        public LocationCategory(string name, string image)
        {
            Name = name;
            Image = image;
        }

        public LocationCategory() { }
    }
}
