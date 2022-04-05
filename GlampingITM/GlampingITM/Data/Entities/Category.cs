﻿using System.ComponentModel.DataAnnotations;

namespace GlampingITM.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Categorias")]
        [MaxLength(50, ErrorMessage ="El campo {0} debe tener minimo {1} caracter.")]
        [Required(ErrorMessage ="El campo {0} es obligatorio.")]
        public string Name { get; set; }
    }
}
