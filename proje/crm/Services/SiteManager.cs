using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class SiteManager : ISiteService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public SiteManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public IEnumerable<SiteSettings> GetAllSettings(bool trackChanges)
        {
            var settings = _manager.settingsRepository.FindAll(false);
            return settings;
        }

        public siteSettingsDtoForUpdate GetSettings(bool trackChanges)
        {
            var setting = _manager.settingsRepository.FindAll(false).FirstOrDefault();
            var settingsDto = _mapper.Map<siteSettingsDtoForUpdate>(setting);
            return settingsDto;
        }

        public void UpdateSettings(siteSettingsDtoForUpdate siteSettingsDto)
        {
            var entity = _mapper.Map<SiteSettings>(siteSettingsDto);
            _manager.settingsRepository.UpdateSiteSettings(entity);
            _manager.Save();
        }
    }
}