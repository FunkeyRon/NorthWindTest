using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace NorthWindTest.Common.Helper
{
    public class JsonHelper
    {

        public JsonHelper()
        {

        }

        /// <summary>
        /// Gets the json stream.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private Stream GetJsonStream(string path)
        {
            if (!File.Exists(path))
                return null;

            return File.OpenRead(path);
        }

        private Task<Stream> GetJsonStreamAsync()
        {
            throw new NotImplementedException();
        }

        public T GetJsonObject<T>(string path)
        {
            T result = default(T);
            var stream = GetJsonStream(path);

            if (stream == null) return result;

            using (var streamReader = new StreamReader(stream))
            {
                var jsonString = streamReader.ReadToEnd();
                var jsonObject = JObject.Parse(jsonString);

                result = jsonObject.ToObject<T>();

            }

            return result;
        }
    }
}
