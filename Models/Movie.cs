using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
	public class Movie
	{
        [Key]
        public int Id { get; set; }

		public string Name { get; set; }
		public string Genre { get; set; }
		public DateTime ReleaseDate { get; set; }
		public DateTime DateAdded { get; set; }
		public int NumInStock { get; set; }
	}
}

