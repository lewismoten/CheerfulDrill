using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace LewisMoten.Spiders.CheerfulDrill.Core
{
    public static class JsonExtensions
    {
        public static string ToJson(this object graph)
        {
            var serializer = new DataContractJsonSerializer(graph.GetType());
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, graph);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public static T FromJson<T>(this T graph, string json)
        {
            var serializer = new DataContractJsonSerializer(typeof (T));
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                return (T) serializer.ReadObject(stream);
            }
        }

        public static T Copy<T>(this T source)
        {
            return FromJson(source, source.ToJson());
        }

        public static IEqualityComparer<T> GetComparer<T>(this T target)
        {
            return new EqualityComparer<T>();
        }

        public sealed class EqualityComparer<T> : IEqualityComparer<T>
        {
            public bool Equals(T x, T y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return String.Equals(x.ToJson(), y.ToJson());
            }

            public int GetHashCode(T obj)
            {
                return obj.ToJson().GetHashCode();
            }
        }
    }
}