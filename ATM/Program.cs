using ATM;
using System.Collections.Generic;


Bills waterBill = new Bills()
{
    Amount = 129,
    billName = "Water"
};

Bills electricBill = new Bills()
{
    Amount = 289,
    billName = "Electric"
};

Bills phoneBill = new Bills()
{
    Amount = 89,
    billName = "Phone"
};

List<Bills> billsToPay = new List<Bills>(2);
billsToPay.Add(waterBill);
billsToPay.Add(electricBill);
billsToPay.Add(phoneBill);



Console.WriteLine("Hi ! What would you like to do ? Please choose one option : \n 1 - Insert card  \n 2 - Withdraw card \n 3 - Block card ");
Console.WriteLine();
Console.Write("Answer : ");


var option = Console.ReadLine();
Console.WriteLine();

bool cont = true;
int billsNumber = billsToPay.Count;

var myCard = new Card();
bool pinValidation = true;

if (option == "1")
{
    Console.Write("PIN code : ");

    do
    {
        var pinCode = int.Parse(Console.ReadLine());

        if (pinCode == myCard.pin)
        {
            pinValidation = false;
        }
        else
        {
            Console.WriteLine("PIN invalid , try again ");
        }

    }while(pinValidation);

    do
    {
    Console.WriteLine();
    Console.WriteLine("Choose one option : \n 1 - Withdraw money \n 2 - Deposit money \n 3 - Pay bills  \n 4 - Show balance ");
    Console.WriteLine();
    Console.Write("Answer : ");

    option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Write("Please enter the amount you would like to withdraw : $");
                int moneyToBeWithdraw = int.Parse(Console.ReadLine());
                myCard.withdrawMoney(moneyToBeWithdraw);
                myCard.currentBalance();

                validation();

                break;
            case "2":
                Console.Write("Please enter the amount you would like to deposit : $");
                int moneyToBeDeposited = int.Parse(Console.ReadLine());
                myCard.depositMoney(moneyToBeDeposited);
                myCard.currentBalance();

                validation();

                break;
            case "3":
                if (billsNumber <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("No bills to pay !");

                }
                else
                {
                    Console.Write("Please select witch bill you would like to pay : ");
                    Console.WriteLine();
                    for (int i = 0; i < billsToPay.Count; i++)
                    {
                        var aux = billsToPay[i];
                        Console.Write(i + " " + aux.Amount + " " + aux.billName);
                        Console.WriteLine();
                    }


                    Console.Write("Answer : ");
                    int selectedBill = int.Parse(Console.ReadLine());
                    var help = billsToPay[selectedBill];
                    billsToPay.RemoveAt(selectedBill);
                    myCard.PayBills(help.Amount);
                    myCard.currentBalance();
                    billsNumber--;
                }

                validation();

                break;
            case "4":
                myCard.showBalance();
                myCard.currentBalance();
                validation();
                break;

            default:
                Console.WriteLine("Invalid input !");
                break;

                validation();
        }
    }while(cont);
    
}
else if(option == "2")
{
    Console.WriteLine("You can withdraw your card ! ");
}else if(option == "3")
{
    Console.WriteLine("Your card is blocked !");
}
else
{
    Console.WriteLine("Invalid input ! ");
}



 void validation()
 {
    Console.WriteLine();
    Console.WriteLine("Would you like to do aonther transaction ? If 'no' the program will exit .");
    string answer = Console.ReadLine();

    if (answer == "no")
        cont = false;      
 }


