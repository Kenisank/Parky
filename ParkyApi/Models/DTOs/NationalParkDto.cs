﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ParkyApi.Models.DTOs
{
    public class NationalParkDto
    {


       
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string State { get; set; }
        public DateTime Created { get; set; }
        public byte[] Picture { get; set; }
        public DateTime Established { get; set; }

    }
}
