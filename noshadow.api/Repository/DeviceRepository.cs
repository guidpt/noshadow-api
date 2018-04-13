using noshadow.api.Context;
using noshadow.api.Model.Entity;
using noshadow.api.Utils;

namespace noshadow.api.Repository
{
    public class DeviceRepository: BaseRepository<DeviceEntity>
    {
        public DeviceRepository(NoShadowContext dataContext) : base(dataContext)
        {

        }
    }
}