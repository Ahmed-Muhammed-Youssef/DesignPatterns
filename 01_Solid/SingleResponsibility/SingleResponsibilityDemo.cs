namespace SOLID.SingleResponsibility;

public static class SingleResponsibilityDemo
{
    public static void Run()
    {
        var journal = new Journal();
        journal.AddEntry("I learnt single responsibility today.");
        journal.AddEntry("I practised some problem solving.");
        Console.WriteLine(journal);

        var fileName = Path.Combine(Path.GetTempPath(), "journal.txt");
        Persistence.SaveToFile(journal, fileName, overwrite: true);
        Console.WriteLine($"Loaded back from {fileName}:");
        Console.WriteLine(Persistence.LoadFile(fileName));
    }
}
