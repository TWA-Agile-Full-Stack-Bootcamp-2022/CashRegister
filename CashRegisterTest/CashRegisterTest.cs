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
			var mockPrinter = new MockPrinter();
			var cashRegister = new CashRegister(mockPrinter);
			var purchase = new Purchase();
			//when
			cashRegister.Process(purchase);
			//then
			//verify that cashRegister.process will trigger print
			Assert.NotNull(mockPrinter.GetPrintContent());
		}

		[Fact]
		public void Should_process_execute_with_purchase_content()
		{
			var mockPrinter = new MockPrinter();
			var cashRegister = new CashRegister(mockPrinter);
			var purchase = new Purchase();
			//when
			cashRegister.Process(purchase);
			//then
			Assert.Contains("content", mockPrinter.GetPrintContent());
		}

		[Fact]
		public void Should_thrown_hardware_exception_when_process_execute_when_printer_has_out_of_paper_exception()
		{
			//given
			var mockExceptionPrinter = new MockExceptionPrinter();
			var cashRegister = new CashRegister(mockExceptionPrinter);
			var purchase = new Purchase();
			//then
			Assert.Throws<HardwareException>(() => cashRegister.Process(purchase));
		}
	}
}
