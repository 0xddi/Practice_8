namespace Practice_8;

class Program
{
    static void Main()
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
                Client.PrintJson(Client.GetJson(inputId));
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