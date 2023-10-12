namespace CashRegisterTest
{
    using CashRegister;
    using Moq;
    using System;
    using Xunit;

    public class CashRegisterMoqTests
    {
        [Fact]
        public void Should_process_execute_printing()
        {
            //given
            var mockedPrinter = new Mock<Printer>();
            var cashRegister = new CashRegister(mockedPrinter.Object);
            var purchase = new Purchase();
            //when
            cashRegister.Process(purchase);
            //then
            //verify that cashRegister.process will trigger print
            mockedPrinter.Verify(printer => printer.Print(It.IsAny<string>()), Times.Once);
        }
    }
}
