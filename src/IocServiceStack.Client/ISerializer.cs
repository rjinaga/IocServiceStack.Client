namespace IocServiceStack.Client
{
    using System;
    public interface ISerializer
    {
        object Deserialize(byte[] content, Type type);
        byte[] Serialize(object @object);
    }
}
