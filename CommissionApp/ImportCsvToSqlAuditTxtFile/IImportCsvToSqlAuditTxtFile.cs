using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommissionApp.ImportCsvToSqlAuditTxtFile
{
    public interface IImportCsvToSqlAuditTxtFile<T>
    {
        void LogAudit(string action, T item);
    }
}
