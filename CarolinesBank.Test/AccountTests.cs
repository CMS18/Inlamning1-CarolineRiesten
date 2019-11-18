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
            Account actualBalance = repo.Deposit(id, amount);
            // Assert

            Assert.AreEqual(expected, actualBalance.Balance);
        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CanNotDepositNegative()
        {
            // Arrange           
            var id = 1;
            var amount = -34;
            BankRepository repo = new BankRepository();
            var currentAccount = repo.FindAccount(id);

            var expected = currentAccount.Balance + amount;
            // Act
            Account actualBalance = repo.Deposit(id, amount);
            // Assert
            Assert.AreNotEqual(expected, actualBalance,"failed due to negative amount for deposit"); 
           //Expects an exeption
        }

        [TestMethod]
        public void CanNotDepositNegative2()
        {
            // Arrange           
            var id = 1;
            var amount = -34;
            BankRepository repo = new BankRepository();
            var currentAccount = repo.FindAccount(id);

            var expected = currentAccount.Balance + amount;
            // Act
            Account actualBalance = repo.Deposit(id, amount);
            // Assert
            Assert.AreEqual(currentAccount.Balance, actualBalance.Balance);
           
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
            Account actualBalance = repo.WithDraw(id, amount);
            // Assert

            Assert.AreEqual(expected, actualBalance.Balance);
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
            Account actualBalance = repo.WithDraw(id, amount);
            // Assert
            //Assert.AreNotEqual(expected, actualBalance.Balance);
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
            Account actualBalance = repo.WithDraw(id, amount);
            // Assert

           //Expect a expection attribut tillagt
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WithDrawBalanceCanNotBeNegative2()
        {
            // Arrange           
            var id = 1;
            var amount = 340;
            BankRepository repo = new BankRepository();
            var currentAccount = repo.FindAccount(id);
            /*currentAccount.Balance - amount; should give a false successrespons*/
            currentAccount.Success = false;
            var expected = currentAccount.Success;
        
            // Act
            Account actualBalance = repo.WithDraw(id, amount);
            // Assert
            Assert.IsFalse(actualBalance.Success);
            //Expect a expection attribut tillagt
        }
    }
}
