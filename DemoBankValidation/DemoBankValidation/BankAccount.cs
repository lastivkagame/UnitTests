using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBankValidation
{
    public class BankAccount
    {
        private string NumberAccount { get; set; }
        public double SumFunds { get; set; }

        public char CurrencySymbol { get; set; }

        /// <summary>
        /// Set all fields
        /// </summary>
        /// <param name="numberAccount"></param>
        /// <param name="sum"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public bool OpenAnAccount(string numberAccount, double sum = 0, char currency = 'G')
        {
            if (numberAccount != "")
            {
                NumberAccount = numberAccount;
                SumFunds = sum;
                CurrencySymbol = currency;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Withdraw\Cash funds from Account
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public bool GetFunds(double sum = 0, char currency = 'G')
        {
            if (currency == CurrencySymbol)
            {
                if (this.SumFunds > 0)
                {
                    if (sum > 0)
                    {
                        if (this.SumFunds > sum)
                        {
                            SumFunds -= sum;
                            return true;
                        }
                    }
                }
                return false;
            }

            return false;
        }

        /// <summary>
        /// Add funds to account
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public bool AddFundsToAccount(double sum = 0, char currency = 'G')
        {
            if (currency == CurrencySymbol)
            {
                if (sum > 0)
                {
                    SumFunds += sum;
                    return true;
                }
                return false;
            }
            return false;
        }


        //public bool FundsTransfer(ref double _otherUser, char _currency, double _yourSumToTransfer) //все те саме просто зміні не треба було б діставати з об'єкта, але більше передавати
        public bool FundsTransfer(ref BankAccount _userToTransfer, double _yourSumToTransfer)
        {
            if (!string.IsNullOrEmpty(this.NumberAccount))
            {
                if (this.SumFunds > 0)
                {
                    if (_yourSumToTransfer > 0)
                    {
                        if (this.SumFunds >= _yourSumToTransfer)
                        {
                            if (_userToTransfer != null)
                            {
                                if (_userToTransfer.CurrencySymbol == this.CurrencySymbol) //якщо задана валюта значить сума теж не null
                                {
                                    this.SumFunds -= _yourSumToTransfer;
                                    _userToTransfer.SumFunds += _yourSumToTransfer;
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}
