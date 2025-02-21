using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }

    public int? SubCategoryId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Subcategory? SubCategory { get; set; }
}
