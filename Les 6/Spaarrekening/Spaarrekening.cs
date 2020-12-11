using System;

namespace Spaarrekening
{
    public class Saving : Rekening
    {
        public Saving(string name) : base(name)
        {

        }

        private void VoerActieUit(char keuze)
        {
           do{
               
           if (keuze == 'b')
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
        } while (keuze !='a');

          
                Console.WriteLine("je kan geen geld afhalen");
            
        }

    }
}
