using DataModel;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace FileHandler
{
    public class FileOperation : IFileOperation
    {
        private string _fileLocation;
        private readonly object _lockObject = new object();

        public FileOperation(IOptions<FileConfiguration> options)
        {
            _fileLocation = Path.Combine(Directory.GetCurrentDirectory(), options.Value.FilePath);
        }

        public List<T> ReadFile<T>() where T : class
        {
            lock (_lockObject)
            {
                string data = File.ReadAllText(_fileLocation);
                if (!string.IsNullOrEmpty(data))
                {
                    return JsonConvert.DeserializeObject<List<T>>(data);
                }
                return null;
            }
        }

        public bool WriteFile(string data)
        {
            try
            {
                lock (_lockObject)
                {
                    File.WriteAllText(_fileLocation, data);
                }
                return true;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
