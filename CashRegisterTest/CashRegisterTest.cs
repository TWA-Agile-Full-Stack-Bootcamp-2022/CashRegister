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
			var newPrinter = new Printer();
			var cashRegister = new CashRegister(newPrinter);
			var purchase = new Purchase();
			//when
			cashRegister.Process(purchase);
			//then
			//verify that cashRegister.process will trigger print
			Assert.NotNull(newPrinter.GetNeedPrintContent());
		}

		[Fact]
		public void Should_process_execute_printing_without_real_printer()
		{
			//given
			var mockPrinter = new Mock<IPrinter>();
			var cashRegister = new CashRegister(mockPrinter.Object);
			var purchase = new Purchase();
			//when
			cashRegister.Process(purchase);
			//then
			//verify that cashRegister.process will trigger print
			mockPrinter.Verify(printer => printer.Print(It.IsAny<string>()));
		}

		[Fact]
		public void Should_process_execute_with_purchase_content()
		{
			var mockPrinter = new Mock<IPrinter>();
			var cashRegister = new CashRegister(mockPrinter.Object);
			var mockPurchase = new Mock<IPurchase>();
			var purchaseDealContent = "content";
			mockPurchase.Setup(purchase => purchase.AsString()).Returns(purchaseDealContent);
			mockPrinter.Setup(printer => printer.Print(It.IsAny<string>()));
			//when
			cashRegister.Process(mockPurchase.Object);
			//then
			mockPrinter.Verify(printer => printer.Print(It.Is<string>(s => s.Equals(purchaseDealContent))),
				Times.Once());
		}

		[Fact]
		public void Should_thrown_hardware_exception_when_process_execute_when_printer_has_out_of_paper_exception()
		{
			//given
			var mockExceptionPrinter = new Mock<IPrinter>();
			var cashRegister = new CashRegister(mockExceptionPrinter.Object);
			var purchase = new Purchase();
			mockExceptionPrinter.Setup(printer => printer.Print(It.IsAny<string>())).Throws(new PrinterOutOfPaperException());
			//then
			Assert.Throws<HardwareException>(() => cashRegister.Process(purchase));
		}
	}
}
