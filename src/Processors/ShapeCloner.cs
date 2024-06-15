using Draw;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public static class ShapeCloner
{
    public static Shape Clone(Shape source)
    {
        if (!typeof(Shape).IsSerializable)
        {
            throw new ArgumentException("The type must be serializable.", "source");
        }
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new MemoryStream();
        using (stream)
        {
            formatter.Serialize(stream, source);
            stream.Seek(0, SeekOrigin.Begin);
            return (Shape)formatter.Deserialize(stream);
        }
    }
}
