using System;
using System.Net.Mime;
using System.Runtime;
using System.Windows.Forms;
using WindowsFormsApp2.model;

namespace WindowsFormsApp2
{
    public partial class MainForm : Form
    {
        private Service service;

        public Service Service
        {
            get { return service;}
            set { service = value; }
        }
        public MainForm()
        {
            InitializeComponent();
        }

        private void mainLoad(object sender, EventArgs e)
        {
            labelErr.Visible = false;
            listViewConcerts.View = View.List;
            listViewConcertsDate.View = View.List;
            loadConcerts();
        }

        private void loadConcerts()
        {
            listViewConcerts.Clear();
            foreach (Concert concert in service.ServiceConcert.findAll())
            {
                Artist artist = service.ServiceArtist.findOne(concert.ArtistId);
                listViewConcerts.Items.Add(artist.Name + "/" + concert.Date + "/" + concert.ConcertLocation + "/" +
                                           concert.TicketsAvailable.ToString() + "/" +
                                           concert.TicketsSold.ToString() + "/" + concert.StartTime);
                
            }
        }

        private void OnSearchButtonClick(object sender, EventArgs e)
        {
            listViewConcertsDate.Clear();
            if(dataBox.Text.ToString()=="")
                return;
            foreach (Concert concert in service.ServiceConcert.getConcertsByDate(dataBox.Text.ToString()))
            {
                Artist artist = service.ServiceArtist.findOne(concert.ArtistId);
                listViewConcertsDate.Items.Add(artist.Name + "/" + concert.Date + "/" + concert.ConcertLocation + "/" +
                                           concert.TicketsAvailable.ToString() + "/" +
                                           concert.TicketsSold.ToString() + "/" + concert.StartTime);
                
            }
        }

        private void OnBuyButtonClick(object sender, EventArgs e)
        {
            if (nameBox.Text.ToString() == "" || ticketsBox.Text.ToString() == "" ||
                listViewConcerts.SelectedItems.Count != 1)
                return;
            string selected = listViewConcerts.SelectedItems[0].Text.ToString();
            string[] data = selected.Split('/');
            Concert concert = service.ServiceConcert.getConcertByDateLocationStart(data[1], data[2], data[5]);
            if(concert.TicketsAvailable<Convert.ToInt32(ticketsBox.Text))
            {
                labelErr.Visible = true;
                labelErr.Text = "Not enough tickets available!";
                return;
            }
            service.ServiceOrder.save(concert.Id, nameBox.Text.ToString(),
                Convert.ToInt32(ticketsBox.Text.ToString()));
            service.ServiceConcert.updateConcertTickets(concert.Id,Convert.ToInt32(ticketsBox.Text.ToString()));
            loadConcerts();
        }

        private void OnLogOutButtonClick(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Service = service;
            login.Show();
        }


       
    }
}