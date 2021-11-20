using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KinoAfisha.Models
{
    public enum Cinema
    { 
        [Display(Name = "Факел")]
        Fackel = 1,
		
		[Display(Name = "Красный")]
        Krasniy = 2,

        [Display(Name = "Ю-сити")]
        Usiti = 3
    }
}