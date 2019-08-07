using System.Windows;
using System.Data.SQLite;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace teamgenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Player> squadList = new List<Player>();
        
        public MainWindow()
        {
            InitializeComponent();
        }
        void OnLoad(object sender, RoutedEventArgs e)
        {
            InitializeDbAndPopulateParameters();
            if (!squadList.Select(x => x.PlayerId).Any())
                return;
            ListBoxTeamOverview.ItemsSource = squadList.Select(x => x.PlayerName).ToList();
        }

        private void InitializeDbAndPopulateParameters()
        {
            if (!File.Exists("db_team.sqlite"))
                SQLiteConnection.CreateFile("db_team.sqlite");
            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=db_team.sqlite;Version=3;"))
            {
                dbConnection.Open();
                List<string> tableNames = new List<string>();
                string sql = "SELECT name FROM sqlite_master WHERE type = 'table'";
                using (SQLiteCommand dbCommand = new SQLiteCommand(sql, dbConnection))
                {
                    using (SQLiteDataReader dbreader = dbCommand.ExecuteReader())
                    {
                        while (dbreader.Read())
                        {
                            string tableName = dbreader.GetString(0);
                            tableNames.Add(tableName);
                        }
                    }
                }
                sql = "CREATE TABLE PLAYER_INFO(PLAYERID NUMBER, NAME VARCHAR2(100),GOALKEEPING NUMBER, TECHNICAL NUMBER,MENTAL NUMBER, PHYSICAL NUMBER)";
                if (!tableNames.Where(x => x == "PLAYER_INFO").Any())
                {
                    using (SQLiteCommand dbCommand = new SQLiteCommand(sql, dbConnection))
                    {
                        dbCommand.ExecuteNonQuery();
                    }
                }
                sql = "CREATE TABLE HISTORY_MATCH (DATETIME TIMESTAMP,PLAYERID NUMBER,COEFFICIENCY NUMBER)";
                if (!tableNames.Where(x => x == "HISTORY_MATCH").Any())
                {
                    using (SQLiteCommand dbCommand = new SQLiteCommand(sql, dbConnection))
                    {
                        dbCommand.ExecuteNonQuery();
                    }
                }
                sql = "SELECT * FROM PLAYER_INFO";
                using (SQLiteCommand dbCommand = new SQLiteCommand(sql, dbConnection))
                {
                    using (SQLiteDataReader dbreader = dbCommand.ExecuteReader())
                    {
                        while (dbreader.Read())
                        {
                            Player TmpPlayer = new Player();
                            TmpPlayer.PlayerId = Convert.ToInt32(dbreader.GetDecimal(0));
                            TmpPlayer.PlayerName = dbreader.GetString(1);
                            TmpPlayer.GoalKeeping = Convert.ToInt32(dbreader.GetDecimal(2));
                            TmpPlayer.Technical = Convert.ToInt32(dbreader.GetDecimal(3));
                            TmpPlayer.Mental = Convert.ToInt32(dbreader.GetDecimal(4));
                            TmpPlayer.Physical = Convert.ToInt32(dbreader.GetDecimal(5));
                            squadList.Add(TmpPlayer);
                        }
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
