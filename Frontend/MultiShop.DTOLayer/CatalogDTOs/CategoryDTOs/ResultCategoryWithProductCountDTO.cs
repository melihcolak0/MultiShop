using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DTOLayer.CatalogDTOs.CategoryDTOs
{
    public class ResultCategoryWithProductCountDTO
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImageUrl { get; set; }
        public int ProductCount { get; set; }
    }
}
