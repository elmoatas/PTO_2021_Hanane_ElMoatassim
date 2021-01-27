using System;
using System.Windows;
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{
    /// <summary>
    /// Interaction logic for WindowShowStudentLoans.xaml
    /// </summary>
    public partial class WindowShowStudentLoans : Window
    {
        LibraryRepository libraryRepository = new LibraryRepository();
        LoansRepository loansRepository = new LoansRepository();
        int studentId;
        public WindowShowStudentLoans(int studentID)
        {
            InitializeComponent();
            this.studentId = studentID;
            ShowLoans();
        }
        private void ShowLoans()
        {
            LoansOfSelectedStudentListbox.ItemsSource = loansRepository.GetLoansOfStudent(studentId);
        }

        private void FilterItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoansOfSelectedStudentListbox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ShowInfoOfLoan();
        }
        private void ShowInfoOfLoan()
        {
            Loans selected = (Loans)LoansOfSelectedStudentListbox.SelectedItem;
            string title = selected.ItemTitle;
            string creator = selected.ItemCreator;
            long productnumber = selected.ItemProductNumber;
            string loandate = selected.LoanDate.ToShortDateString();
            string returnDate = selected.ReturnDateString;
            LoanInfoTextBlock.Text = $"EXTRA INFORMATIE:" +
                                     $"{Environment.NewLine}" +
                                     $"{Environment.NewLine}" +
                                     $"Titel en Artiest/regiseur/auteur: {title} - {creator}" +
                                     $"{Environment.NewLine}" +
                                     $"Artiest/regiseur/auteur: { creator}" +
                                     $"{Environment.NewLine}" +
                                     $"Productnummer: {productnumber}" +
                                     $"{Environment.NewLine}" +
                                     $"Uitleendatum: {loandate}" +
                                     $"{Environment.NewLine}" +
                                     $"{returnDate}";

        }
    }
}
