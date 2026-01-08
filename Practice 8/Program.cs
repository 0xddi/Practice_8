namespace Practice_8;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("=== SeaDocs Document Viewer ===");
        Console.WriteLine("===       Practice 8        ===");
        while (true)
        {
            Console.Write("Введите ID нужного документа: ");
            var inputId = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(inputId)) break;
            try
            {
                var rawJson = await Client.GetJsonAsync(inputId);
                Client.PrintJson(rawJson);
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine("The timeout of HTTP request has reached its limit.");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Couldn't connect to the URL.");
            }
            
            Console.WriteLine("[~] The execution of the task has ended. Starting from very beginning");
        }
        
    }
}