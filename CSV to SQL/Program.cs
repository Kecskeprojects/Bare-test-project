namespace CSVtoSQL;

internal class Program
{
    private static void Main()
    {
        List<string[]> lines = File.ReadAllLines("Translations.csv", System.Text.Encoding.UTF8).ToList().Select(line => line.Replace(";;;;", "").Replace("\'", "\'\'").Split(";")).ToList();

        List<string> Inserts = [];

        foreach (string[] line in lines)
        {
            Inserts.Add($"INSERT INTO [translation] ([English], [Hungarian], [Spanish], [Chinese], [Portugese]) VALUES (N'{line[0]}', N'{line[1]}', N'{line[2]}', N'{line[3]}', N'{line[4]}')");
        }

        File.WriteAllLines("Inserts.txt", [.. Inserts]);
        Console.WriteLine("Done!");
        Console.ReadKey();
    }
}