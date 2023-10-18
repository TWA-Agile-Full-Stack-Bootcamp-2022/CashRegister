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
            Mock<Printer> mock = new Mock<Printer>();
            var cashRegister = new CashRegister(mock.Object);
            Mock<Purchase> mockPurchase = new Mock<Purchase>();
            mockPurchase.Setup(p => p.AsString()).Returns("1234");
            //when
            cashRegister.Process(mockPurchase.Object);
            //then
            mock.Verify(x => x.Print("1234"));
		}

		[Fact]
		public void Should_thrown_when_print_outofpaper()
        {
            Mock<Printer> printerMock = new Mock<Printer>();
            CashRegister cashRegister = new CashRegister(printerMock.Object);
            printerMock.Setup(m => m.Print(It.IsAny<string>())).Throws(new PrinterOutOfPaperException());
            Purchase purchase = new Purchase();

            Assert.Throws<HardwareException>(() => cashRegister.Process(purchase));
        }
    }
}
