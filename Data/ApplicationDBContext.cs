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
        public DbSet<MembershipType> MembershipTypes { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MembershipType>().HasData(
                new MembershipType
                {
                    Id = 1,
                    SignUpFee = 0,
                    DurationInMonths = 0,
                    DiscountRate = 0,
                    Name="Pay as You Go"
                },
                new MembershipType
                {
                    Id = 2,
                    SignUpFee = 30,
                    DurationInMonths = 1,
                    DiscountRate = 10,
                    Name = "Monthly"
                },
                new MembershipType
                {
                    Id = 3,
                    SignUpFee = 90,
                    DurationInMonths = 3,
                    DiscountRate = 15,
                    Name = "Quarterly"
                },
                new MembershipType
                {
                    Id = 4,
                    SignUpFee = 300,
                    DurationInMonths = 12,
                    DiscountRate = 20,
                    Name = "Yearly"
                }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "Johnm Smith",
                    IsSubscribedNewsletter = false,
                    MembershipTypeId = 1,
                    Birthdate = new DateTime(1980, 1, 1)
                },
                new Customer
                {
                    Id = 2,
                    Name = "Mary Williams",
                    IsSubscribedNewsletter = true,
                    MembershipTypeId = 2
                }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Name = "Hangover",
                    Genre = "Comedy",
                    ReleaseDate = new DateTime(2016, 11, 6),
                    DateAdded = new DateTime(2016, 5, 4),
                    NumInStock = 5
                },
                new Movie
                {
                    Id = 2,
                    Name = "Die Hard",
                    Genre = "Action",
                    ReleaseDate = new DateTime(2011, 5, 23),
                    DateAdded = new DateTime(2012, 6, 29),
                    NumInStock = 10
                },
                new Movie
                {
                    Id = 3,
                    Name = "The Terminator",
                    Genre = "Action",
                    ReleaseDate = new DateTime(2022, 10, 6),
                    DateAdded = new DateTime(2022, 12, 30),
                    NumInStock = 6
                },
                new Movie
                {
                    Id = 4,
                    Name = "Toy Story",
                    Genre = "Family",
                    ReleaseDate = new DateTime(2017, 4, 2),
                    DateAdded = new DateTime(2016, 1, 4),
                    NumInStock = 2
                },
                new Movie
                {
                    Id = 5,
                    Name = "Titanic",
                    Genre = "Romance",
                    ReleaseDate = new DateTime(2023, 1, 16),
                    DateAdded = new DateTime(2023, 8, 10),
                    NumInStock = 9
                }
            );
        }
    }
}

 