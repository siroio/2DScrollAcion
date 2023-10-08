using System;
using System.Runtime.Serialization;

[Serializable]
public class NotAttachException<T> : Exception
{
    public NotAttachException()
    {
    }

    public NotAttachException(string msg) : base($"Please Attach {nameof(T)} \nmessage: {msg}")
    {
    }

    public NotAttachException(string msg, Exception innerException) : base($"Please Attach {nameof(T)} \nmessage: {msg}", innerException)
    {
    }

    protected NotAttachException(SerializationInfo info, StreamingContext ctx) : base(info, ctx)
    {
    }
}
