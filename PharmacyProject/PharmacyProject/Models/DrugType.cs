using System;
namespace PharmacyProject.Models
{
    public class DrugType
    {
        // DrugType - deye derman tipi classi olacaq.Unikal Id ve TypeName olacaq.ToString TypeName-ni qaytarmalidir.

        public int Id { get; }

        public string TypeName { get; }

        private static int _counter = 0;

        public DrugType(string typename)
        {
            TypeName = typename;
            _counter++;
            Id = _counter;
        }

        public override string ToString()
        {
            return TypeName;
        }
    }

}