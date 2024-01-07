using Ecom_Application.Model_Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom_Application.DAO
{
    internal interface IOrderProcessorRepository
    {
        bool createProduct(Products products);
        bool createCustomer(Customers customers);
        bool deleteProduct(int product_id);
        bool deleteCustomer(int customer_id);
        bool addToCart(Customers customer, Products product, int quantity);
        bool removeFromCart();
        List<Products> getAllFromCart(Customers customer);


        //List<P,T> getOrdersByCustomer(int Customer_id);

    }
}
