﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AnnouncementDTOs
{
    public class AnnouncementAddValidatorDTO
    {
        //Others are auto increment properties
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}
