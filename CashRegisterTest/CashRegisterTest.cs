using System;
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
			Mock<IPrinter> printerMock = new Mock<IPrinter>();
			printerMock.Setup(p => p.Print(It.IsAny<string>()));
			var cashRegister = new CashRegister(printerMock.Object);
			var purchase = new Purchase();
			//when
			cashRegister.Process(purchase);
			//then
			//verify that cashRegister.process will trigger print
			printerMock.Verify(p => p.Print(
				It.Is<string>(s => s.StartsWith("content"))), Times.Once());
		}

		[Fact]
		public void Should_verify_print_from_purchase_when_process_execute_printing_given_mock_purchase()
		{
			//given
			Mock<IPrinter> printerMock = new Mock<IPrinter>();
			printerMock.Setup(p => p.Print(It.IsAny<string>()));
			var cashRegister = new CashRegister(printerMock.Object);
			Mock<IPurchase> purchaseMock = new Mock<IPurchase>();
			purchaseMock.Setup(p => p.AsString()).Returns("PURCHASE CONTENT");

			//when
			cashRegister.Process(purchaseMock.Object);
			//then
			printerMock.Verify(p => p.Print(
				It.Is<string>(s => s.Equals("PURCHASE CONTENT"))), Times.Once());
		}

		[Fact]
		public void Should_throw_hardware_exception_when_print_given_printer_throws_PrinterOutOfPaperException()
		{
			//given
			Mock<IPrinter> printerMock = new Mock<IPrinter>();
			printerMock.Setup(p => p.Print(It.IsAny<string>())).Throws(new PrinterOutOfPaperException());
			var cashRegister = new CashRegister(printerMock.Object);
			//when
			//then
			HardwareException hardwareException = Assert.Throws<HardwareException>(
				() => cashRegister.Process(new Purchase()));
			Assert.Equal("Printer is out of paper.", hardwareException.Message);
		}
	}
}
