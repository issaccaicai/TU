using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreditCard
{
    public class CreditCardInfo
    {
        public int AccountID { get; set; }
        public String CardNumber { get; set; }
        public String CardHolderName { get; set; }
        public String CardAddr { get; set; }
        public String CardCity { get; set; }
        public String CardState { get; set; }
        public String CardZipCode { get; set; }
        public DateTime CardExpDate { get; set; }
        public String CardCvv { get; set; }
        public bool Val { get; set; }

        public CreditCardInfo()
        {
            this.Val = true;
        }

        public CreditCardInfo(int accountId, String cardNumber, String cardHolderName, String cardAddr, String cardCity, String cardState, String cardZipCode, DateTime cardExpDate, String cardCvv)
        {
            this.AccountID = accountId;
            this.CardNumber = cardNumber;
            this.CardHolderName = cardHolderName;
            this.CardAddr = cardAddr;
            this.CardCity = cardCity;
            this.CardState = cardState;
            this.CardZipCode = cardZipCode;
            this.CardExpDate = cardExpDate;
            this.CardCvv = cardCvv;
            this.Val = true;
        }
    }
}
