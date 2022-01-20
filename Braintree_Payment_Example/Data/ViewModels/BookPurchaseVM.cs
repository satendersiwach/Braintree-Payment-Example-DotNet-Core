using Braintree_Payment_Example.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Braintree_Payment_Example.Data.ViewModels
{
    public class BookPurchaseVM : Book
    {
        public string Nonce { get; set; }
    }
}
