using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class SiteSettingsRepository : RepositoryBase<SiteSettings>, ISiteSettingsRepository
    {
        public SiteSettingsRepository(RepositoryContext context) : base(context)
        {
        }

        public void UpdateSiteSettings(SiteSettings entity) => Update(entity);

    }
}