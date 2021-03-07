using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car added";
        public static string CarNameAndDailyPriceInvalid = "Car Name minimum lenght must be greater than 2 characters and Daily Price must be greater than 0";
        public static string CarDeleted = "Car deleted";
        public static string CarUpdated = "Car Updated";
        public static string BrandAdded = "Brand added";
        public static string BrandDeleted = "Brand deleted";
        public static string BrandUpdated = "Brand updated";
        public static string ColordAdded = "Color added";
        public static string ColorDeleted = "Color deleted";
        public static string ColorUpdated = "Color updated";
        public static string AllCarsListed = "All cars listed";
        public static string AllBrandsListed = "All brands listed";
        public static string AllColorsListed = "All colors listed";
        public static string UserAdded = "User added";
        public static string UserDeleted = "User deleted";
        public static string AllUsersListed = "All users listed";
        public static string UserUpdated = "User updated";
        public static string CustomerAdded = "Customer added";
        public static string CustomerDeleted = "Customer deleted";
        public static string AllCustomersListed = "All customers listed";
        public static string CustomerUpdated = "Customer updated";
        public static string RentalAdded = "Rental added";
        public static string RentalDeleted = "Rental deleted";
        public static string AllRentalsListed = "All rentals listed";
        public static string RentalUpdated = "Rental updated";
        public static string ErrorCarReturnDate = "Delivery date has not come";
        public static string ErrorCar = "Car can not be found";
        public static string CarImageAdded = "Car image added";
        public static string CarImageDeleted = "Car image deleted";
        public static string AllCarImagesListed = "All car images listed";
        public static string CarImageUpdated = "Car image updated";
        public static string CarImageCountExcededError = "There cannot be more than 5 pictures of a car";
        public static string AllCarImagesListedByCarId = "All car images listed by car id";
        public static string AuthorizationDenied = "You don't have authorization";
        public static string AllClaimsListed = "All claims listed";
        public static string UserRegistered = "Registered";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "Password is incorrect";
        public static string SuccessfulLogin = "Successful login";
        public static string UserAlreadyExists = "User already exists";
        public static string AccessTokenCreated = "Token created";
        internal static string UsersListed;
        internal static string UserListedById;
    }
}
