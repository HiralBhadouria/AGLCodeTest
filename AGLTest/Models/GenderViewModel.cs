using AGL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGL.Presentation.Models
{
    public class GenderViewModel
    {
        public GenderTypeEnum Gender { get; set; }
        public List<CatViewModel> Cats { get; set; }
    }
}
