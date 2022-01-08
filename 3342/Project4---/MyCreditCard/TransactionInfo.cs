using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreditCard
{
    public class TransactionInfo
    {
        public int TransactionId { get; set; }
        public int AccountId { get; set;}
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public bool TranReceived { get; set; }
        public string Error { get; set; }

        public TransactionInfo() { }

        public TransactionInfo(int tranId, int accountId, DateTime tranDate, decimal amount, bool tranReceived, string errorSsg) {

            this.TransactionId = tranId;
            this.AccountId = accountId;
            this.TransactionDate = tranDate;
            this.Amount = amount;
            this.TranReceived = tranReceived;
            this.Error = errorSsg;
        }
    }
}
