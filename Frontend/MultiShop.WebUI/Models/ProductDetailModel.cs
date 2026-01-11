using MultiShop.DTOLayer.CatalogDTOs.ProductDetailDTOs;
using MultiShop.DTOLayer.CatalogDTOs.ProductDTOs;
using MultiShop.DTOLayer.CatalogDTOs.ProductImageDTOs;
using MultiShop.DTOLayer.CommentDTOs.UserCommentDTOs;

namespace MultiShop.WebUI.Models
{
    public class ProductDetailModel
    {
        public GetProductDTO ProductBasics { get; set; }
        public GetProductDetailDTO ProductDetails { get; set; }
        public GetProductImageDTO ProductImages { get; set; }
        public CreateUserCommentDTO CreateComment { get; set; }
    }
}
