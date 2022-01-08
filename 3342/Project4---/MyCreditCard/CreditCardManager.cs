using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace MyCreditCard
{
    public class CreditCardManager
    {
        DBConnect myObj = new DBConnect();

        ////////////////////////////////////////////////////////////
        public void MyCreateCardAccount(String cardNumber, String cardHolderName, String cardAddr, String cardCity, String cardState, String cardZipCode, DateTime cardExpDate, String cardCvv)
        {
            SqlCommand createCardAccountCmd = new SqlCommand("CreateCreditCardAccount");
            createCardAccountCmd.CommandType = CommandType.StoredProcedure;
            createCardAccountCmd.Parameters.AddWithValue("@cardNumber", cardNumber);
            createCardAccountCmd.Parameters.AddWithValue("@cardHolderName", cardHolderName);
            createCardAccountCmd.Parameters.AddWithValue("@cardAddr", cardAddr);
            createCardAccountCmd.Parameters.AddWithValue("@cardCity", cardCity);
            createCardAccountCmd.Parameters.AddWithValue("@cardState", cardState);
            createCardAccountCmd.Parameters.AddWithValue("@cardZipCode", cardZipCode);
            createCardAccountCmd.Parameters.AddWithValue("@expDate", cardExpDate);
            createCardAccountCmd.Parameters.AddWithValue("@cvv", cardCvv);

            myObj.DoUpdateUsingCmdObj(createCardAccountCmd);
        }

        ////////////////////////////////////////////////
        public void UpdateCardInfo(int accountId, String cardNumber, String cardHolderName, String cardAddr, String cardCity, String cardState, String cardZipCode, DateTime cardExpDate, String cardCvv, bool val)
        {

            SqlCommand updateCardInfoCmd = new SqlCommand("updateCreditCard");
            updateCardInfoCmd.CommandType = CommandType.StoredProcedure;
            updateCardInfoCmd.Parameters.AddWithValue("@accountId", accountId);
            updateCardInfoCmd.Parameters.AddWithValue("@cardNumber", cardNumber);
            updateCardInfoCmd.Parameters.AddWithValue("@cardHolderName", cardHolderName);
            updateCardInfoCmd.Parameters.AddWithValue("@cardAddr", cardAddr);
            updateCardInfoCmd.Parameters.AddWithValue("@cardCity", cardCity);
            updateCardInfoCmd.Parameters.AddWithValue("@cardState", cardState);
            updateCardInfoCmd.Parameters.AddWithValue("@cardZipCode", cardZipCode);
            updateCardInfoCmd.Parameters.AddWithValue("@expDate", cardExpDate);
            updateCardInfoCmd.Parameters.AddWithValue("@cvv", cardCvv);
            updateCardInfoCmd.Parameters.AddWithValue("@val", val);

            myObj.DoUpdateUsingCmdObj(updateCardInfoCmd);
        }


        public TransactionInfo CreditCardPayment(int accountId, DateTime tranDate, decimal amount, string errorSsg)
        {
            bool tranReceived = true;

            SqlCommand paymentCmd = new SqlCommand("creditPayment");
            paymentCmd.CommandType = CommandType.StoredProcedure;
            paymentCmd.Parameters.AddWithValue("@accountId", accountId);
            paymentCmd.Parameters.AddWithValue("@amount", amount);
            paymentCmd.Parameters.AddWithValue("@tranReceived", tranReceived);
            paymentCmd.Parameters.AddWithValue("@errorSsg", errorSsg);

            SqlParameter myTran = new SqlParameter("@tranId", SqlDbType.Int);
            myTran.Direction = ParameterDirection.ReturnValue;
            paymentCmd.Parameters.Add(myTran);

            myObj.DoUpdateUsingCmdObj(paymentCmd);

            int tranId = Convert.ToInt32(myTran.Value);
            TransactionInfo getTran = GetTransaction(tranId);
            return getTran;
        }


        public List<CreditCardInfo> ShowCreditCardInfo()
        {
            SqlCommand showInfoCmd = new SqlCommand("showCreditCardInfo");
            showInfoCmd.CommandType = CommandType.StoredProcedure;
            DataSet cardInfoDS = myObj.GetDataSetUsingCmdObj(showInfoCmd);
            List<CreditCardInfo> cardList = new List<CreditCardInfo>();

            for (int i = 0; i < cardInfoDS.Tables[0].Rows.Count; i++)
            {
                CreditCardInfo listCardInfo = new CreditCardInfo(
                    Convert.ToInt32(myObj.GetField("Account_ID", i)),
                    myObj.GetField("Card_Number", i).ToString(),
                    myObj.GetField("name", i).ToString(),
                    myObj.GetField("address", i).ToString(),
                    myObj.GetField("city", i).ToString(),
                    myObj.GetField("state", i).ToString(),
                    myObj.GetField("zipCode", i).ToString(),
                    DateTime.Parse(myObj.GetField("expDate", i).ToString()),
                    myObj.GetField("cvv", i).ToString());
                listCardInfo.Val = Convert.ToBoolean(myObj.GetField("val", i));
                cardList.Add(listCardInfo);
            }
            return cardList;
        }

        public TransactionInfo GetTransaction(int tranId)
        {
            SqlCommand tranCmd = new SqlCommand("getTransacion");
            tranCmd.CommandType = CommandType.StoredProcedure;
            tranCmd.Parameters.AddWithValue("@tranId", tranId);

            DataSet tranDS = myObj.GetDataSetUsingCmdObj(tranCmd);

            TransactionInfo listTranInfo = new TransactionInfo(
                Convert.ToInt32(myObj.GetField("transaction_ID", 0)),
                Convert.ToInt32(myObj.GetField("Account_ID", 0)),
                DateTime.Parse(myObj.GetField("transactionDate", 0).ToString()),
                Convert.ToDecimal(myObj.GetField("amount", 0)),
                Convert.ToBoolean(myObj.GetField("tranReceived", 0)),
                myObj.GetField("error", 0).ToString()
                );
            return listTranInfo;
        }
        

        public List<TransactionInfo> ShowAllTranById(int AccountId)
        {
            SqlCommand allTranCmd = new SqlCommand("getAllTransactionById");
            allTranCmd.CommandType = CommandType.StoredProcedure;
            allTranCmd.Parameters.AddWithValue("@accountId", AccountId);
            DataSet allTranDS = myObj.GetDataSetUsingCmdObj(allTranCmd);
            List<TransactionInfo> allTranList = new List<TransactionInfo>();

            for (int i = 0; i < allTranDS.Tables[0].Rows.Count; i++)
            {
                TransactionInfo allTranInfo = new TransactionInfo(

                Convert.ToInt32(myObj.GetField("transaction_ID", i)),
                Convert.ToInt32(myObj.GetField("Account_ID", i)),
                DateTime.Parse(myObj.GetField("transactionDate", i).ToString()),
                Convert.ToDecimal(myObj.GetField("amount", i)),
                Convert.ToBoolean(myObj.GetField("tranReceived", i)),
                myObj.GetField("error", i).ToString()
                );
                allTranList.Add(allTranInfo);
            }
            return allTranList;
        }


        public CreditCardInfo GetCreditCardAcct(int acctId)
        {
            SqlCommand getCardAcct = new SqlCommand("getCreditCardAcct");
            getCardAcct.CommandType = CommandType.StoredProcedure;
            getCardAcct.Parameters.AddWithValue("@accountId", acctId);
            DataSet cardInfoDS = myObj.GetDataSetUsingCmdObj(getCardAcct);

            if (cardInfoDS.Tables[0].Rows.Count == 1)
            {
                CreditCardInfo listCardInfo = new CreditCardInfo(
                Convert.ToInt32(myObj.GetField("Account_ID", 0)),
                myObj.GetField("Card_Number", 0).ToString(),
                myObj.GetField("name", 0).ToString(),
                myObj.GetField("address", 0).ToString(),
                myObj.GetField("city", 0).ToString(),
                myObj.GetField("state", 0).ToString(),
                myObj.GetField("zipCode", 0).ToString(),
                DateTime.Parse(myObj.GetField("expDate", 0).ToString()),
                myObj.GetField("cvv", 0).ToString());
                listCardInfo.Val = Convert.ToBoolean(myObj.GetField("val", 0));
                return listCardInfo;
            }
            return null;
        }
    }
}