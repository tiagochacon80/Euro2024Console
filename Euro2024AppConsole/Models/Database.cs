using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Euro2024AppConsole.Models
{
    public class Database
    {
        public string connectionString;
        
        public Database(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool AddTeam(Team team)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Teams (Id, Name, Points, MatchesPlayed, Wins, Draws, Losses, GoalsFor, GoalsAgainst) VALUES (@Id, @Name, @Points, @MatchesPlayed, @Wins, @Draws, @Losses, @GoalsFor, @GoalsAgainst)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", team.Id);
                cmd.Parameters.AddWithValue("@Name", team.Name);
                cmd.Parameters.AddWithValue("@Points", team.Points);
                cmd.Parameters.AddWithValue("@MatchesPlayed", team.MatchesPlayed);
                cmd.Parameters.AddWithValue("@Wins", team.Wins);
                cmd.Parameters.AddWithValue("@Draws", team.Draws);
                cmd.Parameters.AddWithValue("@Losses", team.Losses);
                cmd.Parameters.AddWithValue("@GoalsFor", team.GoalsFor);
                cmd.Parameters.AddWithValue("@GoalsAgainst", team.GoalsAgainst);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
