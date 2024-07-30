// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var article = new CustomArticle
{
    Subheading = "A Deep Dive into the Latest Language Enhancements",
    Writer = "John Doe",
    ReleaseDate = DateTime.Now
};

// Display article details using ToString method
Console.WriteLine(article.ToString());

public class CustomArticle
{
    public required string Headline { get; set; }
    public string? Subheading { get; set; }
    public required string Writer { get; set; }
    public required DateTime ReleaseDate { get; set; }

    public override string ToString()
    {
        if (string.IsNullOrWhiteSpace(Subheading))
        {
            return $"{Headline} by {Writer} ({ReleaseDate.ToShortDateString()})";
        }

        return $"{Headline}: {Subheading} by {Writer} ({ReleaseDate.ToShortDateString()})";
    }
}
