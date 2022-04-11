using System;
using System.Collections.Generic;
using System.Text;

namespace ReqRespVm.Response
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
