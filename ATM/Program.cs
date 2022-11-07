using ATM;
using System.Linq;
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

Card cardNumber1 = new Card()
{
    cardNumber ="4389 5540 9858 3049",
    money = 2500,
    pin = 3049,
    status = true
    
};

Card cardNumber2 = new Card()
{
    cardNumber ="4389 5500 4421 7901",
    money = 200,
    pin = 8765,
    status = true
    
};


Card cardNumber3 = new Card()
{
    cardNumber ="4389 5580 6512 3212",
    money = 2500,
    pin = 0000,
    status = false
    
};

List<Card> cardsList = new List<Card>();
cardsList.Add(cardNumber1);
cardsList.Add (cardNumber2);
cardsList.Add (cardNumber3);



List<Bills> billsToPay = new List<Bills>();
billsToPay.Add(waterBill);
billsToPay.Add(electricBill);
billsToPay.Add(phoneBill);

bool continueValidator = true;
var option ="";
Card selectedCard = new Card();




do { 
Console.WriteLine("Welcome to our ATM ! You have inserted 3 cards , please choose one :");
Console.WriteLine();

 foreach (Card item in cardsList)
	{
    if(item.status)
    Console.WriteLine(item.cardNumber + " active");
	else
        Console.WriteLine(item.cardNumber + "blocked");
    }

    do { 
Console.WriteLine();
Console.Write("Answer : ");
option = Console.ReadLine();

    
switch(option)
{
        case "1" : 
            selectedCard = cardNumber1;
                   
            break;
        case "2" :
            selectedCard = cardNumber2;

            break;
        case "3" :
            selectedCard = cardNumber3;
            break;
        default :
            inputValidation();
            break;
       
}
        if(cardBlocked(selectedCard))
            continueValidator = false;
        } while(continueValidator);



    continueValidator =true;

    

Console.WriteLine("What would you like to do ? Please choose one option : \n 1 - Other Options (PIN requied)  \n 2 - Withdraw card \n 3 - Block card ");
Console.WriteLine();
Console.Write("Answer : ");


 option = Console.ReadLine();
Console.WriteLine();

int billsNumber = billsToPay.Count;

var myCard = new Card();
bool pinValidation = true;

if (option == "1")
{

    do
    {
    Console.Write("PIN code : ");
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
                int moneyToBeWithdraw;
                bool success = int.TryParse(Console.ReadLine(), out moneyToBeWithdraw);
                if(success)
                {
                myCard.withdrawMoney(moneyToBeWithdraw);
                myCard.currentBalance();
                }
                else
                {
                    Console.WriteLine("Please enter a valid number ! ");
                }

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
    }while(continueValidator);

        continueValidator = true;
    
}
else if(option == "2")
{
    Console.WriteLine("You can withdraw your card ! ");
}else if(option == "3")
{
    Console.WriteLine("Your card is blocked !");
    selectedCard.status = false;
}
else
{
    Console.WriteLine("Invalid input ! ");
}

}while(continueValidator);



 void validation()
 {
    Console.WriteLine();
    Console.WriteLine("Would you like to do aonther transaction ? If 'no' the program will exit .");
    string answer = Console.ReadLine();

    if (answer == "no")
        continueValidator = false;      
 }

void inputValidation()
{
    Console.WriteLine("Invalid input , try again !!");
}

bool cardBlocked(Card cardToBeChecked)
{
    if(cardToBeChecked.status)
        return true;
    else
       Console.WriteLine("This card is Blocked !! Please choose another one ");

    return false;
}


