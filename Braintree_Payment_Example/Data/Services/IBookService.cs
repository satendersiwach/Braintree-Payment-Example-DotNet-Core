using System;
using System.Collections.Generic;
using Braintree_Payment_Example.Data.Models;

namespace Braintree_Payment_Example.Data.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        Book GetById(Guid courseId);
    }
}
