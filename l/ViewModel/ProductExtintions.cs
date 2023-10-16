using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public static class ProductExtintions
    {
        public static Product ToModel(this AddProductViewModel addProduct)
        {
            var ProductAttachments = new List<ProductAttachment>();
            foreach (var item in addProduct.ImagesUrl)
            {
                ProductAttachments.Add(new ProductAttachment()
                {
                    Image = item
                });
            }
            return new Product
            {
                ID = addProduct.Id,
                Name = addProduct.Name,
                Price = addProduct.Price,
                Quantity = addProduct.Quantity,
                Description = addProduct.Description,
                CategoryID = addProduct.CategoryID,
                ProductAttachments = ProductAttachments
            };
        }
        public static Product ToModel(this ProductViewModel addProduct)
        {
            var ProductAttachments = new List<ProductAttachment>();
            foreach (var item in addProduct.Images)
            {
                ProductAttachments.Add(new ProductAttachment()
                {
                    Image = item
                });
            }
            return new Product
            {
                ID = addProduct.ID,
                Name = addProduct.Name,
                Price = addProduct.Price,
                Quantity = addProduct.Quantity,
                Description = addProduct.Description,
                CategoryID = addProduct.CategoryId,
                ProductAttachments = ProductAttachments
            };
        }
        public static ProductViewModel ToVeiwModel(this Product product)
        {
            return new ProductViewModel
            {
                ID = product.ID,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Quantity = product.Quantity,
                CategoryId = product.CategoryID,
                CategoryName = product.Category.Name,
                Images = product.ProductAttachments.Select(x => x.Image).ToList(),
            };
        }
    }
}
