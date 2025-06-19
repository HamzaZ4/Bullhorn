using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("stock")]
public class Stock
{
    public int Id { get; set; }

    public string Ticker { get; set; } = string.Empty;
    
    public string CompanyName { get; set; } = string.Empty;
    
    public decimal Price { get; set; }
    
    public decimal LastDiv {get; set;}

    public string Industry { get; set; } = string.Empty;
    
    public long MarketCap { get; set; }
    
    public List<Comment> Comments { get; set; } = new();
    
}