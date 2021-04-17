using DemoBankValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator.Tests
{
    [TestClass]
    public class ValidateTests
    {
        private BankAccount _validatorClient1;
        private BankAccount _validatorClient2;

        [TestInitialize]
        public void Setup()
        {
            _validatorClient1 = new BankAccount();
            _validatorClient2 = new BankAccount();
        }

        [TestMethod]
        public void FundsTransferIsSenderAccountNull()
        {
            _validatorClient2.OpenAnAccount("test2", 100);

            var resalt = _validatorClient1.FundsTransfer(ref _validatorClient2, 50);

            Assert.IsFalse(resalt);
        }

        [TestMethod]
        public void FundsTransferIsSenderAccountSumLessThanNull()
        {
            _validatorClient1.OpenAnAccount("test1", -100);
            _validatorClient2.OpenAnAccount("test2", 100);

            var resalt = _validatorClient1.FundsTransfer(ref _validatorClient2, 50);

            Assert.IsFalse(resalt);
        }

        [TestMethod]
        public void FundsTransferIsSenderAccountSumLessThanSumToTransfer()
        {
            _validatorClient1.OpenAnAccount("test1", 100);
            _validatorClient2.OpenAnAccount("test2", 50);

            var resalt = _validatorClient1.FundsTransfer(ref _validatorClient2, 500);

            Assert.IsFalse(resalt);
        }

        [TestMethod]
        public void FundsTransferIsSumToTransferLessThanNull()
        {
            _validatorClient1.OpenAnAccount("test1", 200);
            _validatorClient2.OpenAnAccount("test2", 100);

            var resalt = _validatorClient1.FundsTransfer(ref _validatorClient2, -50);

            Assert.IsFalse(resalt);
        }

        [TestMethod]
        public void FundsTransferIsRecipientAccountNull()
        {
            _validatorClient1.OpenAnAccount("test1", 100);
            _validatorClient2 = null;

            var resalt = _validatorClient1.FundsTransfer(ref _validatorClient2, 50);

            Assert.IsFalse(resalt);
        }

        [TestMethod]
        public void FundsTransferIsSenderCurrencyEquelRecipientCurrency()
        {
            _validatorClient1.OpenAnAccount("test1", 300, 'E');
            _validatorClient2.OpenAnAccount("test2", 100, '$');

            var resalt = _validatorClient1.FundsTransfer(ref _validatorClient2, 50);

            Assert.IsFalse(resalt);
        }
    }
}
