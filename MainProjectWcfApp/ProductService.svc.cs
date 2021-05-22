﻿using BusinessLogics;
using DbModels.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MainProjectWcfApp
{
    public class ProductService : IProjectService<Product>
    {
        private ProductionUnitOfWork db = new ProductionUnitOfWork();

        public IEnumerable<Product> GetAll()
        {
            return db.Product.GetAll();
        }

        public IEnumerable<Product> GetAllInInventory()
        {
            return db.Product.GetAllInInventory();
        }


        public Product Get(int id)
        {
            return db.Product.Get(id);
        }

        public void Create(Product product)
        {
            db.Product.Create(product);
        }

        public void Update(Product product)
        {
            db.Product.Update(product);
        }

        public void Delete(int id)
        {
            db.Product.Delete(id);
        }
    }
}