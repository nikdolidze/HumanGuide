using System.Net;

namespace HumanGuide.Core.Application.Exceptions
{

    public class EntityAlreadyExistException : EntityValidationException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        /// <summary>
        /// ჩანაწერი უკვე არსებობს
        /// </summary>
        public EntityAlreadyExistException(string message) : base(message) { }
    }
}
