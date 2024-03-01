using Application.CustomActionFilters;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class AddSessionDto
    {  
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
		public string Name { set; get; }
        [Required]
		//[DateEndValidation(nameof(DateStart), ErrorMessage = "La date de fin doit être égale ou postérieure à la date de début.")]
        public DateTime DateEnd { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Nbrplace { get; set; }
		[Required]
		public Guid SubCategoryId { get; set; }
		[Required]
        public string Type { get; set; }
        [Required]
        public string Adress { get; set; }
        public Guid? EventId { get; set; }
        public Guid TargetAudienceId { get; set; }


    }
}
