namespace CashRegisterTest
{
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
    }
}
