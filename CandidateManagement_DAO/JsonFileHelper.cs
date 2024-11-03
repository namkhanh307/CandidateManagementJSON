using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace CandidateManagement_DAO
{

    public class JsonFileHelper<T>
    {
        private readonly string _filePath;

        public JsonFileHelper(string filePath)
        {
            _filePath = filePath;
        }

        public List<T> Read()
        {
            if (!File.Exists(_filePath))
                return new List<T>();

            var jsonData = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonData) ?? new List<T>();
        }

        public void Write(List<T> data)
        {
            var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(_filePath, jsonData);
        }
    }
}
