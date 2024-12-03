using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
    public interface ISiteService
    {
        siteSettingsDtoForUpdate GetSettings(bool trackChanges);
        void UpdateSettings(siteSettingsDtoForUpdate siteSettingsDto);

        IEnumerable<SiteSettings> GetAllSettings(bool trackChanges);
    }
}