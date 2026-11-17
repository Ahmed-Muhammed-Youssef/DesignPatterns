namespace SOLID.SingleResponsibility;

// Responsibility 1: keep journal entries.
public class Journal
{
    private readonly List<string> entries = [];

    public int AddEntry(string entry)
    {
        entries.Add(entry);
        return entries.Count;
    }

    public void RemoveEntryAt(int index)
    {
        entries.RemoveAt(index);
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, entries);
    }
}

// Responsibility 2: save and load journals. Kept out of Journal so that
// changing how or where journals are stored never touches Journal.
public static class Persistence
{
    public static void SaveToFile(Journal journal, string fileName, bool overwrite = false)
    {
        if (overwrite || !File.Exists(fileName))
        {
            File.WriteAllText(fileName, journal.ToString());
        }
    }

    public static string LoadFile(string fileName)
    {
        return File.ReadAllText(fileName);
    }
}
