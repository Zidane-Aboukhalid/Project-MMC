using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class EventDto
    {

        public Guid Id { set; get; }
        public string Name { set; get; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { set; get; }
        public string? URL { set; get; }
		public string Adress { get; set; }
		public List<SessionDto> Sessions { set; get; }
    }
}
