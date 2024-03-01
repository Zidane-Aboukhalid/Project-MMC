
namespace Application.DTO
{
    public class SessionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
		public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
		public Guid SubCategoryId { get; set; }
		public string Description { get; set; }
        public int Nbrplace { get; set; }
        public string Type { get; set; }
        public string Adress { get; set; }
        public Guid EventId { get; set; } 
    }
}
