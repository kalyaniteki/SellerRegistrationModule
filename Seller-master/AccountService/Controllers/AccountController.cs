using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountService.GlobalExceptionFilter;
using AccountService.Models;
using AccountService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AccountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
     

        private readonly IAccountRepository _repo;
       // private readonly IConfiguration configuration;
        private readonly ILogger<AccountController> _logger;
        public AccountController(IAccountRepository repo, ILogger<AccountController> logger)
        {
            _repo = repo;
            _logger = logger;
            //this.configuration = configuration;
        }
   
        [HttpPost]
        [Route("registerseller")]
        public IActionResult SellerRegister(Seller seller)
        {
            //try
            //{
            //    _repo.SellerRegister(seller);
            //    return Ok();
            //}
            //catch (Exception e)
            //{
            //    return Ok(e.Message);
            //}

            _logger.LogInformation("Register");

            _repo.SellerRegister(seller);

            _logger.LogInformation($"Succesfully Registered");

            return Ok();
        }
        [HttpGet]
        [Route("SellerLogin/{uname}/{pwd}")]
        //[ProducesResponseType()]
        public IActionResult SellerLogin(string uname, string pwd)
        {


            try {
                _logger.LogInformation("Login");

                Seller b = _repo.ValidateSeller(uname, pwd);
                if(b!=null)
                {
                    return Ok(b);
                }

                _logger.LogInformation($"Welcome {b.Username}");
                return Ok(b);

            }



            catch(MyAppException ex)
            {
                throw ex;
            }
            
            


            //try
            //{
            //    Seller b = _repo.ValidateSeller(uname, pwd);
            //    return Ok(b);
            //}
            //catch (Exception e)
            //{
            //    return Ok(e.Message);
            //}
        }
    }
}