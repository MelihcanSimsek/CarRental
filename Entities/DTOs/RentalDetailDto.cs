﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public string? ColorName { get; set; }
        public string? BrandName { get; set; }
        public string? CarName { get; set; }
        public string? UserName { get; set; }
        public string? ModelYear { get; set; }
        public string? CarDescription { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
