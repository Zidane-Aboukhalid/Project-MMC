using Microsoft.EntityFrameworkCore;
using Participant_Speaker.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Infra.data
{
	public class ApplicationContext :DbContext
	{
        public ApplicationContext(DbContextOptions<ApplicationContext> dbContextOptions):base(dbContextOptions){    
        }

        public DbSet<Speaker> Speakers { get; set; } 
        public DbSet<LinkSm> LinkSms { get; set; }
		public DbSet<Participant> Participants { get; set; }
		public DbSet<SpeakerSession> SpeakerSessions { get; set; }
	}
}
