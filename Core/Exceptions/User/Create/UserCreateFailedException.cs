using System.Runtime.Serialization;

namespace Core.Exceptions.User.Create
{
    public class UserCreateFailedException : Exception
    {
        public UserCreateFailedException()
        {
        }

        public UserCreateFailedException(string? message) : base(message)
        {
        }

        public UserCreateFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserCreateFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
