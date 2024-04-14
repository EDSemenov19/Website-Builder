using System;
using Website_Builder.Data.Data;
using Website_Builder.Models;

namespace Website_Builder.Services.Websites.Services
{
	public class WebsiteService : IWebsiteService
	{

        private readonly ApplicationDbContext _dbContext;

		public WebsiteService(ApplicationDbContext _context)
		{

            _dbContext = _context;
		}

        public Website? CreateWebsite(Website website)
        {
            website.Id = Guid.NewGuid().ToString();
            _dbContext.Websites.Add(website);
            _dbContext.SaveChanges();
            return website;
        }

        public Website FetchWebsite(string websiteId)
        {
            var res = _dbContext.Websites.FirstOrDefault(w => w.Id == websiteId);

            return res != null ? res : null;
        }

        public ICollection<Website> FetchAllWebsites() {
            var res = _dbContext.Websites.ToList();

            return res;
        }

        
    }
}

