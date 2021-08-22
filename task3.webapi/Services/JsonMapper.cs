using System;
using System.IO;
using Newtonsoft.Json;

namespace task3.webapi.Services
{
    public class JsonMapper : IJsonMapper
    {
        public T Deserialize<T>(T entity, string fileName){
            //get json file as filestream
            using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory+fileName))
            {
                string json = r.ReadToEnd();
                var type = entity.GetType();
                //Deserialize hoterates.json into T class
                var result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }
    }
}