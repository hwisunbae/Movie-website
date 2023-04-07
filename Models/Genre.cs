﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
	public class Genre
	{
		[Key]
		public byte Id { get; set; }

        [Required]
		[StringLength(255)]
        public string Name { get; set; }
    }
}

