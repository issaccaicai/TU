using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreditCard
{
    public class PaymentInfo
    {
        public int AccountID { get; set; }
        public DateTime TranDate { get; set; }
        public decimal Amount { get; set; }
        public bool TranReceived { get; set; }
        public string ErrorSsg { get; set; }


        public PaymentInfo(int accountId, DateTime tranDate, decimal amount, string errorSsg) {
            this.AccountID = accountId;
            this.TranDate = tranDate;
            this.Amount = amount;
            this.ErrorSsg = errorSsg;
        }
    }
}
