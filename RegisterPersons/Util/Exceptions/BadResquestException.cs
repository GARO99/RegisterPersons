using System.Runtime.Serialization;

namespace RegisterPersons.Util.Exceptions
{
    [Serializable]
    public class BadResquestException : Exception
    {
        public BadResquestException()
        {
        }

        public BadResquestException(string message) : base(message)
        {
        }

        public BadResquestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BadResquestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
