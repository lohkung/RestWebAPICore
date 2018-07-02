using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWebAPICore.Models
{
    public class BusinessService
    {
        public ValidateResult VerifyResult(Card card)
        {
            ValidateResult res = new ValidateResult();
            if (card != null)
            {
                //Visa is a card number starts with 4
                //  A valid Visa card is the card number which expiry year is a leap year.
                //MasterCard is a card number starts with 5
                //  A valid MasterCard card is the card number which expiry year is a prime number
                //Amex is a card number starts with 3
                //  Only Amex card number is 15 digits, the rest of card types have 16 digits long.
                //JCB is a card number starts with 3
                //  All JCB card is valid

                //Result:
                //Card number must exist on the database, unless returned result is “Does not exist”
                //The rest case is “Invalid” card

                //CardType:
                //The card starts with any other numbers is Unknown

                String cardType = VerifyCardType(card);
                res.cardType = cardType;
                if (!cardType.Equals("Unknow"))
                {

                    //  A valid Visa card is the card number which expiry year is a leap year.

                    //  A valid MasterCard card is the card number which expiry year is a prime number

                    //  Only Amex card number is 15 digits, the rest of card types have 16 digits long.

                    //  All JCB card is valid
                    if (cardType.Equals("JCB") || cardType.Equals("Amex"))
                    {
                        res.result ="Valid";
                    }
                    else if (cardType.Equals("Visa") && IsLeapYear(card))
                    {
                        res.result = "Valid";
                    }
                    else if (cardType.Equals("MasterCard") && IsPrimeYear(card))
                    {
                        res.result = "Valid";
                    }
                    else
                    {
                        res.result = "Invalid";
                    }
                    return res;

                }

            }
            res.result = "Invalid";
            return res;
        }

        private String VerifyCardType(Card card)
        {
            if (card != null)
            {
                //Visa is a card number starts with 4

                //MasterCard is a card number starts with 5

                //Amex is a card number starts with 3
                //  Only Amex card number is 15 digits, the rest of card types have 16 digits long.
                //JCB is a card number starts with 3
                //The card starts with any other numbers is Unknown
                int cLength = card.cardNumber.Length;
                int AMEX_LENGTH = 15;
                int REST_LENGTH = 16;
                if (card.cardNumber.StartsWith("3"))
                {
                    if (cLength == AMEX_LENGTH)
                        return "Amex";
                    return "JCB";

                }
                else if (card.cardNumber.StartsWith("4") && cLength == REST_LENGTH)
                {
                    return "Visa";

                }
                else if (card.cardNumber.StartsWith("5") && cLength == REST_LENGTH)
                {
                    return "MasterCard";
                }

            }
            return "Unknow";
        }

        private int ExpiryYear(Card card)
        {
            String expDate = card.expireDate;
            String exp = expDate.Substring(2, 4);
            int year = Convert.ToInt32(exp);
            return year;
        }

        private bool IsLeapYear(Card card)
        {
            int year = ExpiryYear(card);
            return DateTime.IsLeapYear(year);
        }

        private bool IsPrimeYear(Card card)
        {
            int year = ExpiryYear(card);
            int temp = 0;
            bool isPrime = true;
            for (int i = 2; i <= year / 2; i++)
            {
                temp = year % i;
                if (temp == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }
    }
}
