using System;
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;

/*
 * https://stackup.hashnode.dev/ef-migrations-visual-studio-mac to setup DBcontext and DB table via Azure Data Studio
 * 
 * dotnet build - see error
 * dotnet ef migrations add InitialMode
 * dotnet ef migrations remove
 * dotnet ef database update    
 */
namespace Vidly.Data
{
	public class ApplicationDBContext :DbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
		{
		}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MembershipType>().HasData(
                new MembershipType
                {
                    Id = 1,
                    SignUpFee = 0,
                    DurationInMonths = 0,
                    DiscountRate = 0
                },
                new MembershipType
                {
                    Id = 2,
                    SignUpFee = 30,
                    DurationInMonths = 1,
                    DiscountRate = 10
                },
                new MembershipType
                {
                    Id = 3,
                    SignUpFee = 90,
                    DurationInMonths = 3,
                    DiscountRate = 15
                },
                new MembershipType
                {
                    Id = 4,
                    SignUpFee = 300,
                    DurationInMonths = 12,
                    DiscountRate = 20
                }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "Johnm Smith",
                    IsSubscribedNewsletter = false,
                    MembershipTypeId = 1,

                },
                new Customer
                {
                    Id = 2,
                    Name = "Mary Williams",
                    IsSubscribedNewsletter = true,
                    MembershipTypeId = 2,
                }
            );
        }
    }
}

 