﻿using System;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NoughtsAndCrossesApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MultiplayerPage : Page
    {
        string connectionString = @"Server=tcp:mygameserver.database.windows.net,1433;Initial Catalog=noughtsandcrossesDb;Persist Security Info=False;User ID=adgold;Password=Gold1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public MultiplayerPage()
        {
            this.InitializeComponent();
        }

        public void JoinGame()
        {
            int gameId = int.Parse(txtBoxGameId.Text);
            string result = "";
            int p2Result = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT GameId, P2Active FROM gameState WHERE GameId = " + gameId + ";";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = reader.GetInt32(0).ToString();
                            p2Result = reader.GetInt32(1);
                        }
                    }
                    if (result != "" && p2Result == 0)
                    {
                        command.CommandText = "UPDATE gameState SET P2Active = '1' WHERE GameId = " + gameId + ";";
                        command.ExecuteReader();
                        GameID.GID = gameId;
                        GameID.Player = 2;
                        Frame.Navigate(typeof(GamePage));
                    }
                    else
                    {
                        
                    }
                }
            }
        }

        public void CreateGame()
        {
            Random rand = new Random();
            int gameId = rand.Next(1000, 9999);
            string result = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT GameId FROM gameState WHERE GameId = " + gameId + ";";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = reader.GetInt32(0).ToString();
                        }
                    }
                    if (result == "")
                    {
                        command.CommandText = "INSERT INTO gameState(GameId, P1Active, P2Active, PlayersTurn, S1, S2, S3, S4, S5, S6, S7, S8, S9)" +
                            " VALUES(" + gameId + ", 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0);";
                        command.ExecuteReader();
                        GameID.GID = gameId;
                        GameID.Player = 1;
                        Frame.Navigate(typeof(GamePage));
                    }
                    else
                    {
                       CreateGame();
                    }
                }
            }
        }

        private void btnJoinGame_Click(object sender, RoutedEventArgs e)
        {
            JoinGame();
        }

        private void btnCreateGame_Click(object sender, RoutedEventArgs e)
        {
            CreateGame();
        }


    }
}