using Braintree;
using Braintree_Payment_Example.Data.Services;
using Braintree_Payment_Example.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Braintree_Payment_Example.Controllers
{

    public class CheckoutController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IBraintreeService _braintreeService;

        public CheckoutController(IBookService courseService, IBraintreeService braintreeService)
        {
            _bookService = courseService;
            _braintreeService = braintreeService;
        }

        public IActionResult Purchase(Guid id)
        {

            var book = _bookService.GetById(id);
            if (book == null) return NotFound();

            var gateway = _braintreeService.GetGateway();
            var clientToken = gateway.ClientToken.Generate();
            ViewBag.ClientToken = clientToken;

            var data = new BookPurchaseVM
            {
                Id = book.Id,
                Description = book.Description,
                Author = book.Author,
                Title = book.Title,
                Price = book.Price,
                Nonce = ""
            };

            return View(data);
        }

        public IActionResult Create(BookPurchaseVM model)
        {
            var gateway = _braintreeService.GetGateway();
            var book = _bookService.GetById(model.Id);

            var request = new TransactionRequest
            {
                Amount = Convert.ToDecimal(book.Price),
                PaymentMethodNonce = model.Nonce,
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };

            Result<Transaction> result = gateway.Transaction.Sale(request);

            if (result.IsSuccess())
            {
                return View("Success");
            }
            else
            {
                return View("Failure");
            }
        }
    }
}