using System;
using Website_Builder.Models;

namespace Website_Builder.Services.Websites.Services
{
	public interface IWebsiteService
	{
		Website FetchWebsite(string websiteId);

		Website? CreateWebsite(Website website);

		ICollection<Website> FetchAllWebsites();
	}
}

