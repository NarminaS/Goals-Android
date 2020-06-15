using Goals.DTO;
using Goals.Models;
using Messenger.Repositories.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Goals.Services.Repositories.Abstract
{
    interface IMissionRepository : IRepository<Mission>
    {
        Task<List<MissionSimpleDto>> GetMissionsForList();

        Task<MissionSimpleDto> CreateForList(MissionCreateDto mission);

        Task<MissionDetailDto> GetForDetail(int id);
    }
}
