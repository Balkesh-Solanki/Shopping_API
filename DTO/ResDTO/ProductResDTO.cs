using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ResDTO
{
    public class ProductResDTO
    {
        public int Id { get; set; }
        public int? SubCategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string SubCategoryName { get; set; }  
    }
}
