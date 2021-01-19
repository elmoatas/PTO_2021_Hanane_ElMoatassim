using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{
    class DVD:Library
    {
        //regisseur
        //speelduur
        //int id
        public DVD(string title, string author, int ID) : base(title, author, ID)
        {

        }
    }
}
