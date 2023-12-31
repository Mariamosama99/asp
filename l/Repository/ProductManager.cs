﻿using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductManager : Manager<Product>
    {
        public ProductManager(MyDBContext myDBContext) : base(myDBContext) { }

        public IQueryable<Product> Get()
        {
            return GetList().Include(i => i.ProductAttachments).Include(i => i.Category);
        }

        public Product GetOneByID(int id)
        {
            return Get().Where(i => i.ID == id).FirstOrDefault();
        }

        public void Edit(Product newPrd, int id)
        {
            var oldprod = GetOneByID(id);
            oldprod.Name = newPrd.Name;
            oldprod.Price = newPrd.Price;
            oldprod.Quantity = newPrd.Quantity;
            oldprod.CategoryID = newPrd.CategoryID;
            oldprod.Description = newPrd.Description;

            Update(oldprod);
        }





    }
}
