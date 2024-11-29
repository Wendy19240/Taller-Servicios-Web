using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductLogical
    {
     public ProductLogical Create(ProductLogical newProduct)
        {
            ProductLogical Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                ProductLogical res =
                    r.Retrieve<Products>(
                        p => p.ProductName == newProduct.ProductName);
                if (res != null)
                {
                    Result = r.Create(newProduct);
                }
                else
                {
                    //podriamos lanzar una execpcion
                    //para notificae que el produxto ya existe 
                    //podrimos incluso crear una capa de Excepciones
                    //personalizadas y consumirla desde otras capas
                }
            }
        }
    }
}

