using Portfolio.Domain.Dtos;
using System.Threading.Tasks;

namespace Portfolio.Core.Interfaces
{
    public interface IAboutMeService
    {
        Task<AboutMeDto> GetAboutMe();

        Task SaveAboutMe(AboutMeDto model);
    }
}
