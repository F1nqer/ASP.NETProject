﻿using DbModels.Production;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MainProjectWcfLibrary
{
    public class ProductRepository : IProjectService<Product>
    {
        private Production db;

        public ProductRepository(Production context)
        {
            this.db = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Product.Include(p => p.ProductProductPhoto);
        }

        public IEnumerable<Product> GetAllInInventory()
        {
            return db.Product.Include(p => p.ProductProductPhoto).Where(p => p.ProductInventory.Sum(i => i.Quantity) > 0);
        }


        public Product Get(int id)
        {
            return db.Product.Find(id);
        }

        public void Create(Product product)
        {
            db.Product.Add(product);
        }

        public void Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Product item = db.Product.Find(id);
            if (item != null)
                db.Product.Remove(item);
        }
    }
}
