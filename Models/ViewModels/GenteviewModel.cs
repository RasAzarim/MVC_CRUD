﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_CRUD.Models.ViewModels
{
    public class GenteviewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Correo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimeinto")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime Fecha_Nacimiento { get; set; }
        
    }
}