namespace CommissionApp.JsonFile.ImportCsvToSqlExportJsonFile;

public interface IJsonFileService<T>
{
    List<T> LoadFromFile();
    void SaveToFile(IEnumerable<T> data);
}
