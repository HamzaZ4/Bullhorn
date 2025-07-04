using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("comments")]
public class Comment
{
    public int? Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public int? StockId { get; set; } // navigation property 
    
    public Stock? Stock { get; set; } // actually access the properyy
    
    
}