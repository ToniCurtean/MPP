using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using model;
using services;

namespace client
{
    public partial class FestivalWindow : Form
    {
        private Cashier cashier;
        
        private readonly FestivalClientCtrl ctrl;

        private readonly IList<String> concertsData;

        private readonly IList<String> concertsDateData;
        public FestivalWindow(FestivalClientCtrl ctrl,Cashier cashier)
        {
            InitializeComponent();
            this.ctrl = ctrl;
            this.cashier = cashier;
            ///this.ctrl.updateEvent += updateListView;
        }
        
        private void mainLoad(object sender, EventArgs e)
        {
            label1.Text = "aici!";
            concertsView.View = View.List;
            concertsDateView.View = View.List;
            LoadConcerts();
        }

        public void LoadConcerts()
        {
            concertsView.Clear();
            ConcertInfo[] concertsInfo =ctrl.GetConcertsInfos();
            foreach (ConcertInfo info in concertsInfo)
            {
                concertsView.Items.Add(info.artistName+"/"+info.date + "/" + info.concertLocation + "/" +
                                       info.ticketsAvailable.ToString() + "/" +
                                       info.ticketsSold.ToString() + "/" + info.startTime+"/"+info.concertId.ToString());
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (dateText.Text == "")
                return;
            concertsDateView.Clear();
            ConcertInfo[] concertsInfo = ctrl.getConcertInfosByDate(dateText.Text);
            foreach (ConcertInfo info in concertsInfo)
            {
                concertsDateView.Items.Add(info.artistName+"/"+info.date + "/" + info.concertLocation + "/" +
                                           info.ticketsAvailable.ToString() + "/" +
                                           info.ticketsSold.ToString() + "/" + info.startTime+"/"+info.concertId.ToString());
            }
        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            if (buyerText.Text == "" || ticketsText.Text == "")
                return;
            string selected = concertsView.SelectedItems[0].Text.ToString();
            string[] data = selected.Split('/');
            int concertId = int.Parse(data[6]);
            string buyerName = buyerText.Text;
            int nrTickets = int.Parse(ticketsText.Text);
            ctrl.buyTickets(concertId, buyerName, nrTickets);
        }
        
        public delegate void UpdateContent();

        private void logoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                ctrl.LogOut();
                this.Close();
            }
            catch (FestivalException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}