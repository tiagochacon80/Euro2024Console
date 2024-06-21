using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euro2024AppConsole.Models;
using MySql.Data.MySqlClient;

namespace Euro2024AppConsole.Data
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

        public List<Team> GetTeams()
        {
            List<Team> teams = new List<Team>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Teams";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Team team = new Team
                        {
                            Id = reader.GetInt32("Id"),
                            Name = reader.GetString("Name"),
                            Points = reader.GetInt32("Points"),
                            MatchesPlayed = reader.GetInt32("MatchesPlayed"),
                            Wins = reader.GetInt32("Wins"),
                            Draws = reader.GetInt32("Draws"),
                            Losses = reader.GetInt32("Losses"),
                            GoalsFor = reader.GetInt32("GoalsFor"),
                            GoalsAgainst = reader.GetInt32("GoalsAgainst")
                        };
                        teams.Add(team);
                    }
                }
            }
            return teams;
        }

        public bool UpdatePoints(int teamId, string result)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "";

                if (result == "Win")
                {
                    query = "UPDATE Teams SET Points = Points + 3, Wins = Wins + 1 WHERE Id = @Id";
                }
                else if (result == "draw")
                {
                    query = "UPDATE Teams SET Points = Points + 1, Draws = Draws + 1 WHERE Id = @Id";
                }
                else if (result == "loss")
                {
                    query = "UPDATE Teams SET Losses = Losses + 1 WHERE Id = @Id";
                }

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", teamId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateScore(int teamId, int goalsFor, int goalsAgainst)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Teams SET = GoalsFor + @GoalsFor, GoalsAgainst = GoalsAgainst + @GoalsAgainst WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", teamId);
                cmd.Parameters.AddWithValue("@GoalsFor", goalsFor);
                cmd.Parameters.AddWithValue("@GoalsAgainst", goalsAgainst);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteTeam(int teamId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Teams WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", teamId);
                return cmd.ExecuteNonQuery() > 0;
            }

        }
    }
}
