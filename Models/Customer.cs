using System;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Models
{
	public class Customer
	{
		[Key]
        public int Id { get; set; }

		[Required]
		[StringLength(255)]
        public string Name { get; set; }

		public bool IsSubscribedNewsletter { get; set; }

		[Display(Name = "Date of Birth")]
		public DateTime? Birthdate { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        public MembershipType MembershipType { get; set; }
    }
}

