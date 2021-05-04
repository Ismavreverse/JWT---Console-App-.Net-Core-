using AuthenticationService.Managers;
using AuthenticationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace AuthenticationService
{
    class Program
    {
        static void Main(string[] args)
        {
            IAuthContainerModel authContainerModel = GetJWTContainerModel("Vamsi Kalidindi","kalidindivamsikrishna@gmail.com","Admin","+91 9666358224");
            IAuthService authService = new JWTService(authContainerModel.SecretKey);

            //string token = authService.GenerateToken(authContainerModel);
            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiVmFtc2kgS2FsaWRpbmRpIiwiZW1haWwiOiJrYWxpZGluZGl2YW1zaWtyaXNobmFAZ21haWwuY29tIiwicm9sZSI6IkFkbWluIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbW9iaWxlcGhvbmUiOiI5NjY2MzU4MjQ0IiwibmJmIjoxNjE1OTgyMjIyLCJleHAiOjE2MTY1ODcwMjIsImlhdCI6MTYxNTk4MjIyMn0.yElOPO7iPFMRtnilFIXgtykIdUd_6lyUgAq1Fxr0HYk";
            if (!authService.IsTokenValid(token))
            {
                token = authService.GenerateToken(authContainerModel);
                Console.WriteLine("Invalid Token");
                Console.WriteLine("New token is : " + token);
            }
            else
            {
                List<Claim> claims = authService.GetTokenClaims(token).ToList();

                Console.WriteLine(claims.FirstOrDefault(a => a.Type.Equals(ClaimTypes.Name)).Value);
                Console.WriteLine(claims.FirstOrDefault(a => a.Type.Equals(ClaimTypes.Email)).Value);
                Console.WriteLine(claims.FirstOrDefault(a => a.Type.Equals(ClaimTypes.Role)).Value);
                Console.WriteLine(claims.FirstOrDefault(a => a.Type.Equals(ClaimTypes.MobilePhone)).Value);
                Console.WriteLine("Current Token is : " + token);
            }
        }

        private static JWTContainerModel GetJWTContainerModel(string name, string email, string role, string mobileNumber)
        {
            return new JWTContainerModel()
            {
                Claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, role),
                    new Claim(ClaimTypes.MobilePhone, mobileNumber)
                }
            };
        }
    }


}
