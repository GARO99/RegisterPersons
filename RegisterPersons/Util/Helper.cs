using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RegisterPersons.Util.Exceptions;
using RegisterPersons.Util.Response;
using System.Net;

namespace RegisterPersons.Util
{
    public class Helper
    {
        public static ObjectResult GetExectionResponse(Exception ex)
        {
            IDictionary<Type, int?> exception = new Dictionary<Type, int?>()
            {
                { typeof(ConflictException), (int?)HttpStatusCode.Conflict },
                { typeof(BadResquestException), (int?)HttpStatusCode.BadRequest }
            };
            bool successGet = exception.TryGetValue(ex.GetType(), out int? statusCode);
            if (!successGet)
            {
                statusCode = (int?)HttpStatusCode.InternalServerError;
            }
            return new ObjectResult(new ErrorResponse() { Message = ex.Message, Details = ex.InnerException?.Message })
            {
                StatusCode = statusCode
            };

        }

        public static void CheckValidation(ValidationResult result)
        {
            if (!result.IsValid)
            {
                string messageError = "";
                foreach (ValidationFailure error in result.Errors)
                {
                    messageError += error.ErrorMessage+Environment.NewLine;
                }
                throw new BadResquestException(messageError);
            }
        }
    }
}
