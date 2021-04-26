namespace example2
{
    public class Client
    {
        public string Fio { get; set; }
        public BankScore BankScore { get; set; }
        public BankCard BankCard { get; set; }
    }

    public class BankCard : Score
    {
        public BankCard(string number, string pin) : base(number)
        {
            Pin = pin;
        }

        public string Pin { get; }
        public bool IsBlock { get; protected set; }

        public string BlockCard(string pin)
        {
            if (pin != Pin) return "Pin-code is not correctly";

            IsBlock = true;
            return "Block completed by user";
        }

        public string BlockAdmin(string adminPass)
        {
            if (adminPass != "Qwerty") return "Password is not correctly";
            
            IsBlock = true;
            return "Block completed.";
        }
    }

    public class BankScore : Score
    {
        public BankScore(string number) : base(number)
        {
        }

        public bool IsAnnul { get; protected set; }

        public string AnnulScore()
        {
            IsAnnul = true;
            return "Score annul.";
        }
    }


    public class Score
    {
        public Score(string number)
        {
            Number = number;
        }

        public string Number { get; }
        public double Sum { get; private set; }

        public Score PlusMoney(double money)
        {
            Sum += money;
            return this;
        }

        public Score Pay(double money)
        {
            Sum -= money;
            return this;
        }
    }
}