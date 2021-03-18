using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Interfaces;
using Portfolio.Core.Interfaces.Common;
using Portfolio.Domain.Dtos;
using Portfolio.Domain.Models;
using System.Threading.Tasks;

namespace Portfolio.Core.Services
{
    public class AboutMeService : IAboutMeService
    {
        #region Fields

        private readonly IBaseRepository<AboutMe, AboutMeDto> _aboutMeRepository;

        #endregion

        #region Constructor

        public AboutMeService(IBaseRepository<AboutMe, AboutMeDto> aboutMeRepository)
        {
            _aboutMeRepository = aboutMeRepository;
        }

        #endregion

        #region Methods

        public Task<AboutMeDto> GetAboutMe()
        {
            return _aboutMeRepository.FirstOrDefaultAsync();
        }

        public async Task SaveAboutMe(AboutMeDto model)
        {
            var aboutMe = await GetAboutMe();
            if(aboutMe == null)
            {
                await _aboutMeRepository.InsertAsync(model);
                return;
            }

            await Update(model, aboutMe);
        }

        #region Utils

        private Task Update(AboutMeDto model, AboutMeDto original)
        {
            original.Content = model.Content;
            original.Title = model.Title;

            return _aboutMeRepository.UpdateAsync(original);
        }

        #endregion

        #endregion

    }
}
