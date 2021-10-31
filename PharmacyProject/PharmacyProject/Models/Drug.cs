using System;
namespace PharmacyProject.Models
{
    public class Drug
    {
        // Drug - derman classi.Name, Unikal Id, Type(DrugType tipinden), Price, Count olacaq.
        // ToString - Id, Name, Price ve Count qaytarmalidir.

        public string Name { get; }

        public double Price { get; }

        public int Count { get; }

        public int Id { get; }

        public DrugType Type { get; }

        private static int _counter = 0;

        public Drug(string name, double price, int count ,DrugType type)
        {
            Name = name;
            Price = price;
            Count = count;
            Type = type;
            _counter++;
            Id = _counter;
        }

        public override string ToString()
        {
            return $"ID:{Id} Type: {Type} , DrugName: {Name} , Price: {Price}$ , Count: {Count} pieces";
        }
    }
}