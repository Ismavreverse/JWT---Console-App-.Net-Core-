using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationService.Models
{
    public class JWTContainerModel : IAuthContainerModel
    {
        public string SecretKey { get; set; } = "VmFtc2lLcmlzaG5hS2FsaWRpbmRpQXRUaGVSYXRlT2ZFcGFtRG90Q29tVmFtc2lLcmlzaG5hS2FsaWRpbmRpQXRUaGVSYXRlT2ZFcGFtRG90Q29tVmFtc2lLcmlzaG5hS2FsaWRpbmRpQXRUaGVSYXRlT2ZFcGFtRG90Q29tVmFtc2lLcmlzaG5hS2FsaWRpbmRpQXRUaGVSYXRlT2ZFcGFtRG90Q29tVmFtc2lLcmlzaG5hS2FsaWRpbmRpQXRUaGVSYXRlT2ZFcGFtRG90Q29t"; //length > 128 -- used https://www.base64encode.org/
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;
        public int ExpireMinutes { get; set; } = 10080;
        public Claim[] Claims { get; set; }
    }
}
