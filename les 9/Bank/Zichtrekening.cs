using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    class ZichtRekening: Rekening
    {

        public ZichtRekening(string naam) : base(naam)
        {

        }

        internal override void ToonMenu()
        {
            char keuze;
            do
            {
                Console.Clear();
                Console.WriteLine("a. Afhalen.");
                Console.WriteLine("b. Storten.");
                Console.WriteLine("c. Check saldo.");
                Console.WriteLine("d. Bekijk laatste 10 verrichtingen");
                Console.WriteLine("e. Terug naar hoofdmenu.");

                keuze = Convert.ToChar(Console.ReadKey().KeyChar.ToString().ToLower());
                Console.WriteLine();

                VoerActieUit(keuze);
        Console.ReadKey();
            } while (keuze != 'e');
        }
        internal override void VoerActieUit(char keuze)
        {
            if (keuze == 'a')
            {
                GeldAfhalen();
            }
            else if (keuze == 'b')
            {
                GeldStorten();
            }
            else if (keuze == 'c')
            {
                ToonSaldo();
            }
            else if (keuze == 'd')
            {
                ToonVerrichting();
            }
        }
       
    }
}
