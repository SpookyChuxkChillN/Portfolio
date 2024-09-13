This C# code defines a Windows Forms application for managing a list of songs. The MainForm class contains arrays to store song details such as title, artist, genre, year, and URL, with a maximum of five songs. The ValidInput method checks if the input fields are filled. The addButton_Click_1 method adds a new song to the list if the input is valid and the list is not full. The allSongsButton_Click method displays all songs in the list, while the findButton_Click_1 method searches for a song by title and displays its details. The PlayButton_Click_1 method plays the selected song’s URL in a WebView2 control. The clearButton_Click method clears the input fields, and the songList_SelectedIndexChanged_1 method displays the details of the selected song.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace Purnell_CourseProject_Part1
{
    public partial class MainForm : Form
    {
        // class level references
        string[] titleArray = new string[5];
        string[] artistArray = new string[5];
        string[] genreArray = new string[5];
        int[] yearArray = new int[5];
        string[] urlArray = new string[5];
        int songCount = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private bool ValidInput()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(titleText.Text))
            {
                // Title is blank
                MessageBox.Show("The song title cannot be blank.");
                isValid = false;
                titleText.Focus();
            }
            else if (string.IsNullOrEmpty(artistText.Text))
            {
                // Artist is blank
                MessageBox.Show("The artist cannot be blank.");
                isValid = false;
                artistText.Focus();
            }
            else if (string.IsNullOrEmpty(genreText.Text))
            {
                // Genre is blank
                MessageBox.Show("The genre cannot be blank.");
                isValid = false;
                genreText.Focus();
            }
            else if (string.IsNullOrEmpty(yearText.Text))
            {
                // Year is blank
                MessageBox.Show("The artist cannot be blank.");
                isValid = false;
                yearText.Focus();
            }
            else if (string.IsNullOrEmpty(urlText.Text))
            {
                // URL is blank
                MessageBox.Show("The Url cannot be blank.");
                isValid = false;
                urlText.Focus();
            }

            return isValid;
        }

        private int GetSongIndex(string songTitle)
        {
            //int songIndex = songList.Items.IndexOf( songTitle );
            //return songIndex;

            return songList.Items.IndexOf(songTitle);
        }



        private void allSongsButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(string.Empty);
            string nl = "\r\n";

            foreach (var item in songList.Items)
            {
                sb.Append(item.ToString());
                sb.Append(nl);
            }

            // Put the output text into the output textbox
            outputText.Text = sb.ToString();
        }

        private bool SongInList(string songTitle)
        {
            bool found = false;

            foreach (var item in songList.Items)
            {
                string currentSong = item as string;

                // lowercase comparison so not case sensitive
                if (songTitle.ToLower() == currentSong.ToLower())
                {
                    found = true;
                    break;
                }
            }

            return found;
        }






        private void PlayButton_Click_1(object sender, EventArgs e)
        {
            int songIndex = songList.SelectedIndex;
            string url = urlArray[songIndex];
            webViewDisplay.CoreWebView2.Navigate(url);

        }

        private void findButton_Click_1(object sender, EventArgs e)
        {
            if (SongInList(titleText.Text))
            {
                StringBuilder sb = new StringBuilder(string.Empty);
                string nl = "\r\n";

                int songIndex = GetSongIndex(titleText.Text);

                // build the output text
                sb.Append(titleArray[songIndex]);
                sb.Append(nl);
                sb.Append(artistArray[songIndex]);
                sb.Append(nl);
                sb.Append(genreArray[songIndex]);
                sb.Append(nl);
                sb.Append(yearArray[songIndex]);
                sb.Append(nl);
                sb.Append(urlArray[songIndex]);
                sb.Append(nl);

                outputText.Text = sb.ToString();

            }
        }//ends class

        private void clearButton_Click(object sender, EventArgs e)
        {
            // clear the fields
            titleText.Text = "";
            artistText.Clear();
            genreText.Clear();
            yearText.Clear();
            urlText.Clear();
            titleText.Focus(); // return insertion to this field
        }

        private void songList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(string.Empty);
            string nl = "\r\n";

            int songIndex = songList.SelectedIndex;

            // if song is selected, show the details
            if (songIndex != -1)
            {
                sb.Append(titleArray[songIndex]);
                sb.Append(nl);
                sb.Append(artistArray[songIndex]);
                sb.Append(nl);
                sb.Append(genreArray[songIndex]);
                sb.Append(nl);
                sb.Append(yearArray[songIndex]);
                sb.Append(nl);
                sb.Append(urlArray[songIndex]);
                sb.Append(nl);

                outputText.Text = sb.ToString();
            }
        }//ends namespace

        private void addButton_Click_1(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(outputText.Text);
            string nl = "\r\n";

            if (songCount == titleArray.Length)
            {
                MessageBox.Show("Song list is full!");
            }
            else if (ValidInput())
            {
                // add information to arrays and song list
                songList.Items.Add(titleText.Text);
                titleArray[songCount] = titleText.Text;
                artistArray[songCount] = artistText.Text;
                genreArray[songCount] += genreText.Text;
                yearArray[songCount] = int.Parse(yearText.Text);
                urlArray[songCount] = urlText.Text;

                // increment the song counter
                songCount++;

                // Build the output text
                sb.Append(titleText.Text);
                sb.Append(nl);
                sb.Append(artistText.Text);
                sb.Append(nl);
                sb.Append(genreText.Text);
                sb.Append(nl);
                sb.Append(yearText.Text);
                sb.Append(nl);
                sb.Append(urlText.Text);
                sb.Append(nl);

                outputText.Text = sb.ToString();

                // clear the field
                titleText.Clear();
                artistText.Clear();
                genreText.Clear();
                yearText.Clear();
                urlText.Clear();
                titleText.Focus(); // return insertion to this field
            }
        }
    }
}

           
    




