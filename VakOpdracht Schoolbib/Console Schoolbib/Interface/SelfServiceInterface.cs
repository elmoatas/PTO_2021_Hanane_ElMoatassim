using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Schoolbib
{
    class SelfServiceInterface
    {//inloggen aan de hand van selfservice 
     //
        internal SelfServiceInterface()
        {

        }
        internal void ShowSelfService()
        {
            Console.WriteLine("Welkom");
            Console.WriteLine("a. Boek Lenen");
            Console.WriteLine("b. Boek Inleveren ");
            Console.WriteLine("c. Overzicht van ontlening bekijken");
            Console.WriteLine("d. Ontlening verlengen");
            Console.WriteLine("e. Boetes betalen");
        }

       

    }
}
