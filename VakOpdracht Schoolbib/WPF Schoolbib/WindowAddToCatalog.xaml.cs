using System;
using System.Windows;
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{
    /// <summary>
    /// Interaction logic for WindowCatalog.xaml
    /// </summary>
    public partial class WindowAddCatalog : Window
    {
        SchoolbibDBContext schoolbibDBContext = new SchoolbibDBContext();

        public WindowAddCatalog()
        {
            InitializeComponent();
            LoadLanguagesInComboBox();
            LoadGenreInComboBox();
        }
        private void LoadLanguagesInComboBox()
        {
            string[] languages = Enum.GetNames(typeof(Language));
            BookLanguageComboBox.ItemsSource = languages;
            DvdLanguageComboBox.ItemsSource = languages;
        }
        private void LoadGenreInComboBox()
        {
            string[] bookGenre = Enum.GetNames(typeof(BookGenre));
            string[] dvdGenre = Enum.GetNames(typeof(DVDGenre));
            string[] cdGenre = Enum.GetNames(typeof(CDGenre));
            BookGenreComboBox.ItemsSource = bookGenre;
            DvdGenreComboBox.ItemsSource = dvdGenre;
            CdGenreComboBox.ItemsSource = cdGenre;
        }

        #region books
        private bool CheckIfAllIsFilledBook()
        {
            bool allIsFilled = true;
            if (BookTitletextbox.Text == "" || BookAuthortextbox.Text == "" || BookISBNtextbox.Text == "" ||
           BookLanguageComboBox.SelectedIndex == -1 || BookPagestextbox.Text == "" || BookGenreComboBox.SelectedIndex == -1 || BookPublishertextbox.Text == "")
            {
                allIsFilled = false;
            }
            else
            {
                allIsFilled = true;
            }

            return allIsFilled;
        }
        private void UpdateUIBook()
        {
            BookTitletextbox.Text = "";
            BookAuthortextbox.Text = "";
            BookISBNtextbox.Text = "";
            BookLanguageComboBox.SelectedIndex = -1;
            BookPagestextbox.Text = "";
            BookGenreComboBox.SelectedIndex = -1;
            BookPublishertextbox.Text = "";
        }
        private void AddBook()
        {
            if (CheckIfAllIsFilledBook() == true)
            {
                string title = BookTitletextbox.Text;
                string Author = BookAuthortextbox.Text;
                long ISBNCode = Convert.ToInt64(BookISBNtextbox.Text);
                int languageIndex = BookLanguageComboBox.SelectedIndex;
                int pages = Convert.ToInt32(BookPagestextbox.Text);
                int genreIndex = BookGenreComboBox.SelectedIndex;
                string publisher = BookPublishertextbox.Text;
                Books newBook = new Books(title, Author, ISBNCode, genreIndex, languageIndex, pages, publisher);
                schoolbibDBContext.Books.Add(newBook);
                schoolbibDBContext.SaveChanges();
            }
        }
        private void BookAddButton_Click(object sender, RoutedEventArgs e)
        {
            AddBook();
            UpdateUIBook();
        }
        #endregion

        #region DVD
        private bool CheckIfAllIsFilledDVD()
        {
            bool allIsFilled = true;
            if (DvdEANTextbox.Text == "" || DvdTitleTextbox.Text == "" || DvdDirectorTextbox.Text == "" ||
                DvdLanguageComboBox.SelectedIndex == -1 || DvdDurationTextbox.Text == "" || DvdGenreComboBox.SelectedIndex == -1)
            {
                allIsFilled = false;
            }
            else
            {
                allIsFilled = true;
            }

            return allIsFilled;
        }
        private void UpdateUIDVD()
        {
            DvdEANTextbox.Text = "";
            DvdTitleTextbox.Text = "";
            DvdDirectorTextbox.Text = "";
            DvdLanguageComboBox.SelectedIndex = -1;
            DvdDurationTextbox.Text = "";
            DvdGenreComboBox.SelectedIndex = -1;
        }
        private void AddDVD()
        {
            if (CheckIfAllIsFilledDVD() == true)
            {
                string title = DvdTitleTextbox.Text;
                string creator = DvdDirectorTextbox.Text;
                long productNumber = Convert.ToInt64(DvdEANTextbox.Text);
                int languagIndex = DvdLanguageComboBox.SelectedIndex;
                int duration = Convert.ToInt32(DvdDurationTextbox.Text);
                int genreIndex = BookGenreComboBox.SelectedIndex;
                DVD newDVD = new DVD(title, creator, productNumber, genreIndex, languagIndex, duration);
                schoolbibDBContext.DVDs.Add(newDVD);
                schoolbibDBContext.SaveChanges();
            }
        }
        private void DVDAddButton_Click(object sender, RoutedEventArgs e)
        {
            AddDVD();
            UpdateUIDVD();
        }
        #endregion

        #region CD
        private bool CheckIfAllIsFilledCD()
        {
            bool allIsFilled = true;
            if (CdEANTextbox.Text == "" || CdTitleTextbox.Text == "" || CdArtistTextbox.Text == "" ||
            CdDurationTextbox.Text == "" || CdGenreComboBox.SelectedIndex == -1)
            {
                allIsFilled = false;
            }
            else
            {
                allIsFilled = true;
            }

            return allIsFilled; ;
        }
        private void UpdateUICD()
        {
            CdEANTextbox.Text = "";
            CdTitleTextbox.Text = "";
            CdArtistTextbox.Text = "";
            CdDurationTextbox.Text = "";
            CdGenreComboBox.SelectedIndex = -1;
        }
        private void AddCD()
        {

            if (CheckIfAllIsFilledCD() == true)
            {
                string title = CdTitleTextbox.Text;
                string creator = CdArtistTextbox.Text;
                long productNumber = Convert.ToInt64(CdEANTextbox.Text);
                int duration = Convert.ToInt32(CdDurationTextbox.Text);
                int genreIndex = CdGenreComboBox.SelectedIndex;
                CD newCD = new CD(title, creator, productNumber, genreIndex, duration);
                schoolbibDBContext.CDs.Add(newCD);
                schoolbibDBContext.SaveChanges();
            }
        }

        private void CDAddButton_Click(object sender, RoutedEventArgs e)
        {
            AddCD();
            UpdateUICD();
        }
        #endregion


    }
}
