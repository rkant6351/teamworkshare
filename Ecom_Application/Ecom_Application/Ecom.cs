using Ecom_Application.DAO;
using Ecom_Application.Model_Classes;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace Ecom_Application
{
    internal class Ecom
    {
        static void Main(string[] args)
        {
            int x = services();
            Console.WriteLine("Welcome to Ecom Application");
            Console.WriteLine("Enter 1 To Register Customer");
            Console.WriteLine("Enter 2 To Create Product");
            Console.WriteLine("Enter 3 To Delete Product");
            Console.WriteLine("Enter 4 To Add to cart");
            Console.WriteLine("Enter 5 To View Cart");
            Console.WriteLine("Enter 6 To Place Order");
            Console.WriteLine("Enter 7 To View Customer order");
            int a = int.Parse(Console.ReadLine());

            switch (x)
            {
                case 1:Customers regcustomers = new Customers();
                    Console.WriteLine("Welcome to Customers Registration Portal");
                    Console.WriteLine("Enter Customer name");
                    regcustomers.Name=Console.ReadLine();
                    Console.WriteLine("Enter Customer Email");
                    regcustomers.Email=Console.ReadLine();
                    Console.WriteLine("Enter Password");
                    regcustomers.Password=Console.ReadLine();
                    IOrderProcessorRepository customerregistration = new OrderProcessorRepositoryImpl();
                    bool registration= customerregistration.createCustomer(regcustomers);
                    if (registration == true)
                    {
                        Console.WriteLine("Customer Registered");
                    }
                    else
                    {
                        Console.WriteLine("Customer Cannot be registered");
                    }
                    
                    break;

                case 2:Products addproduct = new Products();
                    Console.WriteLine("Welcome to product entry portal");
                    Console.WriteLine("Enter Product name");
                    addproduct.name = Console.ReadLine();
                    Console.WriteLine("Enter Product price");
                    addproduct.price = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Product Description");
                    addproduct.description = Console.ReadLine();
                    Console.WriteLine("Enter Stock Quantity");
                    addproduct.stockQuantity=int.Parse(Console.ReadLine());
                    IOrderProcessorRepository productaddition = new OrderProcessorRepositoryImpl();
                    bool product_addition = productaddition.createProduct(addproduct);
                    if (product_addition == true)
                    {
                        Console.WriteLine("Product Added");
                    }
                    else
                    {
                        Console.WriteLine("Product Already Exist");
                    }
                    break;


                case 3:Products deleteproduct = new Products();
                    Console.WriteLine("Enter product id of the product that you want to Delete");
                    deleteproduct.product_id = int.Parse(Console.ReadLine());
                    IOrderProcessorRepository productdeletion = new OrderProcessorRepositoryImpl();
                    bool productdeleted = productdeletion.deleteProduct(deleteproduct.product_id);
                    if (productdeleted == true)
                    {
                        Console.WriteLine("Product Deleted");
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid Product id");
                    }
                    break;

                case 4:
                    try
                    {
                        Customers addcartcustomer = new Customers();
                        Console.WriteLine("Enter Customer id");
                        addcartcustomer.Customer_id = int.Parse(Console.ReadLine());
                        Products addcartproduct = new Products();
                        Console.WriteLine("Enter Product id");
                        addcartproduct.product_id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Quantity");
                        int quantity = int.Parse(Console.ReadLine());
                        IOrderProcessorRepository addtocart = new OrderProcessorRepositoryImpl();
                        bool addedtocart = addtocart.addToCart(addcartcustomer, addcartproduct, quantity);
                        if (addedtocart == true)
                        {
                            Console.WriteLine("Added to cart");
                        }
                        else
                        {
                            Console.WriteLine("Either customer doesnot exist or product not available");
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadKey();
                   break;
                    
                    

                case 5:
                    break;

                case 6: 
                    break;
                case 7: 
                    break;


                default: Console.WriteLine("Please Enter a valid Choice");
                    break;
            }


            Console.ReadLine();
        }
        public static int services()
        {
            Console.WriteLine("Welcome to Ecom Application");
            Console.WriteLine("Enter 1 To Register Customer");
            Console.WriteLine("Enter 2 To Create Product");
            Console.WriteLine("Enter 3 To Delete Product");
            Console.WriteLine("Enter 4 To Add to cart");
            Console.WriteLine("Enter 5 To View Cart");
            Console.WriteLine("Enter 6 To Place Order");
            Console.WriteLine("Enter 7 To View Customer order");
            int a = int.Parse(Console.ReadLine());

            return a;
        }

    }
}
