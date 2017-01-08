namespace IocServiceStack.Client
{
    using System;
    using System.Text;

    public class JsonSerializer : ISerializer
    {
        public object Deserialize(byte[] content, Type type)
        {
            string value = Encoding.UTF8.GetString(content);
            var @object = Newtonsoft.Json.JsonConvert.DeserializeObject(value, type);
            return @object;
        }

        public byte[] Serialize(object @object)
        {
            var data = Newtonsoft.Json.JsonConvert.SerializeObject(@object);
            return Encoding.UTF8.GetBytes(data);
        }
    }
}
