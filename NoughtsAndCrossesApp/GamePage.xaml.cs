using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Data.SqlClient;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NoughtsAndCrossesApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        string connectionString = @"Server=tcp:mygameserver.database.windows.net,1433;Initial Catalog=noughtsandcrossesDb;Persist Security Info=False;User ID=adgold;Password=Gold1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        int gameId = GameID.GID;
        int PlayersTurn;
        int P1Active;
        int P2Active;
        int S1;
        int S2;
        int S3;
        int S4;
        int S5;
        int S6;
        int S7;
        int S8;
        int S9;
        int i = 1;

        public GamePage()
        {
            this.InitializeComponent();
            txtBoxGameId.Text = "Game Id: " + gameId;
            UpdateTimer();
        }

        public async void UpdateTimer()
        {
            while(i == 1)
            {
                await Task.Delay(1000);
                UpdateBoardState(gameId);
            }
        }

        public void ActivePlayer(int gameId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT P1Active, P2Active FROM gameState WHERE GameId = " + gameId + ";";
                    using (SqlDataReader reader = command.ExecuteReader()) 
                    { 
                        while (reader.Read()) 
                        { 
                            P1Active = reader.GetInt32(0);
                            P2Active = reader.GetInt32(1);
                        } 
                    }
                    if (P1Active != 1)
                    {                        
                        command.CommandText = "UPDATE gameState SET P1Active = 1 WHERE GameId = " + gameId + ";";
                        command.ExecuteReader();  
                        P1Active = 1;
                        txtBoxP1A.Text = "Player 1: Active";

                    }
                    if (P2Active == 1) txtBoxP1A.Text = "Player 2: Active"; else txtBoxP2A.Text = "Player 2: Not Active";
                }
            }            
        }

        public void UpdateBoardState(int gameId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT S1, S2, S3, S4, S5, S6, S7, S8, S9, P1Active, P2Active, PlayersTurn FROM gameState WHERE GameId = " + gameId + ";";
                    using (SqlDataReader reader = command.ExecuteReader()) 
                    { 
                        while (reader.Read()) 
                        {    
                            S1 = reader.GetInt32(0);
                            S2 = reader.GetInt32(1);
                            S3 = reader.GetInt32(2);
                            S4 = reader.GetInt32(3);
                            S5 = reader.GetInt32(4);
                            S6 = reader.GetInt32(5);
                            S7 = reader.GetInt32(6);
                            S8 = reader.GetInt32(7);
                            S9 = reader.GetInt32(8);
                            P1Active = reader.GetInt32(9);
                            P2Active = reader.GetInt32(10);
                            PlayersTurn = reader.GetInt32(11);
                        } 
                    }                    
                }
            }
            if (P1Active == 1 && P2Active == 1 && PlayersTurn == GameID.Player) {
                if (S1 == 1) { btnSquare1.Content = "x"; btnSquare1.IsEnabled = false; } else if (S1 == 2) { btnSquare1.Content = "o"; btnSquare1.IsEnabled = false; } else { btnSquare1.Content = ""; btnSquare1.IsEnabled = true; }
                if (S2 == 1) { btnSquare2.Content = "x"; btnSquare2.IsEnabled = false; } else if (S2 == 2) { btnSquare2.Content = "o"; btnSquare2.IsEnabled = false; } else { btnSquare2.Content = ""; btnSquare2.IsEnabled = true; }
                if (S3 == 1) { btnSquare3.Content = "x"; btnSquare3.IsEnabled = false; } else if (S3 == 2) { btnSquare3.Content = "o"; btnSquare3.IsEnabled = false; } else { btnSquare3.Content = ""; btnSquare3.IsEnabled = true; }
                if (S4 == 1) { btnSquare4.Content = "x"; btnSquare4.IsEnabled = false; } else if (S4 == 2) { btnSquare4.Content = "o"; btnSquare4.IsEnabled = false; } else { btnSquare4.Content = ""; btnSquare4.IsEnabled = true; }
                if (S5 == 1) { btnSquare5.Content = "x"; btnSquare5.IsEnabled = false; } else if (S5 == 2) { btnSquare5.Content = "o"; btnSquare5.IsEnabled = false; } else { btnSquare5.Content = ""; btnSquare5.IsEnabled = true; }
                if (S6 == 1) { btnSquare6.Content = "x"; btnSquare6.IsEnabled = false; } else if (S6 == 2) { btnSquare6.Content = "o"; btnSquare6.IsEnabled = false; } else { btnSquare6.Content = ""; btnSquare6.IsEnabled = true; }
                if (S7 == 1) { btnSquare7.Content = "x"; btnSquare7.IsEnabled = false; } else if (S7 == 2) { btnSquare7.Content = "o"; btnSquare7.IsEnabled = false; } else { btnSquare7.Content = ""; btnSquare7.IsEnabled = true; }
                if (S8 == 1) { btnSquare8.Content = "x"; btnSquare8.IsEnabled = false; } else if (S8 == 2) { btnSquare8.Content = "o"; btnSquare8.IsEnabled = false; } else { btnSquare8.Content = ""; btnSquare8.IsEnabled = true; }
                if (S9 == 1) { btnSquare9.Content = "x"; btnSquare9.IsEnabled = false; } else if (S9 == 2) { btnSquare9.Content = "o"; btnSquare9.IsEnabled = false; } else { btnSquare9.Content = ""; btnSquare9.IsEnabled = true; }
            }
            else
            {
                if (S1 == 1) { btnSquare1.Content = "x"; btnSquare1.IsEnabled = false; } else if (S1 == 2) { btnSquare1.Content = "o"; btnSquare1.IsEnabled = false; } else { btnSquare1.Content = ""; btnSquare1.IsEnabled = false; }
                if (S2 == 1) { btnSquare2.Content = "x"; btnSquare2.IsEnabled = false; } else if (S2 == 2) { btnSquare2.Content = "o"; btnSquare2.IsEnabled = false; } else { btnSquare2.Content = ""; btnSquare2.IsEnabled = false; }
                if (S3 == 1) { btnSquare3.Content = "x"; btnSquare3.IsEnabled = false; } else if (S3 == 2) { btnSquare3.Content = "o"; btnSquare3.IsEnabled = false; } else { btnSquare3.Content = ""; btnSquare3.IsEnabled = false; }
                if (S4 == 1) { btnSquare4.Content = "x"; btnSquare4.IsEnabled = false; } else if (S4 == 2) { btnSquare4.Content = "o"; btnSquare4.IsEnabled = false; } else { btnSquare4.Content = ""; btnSquare4.IsEnabled = false; }
                if (S5 == 1) { btnSquare5.Content = "x"; btnSquare5.IsEnabled = false; } else if (S5 == 2) { btnSquare5.Content = "o"; btnSquare5.IsEnabled = false; } else { btnSquare5.Content = ""; btnSquare5.IsEnabled = false; }
                if (S6 == 1) { btnSquare6.Content = "x"; btnSquare6.IsEnabled = false; } else if (S6 == 2) { btnSquare6.Content = "o"; btnSquare6.IsEnabled = false; } else { btnSquare6.Content = ""; btnSquare6.IsEnabled = false; }
                if (S7 == 1) { btnSquare7.Content = "x"; btnSquare7.IsEnabled = false; } else if (S7 == 2) { btnSquare7.Content = "o"; btnSquare7.IsEnabled = false; } else { btnSquare7.Content = ""; btnSquare7.IsEnabled = false; }
                if (S8 == 1) { btnSquare8.Content = "x"; btnSquare8.IsEnabled = false; } else if (S8 == 2) { btnSquare8.Content = "o"; btnSquare8.IsEnabled = false; } else { btnSquare8.Content = ""; btnSquare8.IsEnabled = false; }
                if (S9 == 1) { btnSquare9.Content = "x"; btnSquare9.IsEnabled = false; } else if (S9 == 2) { btnSquare9.Content = "o"; btnSquare9.IsEnabled = false; } else { btnSquare9.Content = ""; btnSquare9.IsEnabled = false; }
            }
        }

        public void Move(int gameId, int s)
        {
            int nextMove;
            if (GameID.Player == 1) nextMove = 2;
            else nextMove = 1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {     
                    command.CommandText = "UPDATE gameState SET S" + s + " = " + GameID.Player + ", PlayersTurn = " + nextMove + " WHERE GameId = " + gameId + ";";
                    command.ExecuteReader(); 
                }
            }
        }

        private void btnSquare1_Click(object sender, RoutedEventArgs e)
        {
            Move(gameId, 1);
            S1 = GameID.Player;
        }

        private void btnSquare2_Click(object sender, RoutedEventArgs e)
        {
            Move(gameId, 2);
            S2 = GameID.Player;
        }

        private void btnSquare3_Click(object sender, RoutedEventArgs e)
        {
            Move(gameId, 3);
            S3 = GameID.Player;
        }

        private void btnSquare4_Click(object sender, RoutedEventArgs e)
        {
            Move(gameId, 4);
            S4 = GameID.Player;
        }

        private void btnSquare5_Click(object sender, RoutedEventArgs e)
        {
            Move(gameId, 5);
            S5 = GameID.Player;
        }

        private void btnSquare6_Click(object sender, RoutedEventArgs e)
        {
            Move(gameId, 6);
            S6 = GameID.Player;
        }

        private void btnSquare7_Click(object sender, RoutedEventArgs e)
        {
            Move(gameId, 7);
            S7 = GameID.Player;
        }

        private void btnSquare8_Click(object sender, RoutedEventArgs e)
        {
            Move(gameId, 8);
            S8 = GameID.Player;
        }

        private void btnSquare9_Click(object sender, RoutedEventArgs e)
        {
            Move(gameId, 9);
            S9 = GameID.Player;
        }     
    }
}
