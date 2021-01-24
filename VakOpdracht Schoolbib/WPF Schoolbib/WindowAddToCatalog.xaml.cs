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
        LibraryRepository libraryRepository = new LibraryRepository();
        string book = "BOOK";
        string cd = "CD";
        string dvd = "DVD";
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

        //checken of alles ingevuld is
        //item toevoegen als klassobject en aan DB
        //alle velden leegmaken
        private void BookAddButton_Click(object sender, RoutedEventArgs e)
        {
            AddItem(book);
            MakeAllFieldsEmpty(book);
        }
        private void CDAddButton_Click(object sender, RoutedEventArgs e)
        {
            AddItem(cd);
            MakeAllFieldsEmpty(cd);
        }
        private void DVDAddButton_Click(object sender, RoutedEventArgs e)
        {
            AddItem(dvd);
            MakeAllFieldsEmpty(dvd);
        }
        private void AddItem(string Item)
        {
            if (Item == book)
            {
                if (CheckIfAllFieldsAreFilled(book) == true)
                {
                    string title = BookTitletextbox.Text;
                    string Author = BookAuthortextbox.Text;
                    long ISBNCode = Convert.ToInt64(BookISBNtextbox.Text);
                    int languageIndex = BookLanguageComboBox.SelectedIndex;
                    int pages = Convert.ToInt32(BookPagestextbox.Text);
                    int genreIndex = BookGenreComboBox.SelectedIndex;
                    string publisher = BookPublishertextbox.Text;
                    Library newBook = new Books(title, Author, ISBNCode, AvailabilityItem.Aanwezig, genreIndex, languageIndex, pages, publisher);
                    libraryRepository.CreateLibraryItem(newBook);
                }
            }
            else if (Item == cd)
            {
                if (CheckIfAllFieldsAreFilled(cd) == true)
                {
                    string title = CdTitleTextbox.Text;
                    string creator = CdArtistTextbox.Text;
                    long productNumber = Convert.ToInt64(CdEANTextbox.Text);
                    int duration = Convert.ToInt32(CdDurationTextbox.Text);
                    int genreIndex = CdGenreComboBox.SelectedIndex;
                    Library newCD = new CD(title, creator, productNumber, AvailabilityItem.Aanwezig, genreIndex, duration);
                    libraryRepository.CreateLibraryItem(newCD);
                }
            }
            else if (Item == dvd)
            {
                if (CheckIfAllFieldsAreFilled(dvd) == true)
                {
                    string title = DvdTitleTextbox.Text;
                    string creator = DvdDirectorTextbox.Text;
                    long productNumber = Convert.ToInt64(DvdEANTextbox.Text);
                    int languagIndex = DvdLanguageComboBox.SelectedIndex;
                    int duration = Convert.ToInt32(DvdDurationTextbox.Text);
                    int genreIndex = DvdGenreComboBox.SelectedIndex;
                    Library newDVD = new DVD(title, creator, productNumber, AvailabilityItem.Aanwezig, genreIndex, languagIndex, duration);
                    libraryRepository.CreateLibraryItem(newDVD);

                }
            }
        }
        private bool CheckIfAllFieldsAreFilled(string item)
        {
            bool allIsFilled = true;
            if (item == book)
            {
                if (BookTitletextbox.Text == "" || BookAuthortextbox.Text == "" || BookISBNtextbox.Text == "" ||
               BookLanguageComboBox.SelectedIndex == -1 || BookPagestextbox.Text == "" || BookGenreComboBox.SelectedIndex == -1 || BookPublishertextbox.Text == "")
                {
                    allIsFilled = false;
                }
                else
                {
                    allIsFilled = true;
                }
            }
            else if (item == cd)
            {
                if (CdEANTextbox.Text == "" || CdTitleTextbox.Text == "" || CdArtistTextbox.Text == "" ||
                    CdDurationTextbox.Text == "" || CdGenreComboBox.SelectedIndex == -1)
                {
                    allIsFilled = false;
                }
                else
                {
                    allIsFilled = true;
                }
            }
            else if (item == dvd)
            {
                if (DvdEANTextbox.Text == "" || DvdTitleTextbox.Text == "" || DvdDirectorTextbox.Text == "" ||
                DvdLanguageComboBox.SelectedIndex == -1 || DvdDurationTextbox.Text == "" || DvdGenreComboBox.SelectedIndex == -1)
                {
                    allIsFilled = false;
                }
                else
                {
                    allIsFilled = true;
                }
            }
            return allIsFilled;
        }
        private void MakeAllFieldsEmpty(string item)
        {
            if (item == book)
            {
                BookTitletextbox.Text = "";
                BookAuthortextbox.Text = "";
                BookISBNtextbox.Text = "";
                BookLanguageComboBox.SelectedIndex = -1;
                BookPagestextbox.Text = "";
                BookGenreComboBox.SelectedIndex = -1;
                BookPublishertextbox.Text = "";
            }
            else if (item == cd)
            {
                CdEANTextbox.Text = "";
                CdTitleTextbox.Text = "";
                CdArtistTextbox.Text = "";
                CdDurationTextbox.Text = "";
                CdGenreComboBox.SelectedIndex = -1;
            }
            else if (item == dvd)
            {
                DvdEANTextbox.Text = "";
                DvdTitleTextbox.Text = "";
                DvdDirectorTextbox.Text = "";
                DvdLanguageComboBox.SelectedIndex = -1;
                DvdDurationTextbox.Text = "";
                DvdGenreComboBox.SelectedIndex = -1;
            }
        }

    }
}
