using System;
using System.Collections.Generic;
using WPF_Schoolbib;
using WPF_Schoolbib.Models;

namespace Console_Schoolbib
{
    //    Boeken inleveren &uitlenen
    //Een boek wordt normaal gezien gescanned.Dit kan je simuleren aan de hand van het id van een
    //boek in te typen.
    //Overzicht van alle ontleningen bekijken
    //Een ontlening verlengen
    //Een ontlening kan slechts 1 maal verlengd worden.
    //Boetes betalen
    //Een student kan geen nieuwe ontleningen doen wanneer deze een boete heeft.
    //De student moet zijn boete kunnen betalen aan de terminal. De volledige betaling hoef je niet te
    //implementeren.Implementeer wel een manier om aan te geven dat de student betaald heeft.*/
    class SelfServiceInterface
    {//inloggen aan de hand van selfservice 
     //
  
        public SelfServiceInterface()
        {

        }
        public SelfServiceInterface(Students loggedStudent)
        {
            LoggedStudent = loggedStudent;
        }
        static public Students LoggedStudent { get ; set; }
       
      

      

     
        internal void getLoans()
        {

        }
        internal void ExtendLoan()
        {

        }
        internal void PayFine()
        {

        }

    }
}
