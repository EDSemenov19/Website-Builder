using System;
using Microsoft.EntityFrameworkCore;

namespace Website_Builder.Data.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Models.Website> Websites {get; set;}

	}
}

