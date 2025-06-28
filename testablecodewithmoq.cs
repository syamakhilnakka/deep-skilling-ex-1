using System;
using System.Net;
using System.Net.Mail;
using Moq;
using NUnit.Framework;

namespace CustomerCommDemo
{
    // Define the mail sender interface
    public interface IMailSender
    {
        bool SendMail(string toAddress, string message);
    }

    // Implementation of mail sender
    public class MailSender : IMailSender
    {
        public bool SendMail(string toAddress, string message)
        {
            Console.WriteLine($"Pretend email sent to {toAddress} with message: {message}");
            return true;
        }
    }

    // Class that depends on the IMailSender interface
    public class CustomerComm
    {
        private readonly IMailSender _mailSender;

        public CustomerComm(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public bool SendMailToCustomer()
        {
            return _mailSender.SendMail("cust123@abc.com", "Some Message");
        }
    }

    // Unit test class using Moq and NUnit
    [TestFixture]
    public class CustomerCommTests
    {
        [Test]
        public void SendMailToCustomer_WhenCalled_ReturnsTrue()
        {
            // Arrange
            var mockSender = new Mock<IMailSender>();
            mockSender.Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var customerComm = new CustomerComm(mockSender.Object);

            // Act
            bool result = customerComm.SendMailToCustomer();

            // Assert
            Assert.IsTrue(result);
        }

        // Optional Main() for manual test
        public static void Main()
        {
            var mockSender = new Mock<IMailSender>();
            mockSender.Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var customerComm = new CustomerComm(mockSender.Object);
            bool result = customerComm.SendMailToCustomer();

            Console.WriteLine($"SendMailToCustomer returned: {result}");
        }
    }
}
