using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Session
    {
        public Guid Id { get; set; }
		public string Name { set; get; }
		public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }
        public int Nbrplace { get; set; }

        public string Type { get; set; }
        public string Adress { get; set; }
		public Guid SubCategoryId { get; set; }
		[ForeignKey("Event")]
        public Guid EventId { get; set; } 
        public Event Event { get; set; }
    }
}
