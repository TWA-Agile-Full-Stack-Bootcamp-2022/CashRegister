using System;
using System.Runtime.CompilerServices;
using Moq;

namespace CashRegisterTest
{
    using CashRegister;
    using Xunit;

    public class CashRegisterTest
    {
        [Fact]
        public void Should_process_execute_printing()
        {
            //given
            var printer = new Mock<IPrinter>();
            var cashRegister = new CashRegister(printer.Object);
            var purchase = new Purchase();
            //when
            cashRegister.Process(purchase);
            //then
            printer.Verify(p => p.Print(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public void Should_process_execute_printing_with_the_content_from_the_processed_Purchase()
        {
            //given
            var printer = new Mock<IPrinter>();
            var cashRegister = new CashRegister(printer.Object);
            var purchase = new Purchase();
            //when
            cashRegister.Process(purchase);
            //then
            printer.Verify(p => p.Print(It.Is<string>(content => content.StartsWith("content"))), Times.Once());
        }

        [Fact]
        public void Should_throw_HardwareException_when_process_given_out_of_paper_printer()
        {
            //given
            var printer = new MockOutOfPaperPrinter();
            var cashRegister = new CashRegister(printer);
            var purchase = new Purchase();
            //when
            Action act = () => cashRegister.Process(purchase);
            //then
            var hardwareException = Assert.Throws<HardwareException>(act);
            Assert.Equal("Printer is out of paper.", hardwareException.Message);
        }
    }
}