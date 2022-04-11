using ODI.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ODI.Repository.ReqRespVm
{
    public class GenericResponse<TEntity, T> where TEntity : class
    {
        public IEnumerable<TEntity> Entities { get; set; }
        public TEntity Entity { get; set; }
        public string Message { get; set; }
        public T EntityId { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public GenericResponse<TEntity, T> GetGenericResponse(
            IEnumerable<TEntity> entities, TEntity entity, string message, T entityId,
            ResponseStatus status)
        {
            return new GenericResponse<TEntity, T>()
            {
                Entities = entities,
                Entity = entity,
                Message = message,
                EntityId = entityId,
                ResponseStatus = status
            };
        }
    }
}
