using MultiShop.DTOLayer.CatalogDTOs.SliderDTOs;
using MultiShop.DTOLayer.CatalogDTOs.SpecialOfferDTOs;

namespace MultiShop.WebUI.Models
{
    public class SlidersOffersViewModel
    {
        public List<ResultSliderDTO> Sliders { get; set; }
        public List<ResultSpecialOfferDTO> SpecialOffers { get; set; }
    }
}
