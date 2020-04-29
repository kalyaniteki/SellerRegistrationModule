using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountService.Models;
using AccountService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AccountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _repo;
        private readonly IConfiguration configuration;

        public AccountController(IAccountRepository repo, IConfiguration configuration)
        {
            _repo = repo;
            this.configuration = configuration;
        }
        [HttpPost]
        [Route("REGISTER-SELLER")]
        public IActionResult SellerRegister(Seller buyer)
        {
            try
            {
                _repo.SellerRegister(buyer);
                return Ok();
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [HttpGet]
        [Route("SellerLogin/{uname},{pwd}")]
        public IActionResult SellerLogin(string uname, string pwd)
        {
            try
            {
                Seller b = _repo.ValidateSeller(uname, pwd);
                return Ok(b);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
    }
}