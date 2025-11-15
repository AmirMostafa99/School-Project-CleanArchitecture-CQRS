using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Bases
{
    public class ResponseHandler
    {
        private readonly IStringLocalizer<SharedResources> _stringlocalizer;

        public ResponseHandler(IStringLocalizer<SharedResources> stringlocalizer)
        {
            _stringlocalizer = stringlocalizer;
        }
        public Response<T> Deleted<T>(string Message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = Message == null ? _stringlocalizer[SharedResourcesKeys.Deleted] : Message,

            };
        }


        public Response<T> Success<T>(T entity, object Meta = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = _stringlocalizer[SharedResourcesKeys.Success],
                Meta = Meta

            };
        }

        public Response<T> Unauthorized<T>()
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = _stringlocalizer[SharedResourcesKeys.UnAuthorized],


            };
        }

        public Response<T> BadRequest<T>(string Message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message == null ? _stringlocalizer[SharedResourcesKeys.BadRequest] : Message,


            };
        }
        public Response<T> UnprocessableEntity<T>(string Message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = Message == null ? _stringlocalizer[SharedResourcesKeys.UnprocessableEntity] : Message,


            };
        }

        public Response<T> NotFound<T>(string Message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = Message == null ? _stringlocalizer[SharedResourcesKeys.NotFound] : Message,

            };
        }
        public Response<T> Created<T>(T entity, object Meta = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = _stringlocalizer[SharedResourcesKeys.Created],
                Meta = Meta

            };
        }


    }
}
