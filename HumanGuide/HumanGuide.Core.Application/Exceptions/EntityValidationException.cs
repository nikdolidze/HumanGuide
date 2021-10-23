using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HumanGuide.Core.Application.Exceptions
{
    public abstract class EntityValidationException : Exception
    {
        public abstract HttpStatusCode StatusCode { get; }

        public EntityValidationException(string message) : base(message) { }
    }
}
