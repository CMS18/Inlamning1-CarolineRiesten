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
            Assert.AreNotEqual(expected, actualBalance, "failed due to negative amount for deposit");
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

            //Expect a exception attribut tillagt
        }



        [TestMethod]
        public void CanTransferAndBalanceIsCorrect()
        {
            //Arrange
            decimal fromInitialBalance = 100m;
            decimal amount = 50m;
            decimal fromExpectedBalance = 50m;

            decimal toInitialBalance = 100m;
            decimal toExpectedBalance = 150m;

            var fromAccount = new Account { Balance = fromInitialBalance };
            var toAccount = new Account { Balance = toInitialBalance };

            BankRepository repo = new BankRepository();

            //Act
            repo.DepositFromAccount(fromAccount, toAccount, amount);
                       
            decimal fromActualBalance = fromAccount.Balance;
            decimal toActualBalance = toAccount.Balance;

            //Assert
            Assert.AreEqual(fromActualBalance, fromExpectedBalance);
            Assert.AreEqual(toActualBalance, toExpectedBalance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CannotTransferMoreThanBalance()
        {
            //Arrange
            decimal initialBalance = 123.45m;
            decimal amount = 150m;

            var fromAccount = new Account { Balance = initialBalance };
            var toAccount = new Account { Balance = 120 };

            BankRepository repo = new BankRepository();

            //Act
            repo.DepositFromAccount(fromAccount, toAccount, amount);
            decimal actualBalance = fromAccount.Balance;

            //Assert
            Assert.AreEqual(actualBalance, initialBalance);

            //Expects ArgumentOutOfRangeException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CannotTransferNegativeAmount()
        {
            //Arrange
            decimal initialBalance = 123.45m;
            decimal amount = -50m;

            var fromAccount = new Account { Balance = initialBalance };
            var toAccount = new Account { Balance = 120 };

            BankRepository repo = new BankRepository();

            //Act
            repo.DepositFromAccount(fromAccount, toAccount, amount);
            decimal actualBalance = fromAccount.Balance;

            //Assert
            Assert.AreEqual(actualBalance, initialBalance);

            //Expects ArgumentOutOfRangeException
        }
    }
}
