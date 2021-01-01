using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ticketverkoop
{
    /// <summary>
    /// Interaction logic for PrintTicket.xaml
    /// </summary>
    public partial class PrintTicket : TicketInformation
    {
        
        private DateTime DepartureDate;
        private DateTime ArivalDate;
        public PrintTicket(string destinationA)
        {
            InitializeComponent();
            trajectLabel.Content = destinationA;
        }
    }
}
