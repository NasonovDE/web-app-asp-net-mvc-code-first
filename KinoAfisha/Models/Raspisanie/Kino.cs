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
    public class Kino
    {
        /// <summary>
        /// Id
        /// </summary> 
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }


        /// <summary>
        /// Название
        /// </summary> 
        ///  [ScaffoldColumn(false)] 
        public virtual ICollection<Film> Films { get; set; }
        [ScaffoldColumn(false)]
        public List<int> FilmIds { get; set; }
       
        [Display(Name = "Название", Order = 5)]
        [UIHint("MultipleDropDownList")]
        [TargetProperty("FilmIds")]
        [NotMapped]
        public IEnumerable<SelectListItem> FilmDictionary
        {
            get
            {
                var db = new KinoAfishaContext();
                var query = db.Films;

                if (query != null)
                {
                    var Ids = query.Where(s => s.Kinos.Any(ss => ss.Id == Id)).Select(s => s.Id).ToList();
                    var dictionary = new List<SelectListItem>();
                    dictionary.AddRange(query.ToSelectList(c => c.Id, c => $"{c.NameFilm}", c => Ids.Contains(c.Id)));
                    return dictionary;
                }
                return new List<SelectListItem> { new SelectListItem { Text = "", Value = "" } };
            }
        }




        /// <summary>
        /// Цена
        /// </summary> 
        [Required]
        [Display(Name = "Цена", Order = 10)]
        public decimal Price { get; set; }

        /// <summary>
        /// Количество билетов
        /// </summary> 
        [Required]
        [Display(Name = "Количество билетов", Order = 30)]
        public int NumberOfBilets { get; set; }

        /// <summary>
        /// Место показа
        /// </summary> 

        [ScaffoldColumn(false)]
        public Cinema Cinema { get; set; }

        [Display(Name = "Место показа", Order = 20)]
        [UIHint("DropDownList")]
        [TargetProperty("Cinema")]
        [NotMapped]
        public IEnumerable<SelectListItem> CinemaDictionary
        {
            get
            {
                var dictionary = new List<SelectListItem>();

                foreach (Cinema type in Enum.GetValues(typeof(Cinema)))
                {
                    dictionary.Add(new SelectListItem
                    {
                        Value = ((int)type).ToString(),
                        Text = type.GetDisplayValue(),
                        Selected = type == Cinema
                    });
                }

                return dictionary;
            }
        }

        /// <summary>
        /// Дата
        /// </summary> 
        [Required]
        [Display(Name = "Дата", Order = 40)]
        public DateTime? NextArrivalDate { get; set; }

        /// <summary>
        /// Дата создания записи
        /// </summary> 
        [ScaffoldColumn(false)]
        public DateTime CreateAt { get; set; }


       

    }
}