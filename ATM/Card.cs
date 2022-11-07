using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Card
    {
        public string cardNumber { get; set; }
        public int pin { get; set;}
        public bool status {get; set; }

        public int money {get; set;}

        public int numberOfEvents = 0;

        List<Event> events = new List<Event>();

        


       

        public void withdrawMoney(int a)
        {
            money -= a;

            Event withdrawMoney = new Event()
            {
                eventName = "Withdraw Money",
                amountSpent = -a,
                actualAmount = money
            };

            events.Add(withdrawMoney);

        }
        public void depositMoney(int a)
        {
            money += a;

            Event depositMoney = new Event()
            {
                eventName = "Deposit Money",
                amountSpent = +a,
                actualAmount = money
            };

            events.Add(depositMoney);

        }
        public void PayBills(int a)
        {        

            money -= a;

            Event paidBills = new Event()
            {
                eventName = "Paid Bill",
                amountSpent = -a,
                actualAmount = money
            };

            events.Add(paidBills);


        }
        public void showBalance()
        {

            for (int i = 0; i < events.Count; i++)
            {
                var aux = events[i];
                Console.Write(" "+ i + 1 + "Event Name : " + aux.eventName + "Amount : $" + aux.amountSpent + " Balance : $" + aux.actualAmount );
                Console.WriteLine();
            }

        }

        public void currentBalance()
        {
            Console.WriteLine("Your current balance is : $" + money);

        }

    }
}
