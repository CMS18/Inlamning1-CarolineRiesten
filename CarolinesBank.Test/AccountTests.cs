using CarolinesBank.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CarolinesBank.Test
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void CanDeposit()
        {
            // Arrange           
            var id = 1;
            var amount = 34; 
            BankRepository repo = new BankRepository();
            var currentAccount = repo.FindAccount(id);
          
            var expected = currentAccount.Balance + amount;
            // Act
            decimal actualBalance = repo.Deposit(id, amount);
            // Assert

            Assert.AreEqual(expected, actualBalance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CanNotDepositNegative()
        {
            // Arrange           
            var id = 1;
            var amount = -34;
            BankRepository repo = new BankRepository();
            var currentAccount = repo.FindAccount(id);

            var expected = currentAccount.Balance + amount;
            // Act
            decimal actualBalance = repo.Deposit(id, amount);
            // Assert

           //Expects an exeption
        }

        [TestMethod]
        public void CanWithDraw()
        {
            // Arrange           
            var id = 1;
            var amount = 34;
            BankRepository repo = new BankRepository();
            var currentAccount = repo.FindAccount(id);

            var expected = currentAccount.Balance - amount;
            // Act
            decimal actualBalance = repo.WithDraw(id, amount);
            // Assert

            Assert.AreEqual(expected, actualBalance);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CanNotWithDrawNegative()
        {
            // Arrange           
            var id = 1;
            var amount = -34;
            BankRepository repo = new BankRepository();
            var currentAccount = repo.FindAccount(id);

            var expected = currentAccount.Balance - amount;
            // Act
            decimal actualBalance = repo.WithDraw(id, amount);
            // Assert

          // Expects an expcection
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WithDrawBalanceCanNotBeNegative()
        {
            // Arrange           
            var id = 1;
            var amount = 340;
            BankRepository repo = new BankRepository();
            var currentAccount = repo.FindAccount(id);

            var expected = currentAccount.Balance - amount;
            // Act
            decimal actualBalance = repo.WithDraw(id, amount);
            // Assert

           //Expect a expection attribut tillagt
        }
    }
}
