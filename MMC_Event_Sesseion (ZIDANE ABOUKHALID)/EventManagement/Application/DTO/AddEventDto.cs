using Application.CustomActionFilter;
using Application.CustomActionFilters;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class AddEventDto
    {

        [Required]
        [MinLength(3, ErrorMessage = "Le code doit comporter au moins 3 caractères.")]
        public string Name { set; get; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        //[DateEndValidation(nameof(DateStart), ErrorMessage = "La date de fin doit être égale ou postérieure à la date de début.")]
        public DateTime DateEnd { get; set; }
        [Required]
        public string Description { set; get; }
		[Required]
		public string Adress { get; set; }
		[Required]
        [DataType(DataType.Upload)]
        [ImageValidation(ErrorMessage = "Extension de fichier non prise en charge ou La taille du fichier dépasse 10 Mo")]
        public IFormFile file { get; set; }


    }
}
