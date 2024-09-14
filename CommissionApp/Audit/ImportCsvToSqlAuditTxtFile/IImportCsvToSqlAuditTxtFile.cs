namespace CommissionApp.Audit.ImportCsvToSqlAuditTxtFile
{
    public interface IImportCsvToSqlAuditTxtFile<T>
    {
        void LogAudit(string action, T item);
    }
}
