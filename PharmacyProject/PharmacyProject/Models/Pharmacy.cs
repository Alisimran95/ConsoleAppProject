using System;
using System.Collections.Generic;

namespace PharmacyProject.Models
{

    partial class Pharmacy
    {
        //Pharmacy - aptek classi.Name, Unikal Id, Drug list olacaq.ToString - Id, Name qaytarmalidir.

        public string Name { get; }

        public int Id { get; }

        private static int _counter = 0;

        private List<Drug> _drugList;
        public List<DrugType> _drugTypes;

        public Pharmacy(string name)
        {
            Name = name;
            _counter++;
            Id = _counter;
            _drugList = new List<Drug>();
            _drugTypes =  new List<DrugType>();
        }
    }
}
