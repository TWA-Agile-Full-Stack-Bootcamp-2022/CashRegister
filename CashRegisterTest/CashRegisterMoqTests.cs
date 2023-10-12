namespace CashRegisterTest
{
    using CashRegister;
    using Moq;
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
    }
}
