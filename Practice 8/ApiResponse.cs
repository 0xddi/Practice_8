namespace Practice_8;

public class ApiResponse
{
    public string? AccessLevel { get; set; }
    public Share Share { get; set; }
    public List<Document> Lineage { get; set; }
    public List<Document> Children { get; set; }
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsIndexed { get; set; }
    public string? CoverUrl { get; set; }
    public string? OwnerId { get; set; }
    public string? ParentId { get; set; }
    public string? CreatedAt { get; set; }
    public string? UpdatedAt { get; set; }
}

public class Share
{
    public string? Access { get; set; }
    public string? Type { get; set; }
}

public class Document
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsIndexed { get; set; }
    public string? CoverUrl { get; set; }
    public string? OwnerId { get; set; }
    public string? ParentId { get; set; }
    public string? CreatedAt { get; set; }
    public string? UpdatedAt { get; set; }
}

