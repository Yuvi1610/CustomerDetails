using System.Collections.Generic;

namespace DataModel
{
    public interface IFileOperation
    {
        List<T> ReadFile<T>() where T : class;
        bool WriteFile(string data);
    }
}
