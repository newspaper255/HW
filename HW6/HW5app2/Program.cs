namespace HW5app2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            const string savePathName = @"D:\HW\HW6\HW5app1\Lesson12Homework.txt";
            string infoFilePath = "";

            // Read path info.csv
            try
            {
                using (StreamReader reader = new(savePathName))
                {
                    infoFilePath = await reader.ReadLineAsync();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File .txt not found: {ex.Message}");
            }

            catch (IOException ex)
            {
                Console.WriteLine($"Error read .txt {ex.Message}");
            }

            List<FileData> data = new();

            // Read data 
            try
            {
                using (StreamReader reader = new(infoFilePath))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        string[] fields = line.Split('\t');
                        FileData item = new()
                        {
                            Type = fields[0],
                            Name = fields[1],
                            Date = DateTime.Parse(fields[2])
                        };
                        data.Add(item);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File .csv not found: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error read .csv {ex.Message}");
            }

            // Sort
            var sortedData = data.OrderBy(item => item.Date).ToList();
            // Write data
            foreach (FileData item in sortedData)
            {
                Console.WriteLine($"{item.Type} {item.Name} {item.Date}");
            }



            // Delete File
            File.Delete(savePathName);
        }
    }

    // Class for data
    public class FileData
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }

}