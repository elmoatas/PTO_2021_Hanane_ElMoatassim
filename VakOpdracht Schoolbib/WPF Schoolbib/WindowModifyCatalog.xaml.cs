﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WPF_Schoolbib.Models;


namespace WPF_Schoolbib
{
    /// <summary>
    /// Interaction logic for WindowModifyCatalog.xaml
    /// </summary>
    public partial class WindowModifyCatalog : Window
    {
        LibraryRepository libraryRepository = new LibraryRepository();
        StudentRepository studentRepository = new StudentRepository();
        public WindowModifyCatalog()
        {
            InitializeComponent();
            ShowLibraryInListbox();
            LoadLanguagesInComboBox();
            LoadGenreInComboBox();
        }
        private void ShowLibraryInListbox()
        {
            Listbox.ItemsSource = null;
            Listbox.ItemsSource = libraryRepository.GetAllLibraryItems();
        }
        private void LoadLanguagesInComboBox()
        {
            string[] languages = Enum.GetNames(typeof(LanguageEnum));
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
        private void MakeAllFieldsEmpty()
        {

            BookTitletextbox.Text = "";
            BookAuthortextbox.Text = "";
            BookISBNtextbox.Text = "";
            BookLanguageComboBox.SelectedIndex = -1;
            BookPagestextbox.Text = "";
            BookGenreComboBox.SelectedIndex = -1;
            BookPublishertextbox.Text = "";

            CdEANTextbox.Text = "";
            CdTitleTextbox.Text = "";
            CdArtistTextbox.Text = "";
            CdDurationTextbox.Text = "";
            CdGenreComboBox.SelectedIndex = -1;

            DvdEANTextbox.Text = "";
            DvdTitleTextbox.Text = "";
            DvdDirectorTextbox.Text = "";
            DvdLanguageComboBox.SelectedIndex = -1;
            DvdDurationTextbox.Text = "";
            DvdGenreComboBox.SelectedIndex = -1;

        }



        private void ShowInfo()
        {
            if (Listbox.SelectedItem != null)
            {
                Library selected = (Library)Listbox.SelectedItem; ;
                if (selected is Books book)
                {
                    BookGroupBox.Visibility = Visibility.Visible;
                    CDGroupBox.Visibility = Visibility.Hidden;
                    DVDGroupBox.Visibility = Visibility.Hidden;
                    BookTitletextbox.Text = book.Title;
                    BookAuthortextbox.Text = book.Creator;
                    BookISBNtextbox.Text = book.ProductNumber.ToString();
                    BookLanguageComboBox.SelectedIndex = book.LanguageIndex;
                    BookPagestextbox.Text = book.Pages.ToString();
                    BookGenreComboBox.SelectedIndex = book.GenreIndex;
                    BookPublishertextbox.Text = book.Publisher;

                }
                else if (selected is CD cd)
                {
                    CDGroupBox.Visibility = Visibility.Visible;
                    BookGroupBox.Visibility = Visibility.Hidden;
                    DVDGroupBox.Visibility = Visibility.Hidden;
                    CdTitleTextbox.Text = cd.Title;
                    CdArtistTextbox.Text = cd.Creator;
                    CdEANTextbox.Text = cd.ProductNumber.ToString();
                    CdDurationTextbox.Text = cd.Duration.ToString();
                    CdGenreComboBox.SelectedIndex = cd.GenreIndex;



                }
                else if (selected is DVD dvd)
                {
                    DVDGroupBox.Visibility = Visibility.Visible;
                    CDGroupBox.Visibility = Visibility.Hidden;
                    BookGroupBox.Visibility = Visibility.Hidden;
                    DvdTitleTextbox.Text = dvd.Title;
                    DvdDirectorTextbox.Text = dvd.Creator;
                    DvdEANTextbox.Text = dvd.ProductNumber.ToString();
                    DvdLanguageComboBox.SelectedIndex = dvd.LanguageIndex;
                    DvdDurationTextbox.Text = dvd.Duration.ToString();
                    DvdGenreComboBox.SelectedIndex = dvd.GenreIndex;

                }
            }
        }

        private void EraseButton_Click(object sender, RoutedEventArgs e)
        {
            Library selected = (Library)Listbox.SelectedItem; 
            if(selected.Availability == AvailabilityItem.Uitgeleend)
            {
                MessageBox.Show($"Verwijderen niet mogelijk! Item is uitgeleend. gelieve Item Eerst in te leveren.");
            }
            else
            {
                libraryRepository.DeleteLibraryItems(selected);
                ShowLibraryInListbox();
                MakeAllFieldsEmpty();
            }
           
        }
        private void EditItem()
        {
            Library selected = (Library)Listbox.SelectedItem; ;
            if (selected is Books book)
            {
                book.Title = BookTitletextbox.Text;
                book.Creator = BookAuthortextbox.Text;
                book.ProductNumber = Convert.ToInt64(BookISBNtextbox.Text);
                book.LanguageIndex = BookLanguageComboBox.SelectedIndex;
                book.Pages = Convert.ToInt32(BookPagestextbox.Text);
                book.GenreIndex = BookGenreComboBox.SelectedIndex;
                book.Publisher = BookPublishertextbox.Text;

                libraryRepository.UpdateLibraryItems(book);

            }
            else if (selected is CD cd)
            {
                cd.Title = CdTitleTextbox.Text;
                cd.Creator = CdArtistTextbox.Text;
                cd.ProductNumber = Convert.ToInt64(CdEANTextbox.Text);
                cd.Duration = Convert.ToInt32(CdDurationTextbox.Text);
                cd.GenreIndex = CdGenreComboBox.SelectedIndex;
             
                libraryRepository.UpdateLibraryItems(cd);

            }
            else if (selected is DVD dvd)
            {

                dvd.Title = DvdTitleTextbox.Text;
                dvd.Creator = DvdDirectorTextbox.Text;
                dvd.ProductNumber = Convert.ToInt64(DvdEANTextbox.Text);
                dvd.LanguageIndex = DvdLanguageComboBox.SelectedIndex;
                dvd.Duration = Convert.ToInt32(DvdDurationTextbox.Text);
                dvd.GenreIndex = BookGenreComboBox.SelectedIndex;
             
                libraryRepository.UpdateLibraryItems(dvd);
            }
        }
        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            EditItem();
            MakeAllFieldsEmpty();
            ShowLibraryInListbox();
        }

        private void Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowInfo();
        }

        private void Filter_Checked(object sender, RoutedEventArgs e)
        {
            Listbox.ItemsSource = null;
            List<Library> filteredItems= new List<Library>();
            if (BookFilter.IsChecked == true)
            {
                filteredItems.AddRange(libraryRepository.GetAllBooks());
            }
            else
            {
                foreach (Library item in libraryRepository.GetAllBooks())
                {
                    filteredItems.Remove(item);
                }
            }

            if (CDFilter.IsChecked == true)
            {
                filteredItems.AddRange(libraryRepository.GetAllCds());
            }
            else
            {
                foreach (Library item in libraryRepository.GetAllCds())
                {
                    filteredItems.Remove(item);
                }
            }

            if (DVDFilter.IsChecked == true)
            {
                filteredItems.AddRange(libraryRepository.GetAllDvds());
            }
            else
            {
                foreach (Library item in libraryRepository.GetAllDvds())
                {
                    filteredItems.Remove(item);
                }
            }
            if (CDFilter.IsChecked==false &&  DVDFilter.IsChecked == false && BookFilter.IsChecked == false )
            {
                 filteredItems = libraryRepository.GetAllLibraryItems();
            }
        
          Listbox.ItemsSource = filteredItems;
        }
    }
}
