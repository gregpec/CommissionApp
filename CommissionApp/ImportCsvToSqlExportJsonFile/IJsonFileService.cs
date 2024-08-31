using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommissionApp.Services;

public interface IJsonFileService<T>
{
    List<T> LoadFromFile();
    void SaveToFile(IEnumerable<T> data);
}
