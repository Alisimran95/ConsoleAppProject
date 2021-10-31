using System;
using PharmacyProject.Utils;

namespace PharmacyProject.Models
{
    //AddDrug - methodu Drug gebul etmeli Drug listine add etmelidir.
    //InfoDrug - name qebul etmelidir ve uygun derman haqqinda melumatlari chixarmalidir.
    //ShowDrugItems - methodu olmalidir, dermanlarin siyahisini vermelidr.
    //SaleDrug - methodu olmalidir, derman adi - derman sayi - pul qebul etmelidir,
    //eger bu dermandan varsa ve istenilen say qederdise ve pulda chatirsa satish bash versin. Eks halda uygun xeberdarliq chixarsin.
    partial class Pharmacy
    {
        public override string ToString()
        {
            return $"{Id} {Name}";
        }

        public bool AddDrug(Drug drug)
        {
            if (_drugList.Count == drug.Count)
            {
                return false;
            }

             _drugList.Add(drug); 
            
            return true;
        }
        public bool AddType(DrugType drugType)
        {
            if (drugType !=null)
            {
                return true;
            }
            return false;
        }

        public void ShowDrugItems()
        {
            if (_drugList.Count == 0)
            {
                Easy.Print($"{Name} is Empty , there are not drugs.", ConsoleColor.Red);
                return;
            }

            Easy.Print($"{"Drug's info is below: "}", ConsoleColor.Yellow);

            foreach (var item in _drugList)
            {
                Easy.Print(item.ToString(), ConsoleColor.Green);
            }
        }

        public bool InfoDrug(string drugname)
        {
            var students = _drugList.FindAll(x => x.Name.ToLower().Contains(drugname.Trim().ToLower()));
            if (students.Count == 0)
            {
                Easy.Print("Nothing found", ConsoleColor.Red);
                return false;
            }
            foreach (var item in _drugList)
            {
                Easy.Print($"{item}", ConsoleColor.Green);
            }

            return true;
        }

        public void SaleDrug(string drugname, double money, int count, string drugtype)
        {
            var drug1 = _drugList.Find(x => x.Name.Trim().ToLower() == drugname.Trim().ToLower());
            var drug2 = _drugList.Find(x => x.Price > money && (x.Count <= count || x.Count >= count));
            var drug3 = _drugList.Find(x =>x.Count < count && (x.Price <= money || x.Price >= money));
            var drug4 = _drugList.Find(x => x.Type.ToString().Trim().ToLower() == drugtype.Trim().ToLower());

            if (drug1 == null)
            {
                Easy.Print($"There is not {drugname} drug in selected pharmacy", ConsoleColor.Red);
                return;
            }
            if (drug2 != null)
            {
                Easy.Print("Sale is not successfully completed , because you have not enough money , sorry ... ", ConsoleColor.Red);
                return;
            }
            if (drug3 != null)
            {
                Easy.Print("Sale is not successfully completed , because there is not enough drug count in pharmacy , sorry ...", ConsoleColor.Red);
                return;
            }
            if (drug4 == null)
            {
                Easy.Print($"There is not {drugtype} type in selected pharmacy ",ConsoleColor.Red);
                return;
            }

            if (drug1 != null || drug2 == null || drug3 == null || drug4 != null)
            {
                Easy.Print("Sale is successfully completed ", ConsoleColor.Green);
            }
        }
        //public Drug InfoDrug(string drugname)
        //{
        //    Drug find = _drugList.Find(x => x.Name.Trim().ToLower() == drugname.Trim().ToLower());
        //    if (find == null)
        //    {
        //        return null;
        //    }
        //    return find;


        //}

    }
}