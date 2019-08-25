using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.ViewModel
{
    public class OffsetModel
    {
        [Display(Name = "index")]
        public int? Index { get; set; } = 0;

        [Display(Name = "length")]
        public int? Length { get; set; } = 30;
    }
}