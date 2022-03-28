using System.Xml.Serialization;

namespace BankAccounts.App
{
    public class Transaction
    {
        // Fields
        [XmlAttribute]
        public double amount {get; set;}
        public DateTime date {get; set;}
        public string? note {get; set;}

        // Constructors
        public Transaction() {}

        public Transaction(double amount, DateTime date, string note = "")
        {
            this.amount = amount;
            this.date = date;
            this.note = note;
        }

    }
}