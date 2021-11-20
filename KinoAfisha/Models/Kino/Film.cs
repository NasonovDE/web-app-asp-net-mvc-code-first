using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppAspNetMvcCodeFirst.Extensions;
using WebAppAspNetMvcCodeFirst.Models.Attributes;

namespace KinoAfisha.Models
{
    public class Film
    {
        /// <summary>
        /// Id
        /// </summary> 
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary> 
        [Required]
        [Display(Name = "Название", Order = 5)]
        public string NameFilm { get; set; }
        
      

        /// <summary>
        /// Возрастное ограничение
        /// </summary> 
        [ScaffoldColumn(false)]
        public FilmYears FilmYears{ get; set; }

        [Display(Name = "Ограничение", Order = 50)]
        [UIHint("DropDownList")]
        [TargetProperty("FilmYears")]
        [NotMapped]
        public IEnumerable<SelectListItem> YearsDictionary
        {
            get
            {
                var dictionary = new List<SelectListItem>();

                foreach (FilmYears type in Enum.GetValues(typeof(FilmYears)))
                {
                    dictionary.Add(new SelectListItem
                    {
                        Value = ((int)type).ToString(),
                        Text = type.GetDisplayValue(),
                        Selected = type == FilmYears
                    });
                }

                return dictionary;
            }
        }

        /// <summary>
        /// Фото обложка
        /// </summary> 
        [ScaffoldColumn(false)]
        public virtual FilmCover FilmCover { get; set; }

        [Display(Name = "Обложка", Order = 60)]
        [NotMapped]
        public HttpPostedFileBase FilmCoverFile { get; set; }

      
    }
}