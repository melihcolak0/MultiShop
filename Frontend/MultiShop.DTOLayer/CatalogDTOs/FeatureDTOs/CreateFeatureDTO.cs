using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DTOLayer.CatalogDTOs.FeatureDTOs
{
    public class CreateFeatureDTO
    {
        public string Title { get; set; }
        public string IconUrl { get; set; }
        public bool Status { get; set; }
    }
}
