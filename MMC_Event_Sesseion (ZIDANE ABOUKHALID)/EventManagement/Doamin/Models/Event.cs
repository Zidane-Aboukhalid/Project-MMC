using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Domain.Models
{
    public class Event
    {
        public Guid Id { set; get; }
        public string Name { set; get; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { set; get; }
		public string Adress { get; set; }
		public string? URL { set; get; }

      //  public Guid? TargetAudienceId {get; set;}

        public List<Session> Sessions { set; get; }


        
    }
}
