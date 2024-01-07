using Ecom_Application.Model_Classes;
using Ecom_Application.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ecom_Application.DAO
{
    internal class OrderProcessorRepositoryImpl : IOrderProcessorRepository
    {
        SqlConnection conn;

        public bool addToCart(Customers customer, Products product, int quantity)
        {
            conn = DBConnection.GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            conn.Open();
            cmd.CommandText = $"insert into cart(customer_id,product_id,quantity) values({customer.Customer_id},{product.product_id},{quantity})";
            try
            {
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                conn.Close();
                return false;
            }
        }

        public bool createCustomer(Customers customers)
        {
            conn = DBConnection.GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            conn.Open();
            cmd.CommandText = $"insert into customers(Name,email,password) values('{customers.Name}','{customers.Email}','{customers.Password}')";
            try
            {
                cmd.ExecuteNonQuery();
                cmd.CommandText = $"select customer_id from customers where Name like '{customers.Name}' and email like '{customers.Email}' and password like '{customers.Password}'";
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                Console.WriteLine($"\n\nYou have been allocated a Customer_id Kindly note it down\n\n\nCustomerid={reader[0]}\n\n");
                return true;
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e.Message);
                return false;
            } 
            finally
            {
                conn.Close();
            }
        }

        public bool createProduct(Products products)
        {
            conn = DBConnection.GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            conn.Open();
            cmd.CommandText = $"insert into products(Name,Price,description,stockQuantity) values('{products.name}','{products.price}','{products.description}',{products.stockQuantity})";
            try
            {
                cmd.ExecuteNonQuery();
                cmd.CommandText = $"select Product_id from products where Name like '{products.name}' and price= {products.price} and description like '{products.description}' and stockQuantity={products.stockQuantity}";
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                Console.WriteLine($"\n\nYour have been allocated a Product id Kindly note it down\n\n\nproduct id={reader[0]}\n\n");
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                conn.Close();
                return false;
            }
        }

        public bool deleteCustomer(int customer_id)
        {
            conn = DBConnection.GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            conn.Open();
            cmd.CommandText = $"Delete from customers where customer_id={customer_id}";
            try
            {
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                conn.Close();
                return false;
            }
        }

        public bool deleteProduct(int product_id)
        {
            conn = DBConnection.GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            conn.Open();
            cmd.CommandText = $"Delete from products where product_id={product_id}";
            try 
            {
                int roweffcted=cmd.ExecuteNonQuery();
                if(roweffcted > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

        }

        public List<Products> getAllFromCart(Customers customer)
        {
            throw new NotImplementedException();
        }

        public bool removeFromCart()
        {
            throw new NotImplementedException();
        }
    }
}
