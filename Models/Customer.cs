using System;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Models
{
	public class Customer
	{
		[Key]
        public int Id { get; set; }

		[Required(ErrorMessage ="Please enter customer's name.")]
		[StringLength(255)]
        public string Name { get; set; }

		public bool IsSubscribedNewsletter { get; set; }

		[Display(Name = "Date of Birth")]
        [IsAgeOver18]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        public MembershipType? MembershipType { get; set; }
    }
}

