using System.Text.Json;

namespace Practice_8;

public class Client
{
    public static async Task<string> GetJsonAsync(string documentId)
    {
        string apiUrl = $"https://seadox.ru/api/seadocs/{documentId}";
    
        using (HttpClient client = new HttpClient())
        {
            client.Timeout = TimeSpan.FromSeconds(10);
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }

    public static void PrintJson(string rawJson)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
            
        var document = JsonSerializer.Deserialize<ApiResponse>(rawJson, options);
        
        if (document == null)
        {
            throw new NullReferenceException("[-] The document was null");
        }
        
        Console.WriteLine("\n=== ОСНОВНАЯ ИНФОРМАЦИЯ ===");
        Console.WriteLine($"ID: {document.Id}");
        Console.WriteLine($"Название: {document.Name}");
        Console.WriteLine($"Описание: {document.Description}");
        Console.WriteLine($"Уровень доступа: {document.AccessLevel}");
        Console.WriteLine($"ID владельца: {document.OwnerId}");
        Console.WriteLine($"ID 'родителя': {document.ParentId}");
        Console.WriteLine($"Создан: {document.CreatedAt}");
        Console.WriteLine($"Обновлён: {document.UpdatedAt}");
        Console.WriteLine($"Индексирован: {(document.IsIndexed ? "Да" : "Нет")}");
        
        if (!string.IsNullOrEmpty(document.CoverUrl))
        {
            Console.WriteLine($"Обложка (URL-адрес): {document.CoverUrl}");
        }
        
        if (document.Share != null)
        {
            Console.WriteLine("=== НАСТРОЙКИ ДОСТУПА ===");
            Console.WriteLine($"Тип доступа: {document.Share.Access}");
            // Не понял, что конкретно значит Type, судя по гуглу Cascades в большинстве API это что-то вроде иерархии
            Console.WriteLine($"Тип наследования: {document.Share.Type}");
        }
        
        if (document.Lineage != null && document.Lineage.Count > 0)
        {
            Console.WriteLine("\n=== ЦЕПОЧКА ПРЕДКОВ ===");
            for (int i = 0; i < document.Lineage.Count; i++)
            {
                var ancestor = document.Lineage[i];
                Console.WriteLine($"{i + 1}. {ancestor.Name} (ID: {ancestor.Id})");
                Console.WriteLine($"   Описание: {ancestor.Description}");
                if (!string.IsNullOrEmpty(ancestor.ParentId))
                {
                    Console.WriteLine($"   Родительский ID: {ancestor.ParentId}");
                }
            }
        }
        else
        {
            Console.WriteLine("Предки отсутствуют");
        }
        
        if (document.Children?.Count > 0)
        {
            Console.WriteLine($"\n=== ДОЧЕРНИЕ ДОКУМЕНТЫ ({document.Children.Count} шт.) ===");
            foreach (var child in document.Children)
            {
                Console.WriteLine($"\n• {child.Name} (ID: {child.Id})");
                if (!string.IsNullOrEmpty(child.Description))
                    Console.WriteLine($"  Описание: {child.Description}");
                Console.WriteLine($"  Создан: {child.CreatedAt}");
            }
        }
        else
        {
            Console.WriteLine("\nДочерние документы: отсутствуют");
        }

        

    }
    
}