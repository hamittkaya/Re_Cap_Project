﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Contains
{
    public static class Messages
    {
        public static string CarAdded = "Car has been added";
        public static string CarDeleted = "Car has been deleted";
        public static string CarUpdated = "Car has been updated";
        public static string CarNameInvalid = "Car name is invalid";
        public static string MaintenenceTime = "System is under maintenence";
        public static string CarsListed = "Car has been listed";
        public static string UserAdded = "User has been added";
        public static string UserDeleted = "User has been deleted";
        public static string UserUpdated = "User has been updated";
        public static string CustomerUpdated = "Customer has been updated";
        public static string CustomerDeleted = "Customer has been deleted";
        public static string CustomerAdded = "Customer has been added";
        public static string RentalAddedInvalid = "Renting car busing";
        public static string RentalAdded = "Rental car has been added";
        public static string RentalDeleted = "Rental car has been deleted";
        public static string RentalUpdated = "Rental car has been updated";
        public static string RentalUpdatedReturnDateError = "Car received";
        public static string RentalUpdatedReturnDate = "This car isn't rented now";
        public static string CarImageOfLimitExceted="A car can have up to 5 images";
        public static string AuthorizationDenied= "Authorization Denied";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "Password is incorrect";
        public static string SuccessfulLogin = "Login to the system is successful";
        public static string UserAlreadyExists = "This user already exists";
        public static string UserRegistered = "User successfully registered";
        public static string AccessTokenCreated = "Access token created";
    }
}
