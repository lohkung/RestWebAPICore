using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("{id}")]
        public ActionResult<CreditCardItem> GetById(int id)
        {
            var item = _context.CreditCardItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        
        [HttpGet("{cardNumber}/{expireDate}")]
        public ActionResult<ValidateResult> CheckCreditcard([FromRoute]String cardNumber, [FromRoute]String expireDate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ValidateResult res = new ValidateResult();
            BusinessService bs = new BusinessService();
            Card c = new Card(cardNumber, expireDate);
            var paramCardNumber = new SqlParameter("@CardNumber", cardNumber);
            List<CreditCardItem> CreditCardItems = _context.CreditCardItems.FromSql("GetOfCreditCards @CardNumber", paramCardNumber).ToList();

            int cnt = CreditCardItems.Count();
            if (cnt == 0)
            {
                res.result = "Does not exist";
                return res;
            }

            /*
            foreach (var item in CreditCardItems)
            {

            }
            */
            


            return bs.VerifyResult(c);
        }


    }
}
