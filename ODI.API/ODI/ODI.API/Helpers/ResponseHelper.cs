using System.Collections.Generic;
using System.Net;

namespace ODI.API.Helpers
{
    public class ResponseHelper<TModel>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<TModel> TEntities { get; set; }
        public TModel TEntity { get; set; }

        public ResponseHelper(HttpStatusCode statusCode, string message, List<TModel> entities)
        {
            StatusCode = statusCode;
            StatusMessage = message;
            TEntities = entities;
        }

        public ResponseHelper(HttpStatusCode statusCode, string message, TModel entity)
        {
            StatusCode = statusCode;
            StatusMessage = message;
            TEntity = entity;
        }
    }

}
