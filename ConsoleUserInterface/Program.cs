using Business.Concrete;
using Business.Contains;
using DAL.Concrete.EntityFramework;
using DAL.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUserInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //CarTest2();
            //UserAdd();
            //UserDelete();
            //UserUpdate();
            //SelectByUserId(2);
            //UserList();
            //CustomerAdd();
            //RentAdd();
            //RentDelete();
            RentUpdate();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


            try
            {
                carManager.Add(new Car { Id = 7, CarName = "aa" });
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        private static void CarTest2()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName+ " " + car.BrandName+ " " + car.ColorName+ " " +car.DailyPrice);
            }
        }

        private static void UserAdd()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            Console.Write("Enter firstname: ");
            var firstname = Console.ReadLine();
            Console.Write("Enter lastname: ");
            var lastname = Console.ReadLine();
            Console.Write("Enter email: ");
            var email = Console.ReadLine();
            Console.Write("Enter password: ");
            var password = Console.ReadLine();

            Console.WriteLine("Succesfull");

            userManager.Add(new User() { FirstName = firstname, LastName = lastname, Email = email, Password = password });
        }

        private static void UserDelete()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            
            Console.Write("Please enter the id of the user you want to delete");
            int id = int.Parse(Console.ReadLine());
            userManager.Delete(new User { Id = id });
        }

        private static void UserUpdate()
        {
            UserManager userManager = new UserManager(new EfUserDal());
           
            Console.WriteLine("Plese enter the id of the user you want to update");
            int id = int.Parse(Console.ReadLine());
            var userEntity = userManager.GetById(id).Data;
            Console.WriteLine(userEntity.FirstName + " " + userEntity.LastName + " " + userEntity.Email + " " + userEntity.Password);
            Console.WriteLine("");
            Console.Write("Update the firstname: ");
            userEntity.FirstName = Console.ReadLine();
            Console.Write("Update the lastname: ");
            userEntity.LastName = Console.ReadLine();
            Console.Write("Update the email: ");
            userEntity.Email = Console.ReadLine();
            Console.Write("Update the password: ");

            Console.WriteLine("Successfully");

            userEntity.Password = Console.ReadLine();
            userManager.Update(userEntity);
        }

        private static void SelectByUserId(int userId)
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var user = userManager.GetById(userId).Data;
            Console.WriteLine(user.Id + " " + user.FirstName + " " + user.LastName + " " + user.Email);
        }
        private static void UserList()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.Id + " " + user.FirstName + " " + user.LastName);
            }
        }

        private static void CustomerAdd()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserList();
            Console.Write("Enter the id of the user you want to add as a customer: ");
            var userid = int.Parse(Console.ReadLine());
            Console.Write("Enter the company name: ");
            var companyname = Console.ReadLine();
            customerManager.Add(new Customer() { UserId = userid, CompanyName = companyname });
        }
        private static void CustomerDelete()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Console.Write("Please enter the id of the customer you want to delete: ");
            int id = int.Parse(Console.ReadLine());
            customerManager.Delete(new Customer { Id = id });
        }
        private static void CustomerUpdate()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Console.WriteLine("Please enter the id of the customer you want to updated: ");
            int id = int.Parse(Console.ReadLine());
            var customerEntity = customerManager.GetById(id).Data;
            Console.WriteLine(customerEntity.UserId + " " + customerEntity.CompanyName);
            Console.WriteLine("");
            UserList();
            Console.Write("Update the User Id: ");
            customerEntity.UserId = int.Parse(Console.ReadLine());
            Console.Write("Update the Company name: ");
            customerEntity.CompanyName = Console.ReadLine();
            customerManager.Update(customerEntity);
        }
        private static void SelectByCustomerId(int customerId)
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var customer = customerManager.GetById(customerId).Data;
            Console.WriteLine(customer.Id + " " + "User Id " + customer.UserId + " " + customer.CompanyName);
        }


        public static void RentAdd()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //UserList();
            Console.Write("Enter the id of the user you want to add as a carId: ");
            var carId = int.Parse(Console.ReadLine());
            rentalManager.Add(new Rental() { CarId = carId,  RentDate= DateTime.Now ,ReturnDate=DateTime.Now });

        }

        public static void RentDelete()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.Write("Enter the id of the user you want to delete as a carId: ");
            var id = int.Parse(Console.ReadLine());
            rentalManager.Delete(new Rental { Id =id});
        }

        private static void RentUpdate()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine("RentId of the data you want to update: ");
            int id = int.Parse(Console.ReadLine());
            var rentalEntity = rentalManager.GetById(id).Data;
            Console.WriteLine(rentalEntity.CarId + " " + rentalEntity.CustomerId + " " + rentalEntity.RentDate + " " + rentalEntity.ReturnDate);
            Console.WriteLine("");
            Console.Write("Update Car Id: ");
            rentalEntity.CarId = int.Parse(Console.ReadLine());
            Console.Write("Update Customer Id: ");
            rentalEntity.CustomerId = int.Parse(Console.ReadLine());
            Console.Write("Update Rent Date: ");
            rentalEntity.RentDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Update the delivery date. Leave blank if it is not delivered:  ");
            rentalEntity.ReturnDate = DateTime.Parse(Console.ReadLine());
            rentalManager.Update(rentalEntity);
        }

        public static void RentUpdateReturn()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.Write("Enter the id of the user you want to delete as a carId: ");
            var id = int.Parse(Console.ReadLine());
            rentalManager.UpdateReturnDate(id);
        }
    }
}
