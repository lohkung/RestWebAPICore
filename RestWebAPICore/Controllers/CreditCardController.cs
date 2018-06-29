using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestWebAPICore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase  
    {
        private readonly CreditCardContext _context;

        public CreditCardController(CreditCardContext context)
        {
            _context = context;

            
        }

        [HttpGet]
        public ActionResult<List<CreditCardItem>> GetAll()
        {
            return _context.CreditCardItems.ToList();
        }

        [HttpGet("{id}", Name = "CheckCreditCard")]
        public ActionResult<CreditCardItem> GetById(int id)
        {
            var item = _context.CreditCardItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet("cardNumber = {cardNumber}/expireDate={expireDate}")]
        public ActionResult<ValidateResult> CheckCreditcard([FromQuery]String cardNumber, [FromQuery]String expireDate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ValidateResult res = new ValidateResult();
            BusinessService bs = new BusinessService();
            Card c = new Card(cardNumber, expireDate);
            //if (!isExist()) // check by proc
            bool test = true;
            if (!test)
            {
                res.result = "Does not exist";
                return res;
            }
            
            return bs.VerifyResult(c);
        }

        
    }
}
