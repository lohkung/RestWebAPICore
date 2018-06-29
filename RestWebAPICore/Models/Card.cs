using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWebAPICore.Models
{
    public class Card
    {
        public String cardNumber { get; set; }
        public String expireDate { get; set; }

        public Card(String cardNumber, String expireDate)
        {
            this.cardNumber = cardNumber;
            this.expireDate = expireDate;
        }
    }
}
