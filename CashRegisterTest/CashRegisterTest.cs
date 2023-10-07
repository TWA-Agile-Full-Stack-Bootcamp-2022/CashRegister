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
    }
}
