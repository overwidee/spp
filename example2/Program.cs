using System;

namespace example2
{
    class Program
    {
        static void Main(string[] args)
        {
            var newClient = new Client()
            {
                Fio = "Шичко П.В.",
                BankCard = new BankCard("9984 3452 3245 3423", "1234"),
                BankScore = new BankScore("BY22314182124123")
            };

            //добавляем
            newClient.BankCard.PlusMoney(1000);
            newClient.BankScore.PlusMoney(1000);
            
            Console.WriteLine($"On card: {newClient.BankCard.Sum}");
            Console.WriteLine($"On score: {newClient.BankScore.Sum}");
            
            // оплачиваем
            newClient.BankCard.Pay(345);
            newClient.BankScore.Pay(789);
            
            Console.WriteLine($"On card: {newClient.BankCard.Sum}");
            Console.WriteLine($"On score: {newClient.BankScore.Sum}");
            
            Console.WriteLine($"Block message: {newClient.BankCard.BlockCard("1234")}");
            Console.WriteLine($"Block message: {newClient.BankScore.AnnulScore()}");

            Console.ReadLine();
        }
    }
}