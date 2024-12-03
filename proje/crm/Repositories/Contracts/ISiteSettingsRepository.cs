using Entities.Models;

namespace Repositories.Contracts
{
    public interface ISiteSettingsRepository:IRepositoryBase<SiteSettings>
    {
        void UpdateSiteSettings(SiteSettings entity);
    }
}