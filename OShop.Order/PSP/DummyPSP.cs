using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OShop.Order.Abstract;

namespace OShop.Order.PSP
{
    public class DummyPSP : IPSP
    {
        public bool MakePayment()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(100);
            return (randomNumber < 70);
        }
    }
}