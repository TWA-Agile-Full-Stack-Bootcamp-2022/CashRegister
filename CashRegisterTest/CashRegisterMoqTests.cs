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

        [Fact]
        public void Should_pass_the_purchase_info_to_printer_by_given_Purchase_Object()
        {
            // given
            var mockedPrinter = new Mock<Printer>();
            var cashRegister = new CashRegister(mockedPrinter.Object);

            const string givenPurchaseInfo = "Some Given Purchase infomation";
            //StubPurchase strubPurchase = new StubPurchase();
            //strubPurchase.WhenAsStringThenReturn(givenPurchaseInfo);

            var mockedPurchase = new Mock<Purchase>();
            mockedPurchase.Setup(purchase => purchase.AsString()).Returns(givenPurchaseInfo);

            // when
            cashRegister.Process(mockedPurchase.Object);
            // then
            mockedPrinter.Verify(printer => printer.Print(givenPurchaseInfo), Times.Once);
            //Assert.Equal(givenPurchaseInfo, mockedPrinter.PrintContentRecived);
        }

        [Fact]
        public void Should_throw_HardwareException_given_printer_is_out_of_paper()
        {
            //given
            Mock<Printer> mockedPrinter = new Mock<Printer>();
            mockedPrinter.Setup(printer => printer.Print(It.IsAny<string>())).Throws(new PrinterOutOfPaperException());
            var cashRegister = new CashRegister(mockedPrinter.Object);
            var purchase = new Purchase();
            //when
            Action action = () => cashRegister.Process(purchase);
            //then
            Exception exception = Assert.Throws<HardwareException>(action);
            Assert.Equal("Printer is out of paper.", exception.Message);
        }
    }
}
