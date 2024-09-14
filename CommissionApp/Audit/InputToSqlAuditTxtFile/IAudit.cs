namespace CommissionApp.Audit.InputToSqlAuditTxtFile
{
    public interface IAudit
    {
        string Date { get; }
        string Action { get; }
        string ItemData { get; }
        List<string> ReadAuditFile();
        void AddEntryToFile();
        void SaveAuditFile();
    }
}
