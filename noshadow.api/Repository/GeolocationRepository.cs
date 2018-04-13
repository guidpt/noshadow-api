using noshadow.api.Context;
using noshadow.api.Model.Entity;
using noshadow.api.Utils;

namespace noshadow.api.Repository
{
    public class GeolocationRepository: BaseRepository<LogEntity>
    {
        public GeolocationRepository(NoShadowContext dataContext) : base(dataContext)
        {

        }
    }
    
}