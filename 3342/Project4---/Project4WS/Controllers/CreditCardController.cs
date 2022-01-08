using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCreditCard;

namespace Project4WS.Controllers
{
    [Produces("application/json")]
    [Route("api/CreditCard")]
    public class CreditCardController : Controller
    {
        CreditCardManager myManager = new CreditCardManager();
        // GET: api/CreditCard
        [HttpGet]
        public List<CreditCardInfo> Get()
        {
            if (valRequst())
            {

                return myManager.ShowCreditCardInfo();
            }
            else {
                return null;
            }
        }
        

        // GET: api/CreditCard/5
        [HttpGet("transaction/{accountId}", Name = "Get")]
        public List<TransactionInfo> Get(int accountId)
        {
            if (valRequst())
            {
                return myManager.ShowAllTranById(accountId);
            }
            else {
                return null;
            }
        }


        // GET: api/CreditCard/5
        [HttpGet("{acctId}")]
        public CreditCardInfo GetCreditCard(int acctId)
        {
            if (valRequst())
            {
                return myManager.GetCreditCardAcct(acctId);
            }
            else {
                return null;
            }
        }


        // POST: api/CreditCard
        [HttpPost]
        public void Post([FromBody]CreditCardInfo info)
        {
            if (valRequst())
            {
                myManager.MyCreateCardAccount(info.CardNumber, info.CardHolderName, info.CardAddr, info.CardCity, info.CardState, info.CardZipCode, info.CardExpDate, info.CardCvv);
            }
            else {
                 return;
            }
            }



        // POST: api/CreditCard/Payment
        [HttpPost("Payment")]
        public TransactionInfo Payment([FromBody]PaymentInfo info)
        {
            if (valRequst())
            {
                return myManager.CreditCardPayment(info.AccountID, info.TranDate, info.Amount, info.ErrorSsg);
            }
            else {
                return null;

            }
            }




        // PUT: api/CreditCard/5
        [HttpPut("{accountId}")]
        public void Put(int accountId, [FromBody]CreditCardInfo info)
        {
            if (valRequst())
            {
                myManager.UpdateCardInfo(accountId, info.CardNumber, info.CardHolderName, info.CardAddr, info.CardCity, info.CardState, info.CardZipCode, info.CardExpDate, info.CardCvv, info.Val);
          }
            return;
        }


        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }



        private bool valRequst() {
            string key = Request.Headers["apikey"];
            if (key == "ELIE3173")
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
