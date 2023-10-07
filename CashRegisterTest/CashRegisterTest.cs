namespace CashRegisterTest
{
    using System;
    using CashRegister;
    using Moq;
    using Xunit;

    public class CashRegisterTest
    {
        [Fact]
        public void Should_process_execute_printing()
        {
            //given
            var printer = new Mock<IPrinter>();
            CashRegister cashRegister = new CashRegister(printer.Object);
            Purchase purchase = new Purchase();

            //when
            cashRegister.Process(purchase);

            //then
            printer.Verify(p => p.Print(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public void Printed_content_should_be_from_the_processed_purchase()
        {
            //given
            var printer = new Mock<IPrinter>();
            var cashRegister = new CashRegister(printer.Object);
            var purchase = new Purchase();

            //when
            cashRegister.Process(purchase);

            //then
            printer.Verify(p => p.Print(It.Is<string>(content => content.Contains("content"))), Times.Once());
        }

        [Fact]
        public void Process_should_throw_the_specified_exception_if_the_printer_is_out_of_paper()
        {
            //given
            var printer = new Mock<IPrinter>();
            printer.Setup(p => p.Print(It.IsAny<string>())).Throws<PrinterOutOfPaperException>();
            var cashRegister = new CashRegister(printer.Object);
            var purchase = new Purchase();

            //when
            Action act = () => cashRegister.Process(purchase);

            //then
            var hardwareException = Assert.Throws<HardwareException>(act);
            Assert.Equal("Printer is out of paper.", hardwareException.Message);
        }
    }
}
