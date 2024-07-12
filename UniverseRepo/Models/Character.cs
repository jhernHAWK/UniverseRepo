namespace UniverseRepo.Models
{
    public class Character
    {
        public int Id { get; set; }
        public int universe_id { get; set; }
        public string character_name { get; set; }
        public string description { get; set; }
    }
}
