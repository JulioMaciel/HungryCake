using System;
using System.Collections.Generic;
using System.Linq;
using HungryCake.API.Data;
using HungryCake.API.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace HungryCakeApp.API.Data
{
    public class Seed
    {
        // private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ICakeRepository _repo;


        public Seed(UserManager<User> userManager, RoleManager<Role> roleManager, ICakeRepository repo)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            // _context = context;
            _repo = repo;
        }

        public void SeedUsers()
        {
            if (_userManager.Users.Any())
                return;

            var roles = new List<Role>
            {
                new Role { Name = "Member"},
                new Role { Name = "Admin"},
            };

            foreach (var role in roles)
            {
                _roleManager.CreateAsync(role).Wait();
            }

            var adminUser = new User
            {
                UserName = "Admin"
            };

            IdentityResult result = _userManager.CreateAsync(adminUser, "passw0rd").Result;

            if (result.Succeeded)
            {
                var admin = _userManager.FindByNameAsync("Admin").Result;
                _userManager.AddToRolesAsync(admin, new[] { "Admin" }).Wait();
            }            
        }

        public void SeedCategory()
        {
            var cat = new Category();
            cat.English = "General";
            cat.Portuguese = "Geral";

            _repo.Add(cat);
            _repo.SaveAll();
        }
    }
}