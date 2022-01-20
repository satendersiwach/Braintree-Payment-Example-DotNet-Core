using Braintree;
using Braintree_Payment_Example.Data.Models;
using Braintree_Payment_Example.Data.Services;
using Braintree_Payment_Example.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Braintree_Payment_Example.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        // GET: Books
        public IActionResult Index()
        {
            var items = _service.GetAll();
            return View(items);
        }

        // GET: Books/Details/5
        public IActionResult Details(Guid id)
        {
            var book = _service.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

    }

   
}
