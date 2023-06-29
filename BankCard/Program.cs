using System;

namespace BankCard
{
    public abstract class Bankcard
    {
        public string NameSurname { get; set; }
        public string CardCode { get; set; }
        public int CVV { get; set; }
        public decimal Balance { get; set; }

        public Bankcard(string nameSurname, string cardCode, int cvv, decimal balance)
        {
            NameSurname = nameSurname;
            CardCode = cardCode;
            CVV = cvv;
            Balance = balance;
        }

        public abstract void Medaxil(decimal amount);
        public abstract void Mexaric(decimal amount);
    }

    public class UnibankCard : Bankcard
    {
        public UnibankCard(string nameSurname, string cardCode, int cvv, decimal balance) : base(nameSurname, cardCode, cvv, balance)
        {
        }

        public override void Medaxil(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"{Balance} AZN deposited to Unibank Card.");
        }

        public override void Mexaric(decimal amount)
        {
            Balance-=amount * 0.015m;
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew {amount} AZN from Unibank Card.");
            }
            else
            {
                Console.WriteLine("There is not enough money in the balance.");
            }
        }
    }

    public class AccessbankCard : Bankcard
    {
        public AccessbankCard(string nameSurname, string cardCode, int cvv, decimal balance) : base(nameSurname, cardCode, cvv, balance)
        {
        }

        public override void Medaxil(decimal amount)
        {
            Balance += amount - amount * 0.003m;
            Console.WriteLine($"{amount} AZN deposited to AccessBank Card.");
        }

        public override void Mexaric(decimal amount)
        {
            decimal commission = amount * 0.016m;
            decimal totalAmount = amount + commission;

            if (totalAmount <= Balance)
            {
                Balance -= totalAmount;
                Console.WriteLine($"Withdrew {amount} AZN from AccessBank Card. Commission: {commission} AZN");
            }
            else
            {
                Console.WriteLine("There is not enough money in the balance.");
            }
        }
    }

    public class PashabankCard : Bankcard
    {
        public PashabankCard(string nameSurname, string cardCode, int cvv, decimal balance) : base(nameSurname, cardCode, cvv, balance)
        {
        }

        public override void Medaxil(decimal amount)
        {
            Balance += amount - amount * 0.3m;
            Console.WriteLine($"{amount} AZN deposited to PashaBank Card.");
        }

        public override void Mexaric(decimal amount)
        {
            decimal commission = amount * 0.011m;
            decimal totalAmount = amount + commission;

            if (totalAmount <= Balance)
            {
                Balance -= totalAmount;
                Console.WriteLine($"Withdrew {amount} AZN from PashaBank Card. Commission: {commission} AZN");
            }
            else
            {
                Console.WriteLine(" There is not enough money in the balance.");
            }
        }
    }

    public class LeobankCard : Bankcard
    {
        public LeobankCard(string nameSurname, string cardCode, int cvv, decimal balance) : base(nameSurname, cardCode, cvv, balance)
        {
        }

        public override void Medaxil(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"{amount} AZN deposited to LeoBank Card.");
        }

        public override void Mexaric(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew {amount} AZN from LeoBank Card.");
            }
            else
            {
                Console.WriteLine("There is not enough money in the balance.");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            UnibankCard unibank = new UnibankCard("Ali Salmanov", "1234 4321 5678 8765", 333, 10003m);
            AccessbankCard access = new AccessbankCard("Ali Salmanov", "1234 4321 5678 8765", 333, 3000m);
            PashabankCard pashabank = new PashabankCard("Ali Salmanov", "1234 4321 5678 8765", 333, 3333m);
            LeobankCard leobank = new LeobankCard("Ali Salmanov", "1234 4321 5678 8765", 333, 77777m);

            unibank.Medaxil(300m);
            access.Medaxil(300m);
            pashabank.Medaxil(300m);
            leobank.Medaxil(300m);

            unibank.Mexaric(100m);
            access.Mexaric(100m);
            pashabank.Mexaric(100m);
            leobank.Mexaric(100m);
        }
    }
}
