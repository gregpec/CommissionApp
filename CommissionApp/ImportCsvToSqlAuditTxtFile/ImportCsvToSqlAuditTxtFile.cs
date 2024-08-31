using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CommissionApp.ImportCsvToSqlAuditTxtFile
{
    public class ImportCsvToSqlAuditTxtFile<T> : IImportCsvToSqlAuditTxtFile<T>
    {
        private readonly string _auditFileName;

        public ImportCsvToSqlAuditTxtFile(string auditFileName)
        {
            _auditFileName = auditFileName;
        }

        public void LogAudit(string action, T item)
        {
            var data = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var logEntry = $"{data} - {action} - {item}";
            try
            {
                File.AppendAllText(_auditFileName, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to log audit entry: {ex.Message}");
            }
        }
    }      
}



























    

