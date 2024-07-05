using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euro2024AppConsole.Models;
using Org.BouncyCastle.Utilities.IO;

namespace Euro2024AppConsole.Data
{
    public class TeamRepository
    {
        private readonly Database _database;

        public TeamRepository(Database database)
        {
            _database = database;
        }
        public bool AddTeam(Team team)
        {
            try
            {
                using (var conn = _database.GetConnection())
                {
                    conn.Open();
                    var query = "INSERT INTO Teams (Id, Name, Points, MatchesPlayed, Wins, Draws, Losses, GoalsFor, GoalsAgainst) VALUES (@Id, @Name, @Points, @MatchesPlayed, @Wins, @Draws, @Losses, @GoalsFor, @GoalsAgainst)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
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
            catch (MySqlException ex)
            {
                Console.WriteLine($"Database error while adding team with ID: {team.Id}: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred while adding team with ID: {team.Id}: {ex.Message}");
                return false;
            }

        }

        public List<Team> GetTeams()
        {
            try
            {
                var teams = new List<Team>();
                using (var conn = _database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM Teams";
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var team = new Team
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
            catch (MySqlException ex)
            {
                Console.WriteLine($"Database error while retrieving teams: {ex.Message}");
                return new List<Team>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred while retrieving teams: {ex.Message}");
                return new List<Team>();
            }
        }

        public bool UpdatePoints(int teamId, string result)
        {
            try
            {
                using (var conn = _database.GetConnection())
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

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", teamId);
                        return cmd.ExecuteNonQuery() > 0;
                    }                   
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Database error while updating points for Team ID {teamId}: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred while updating points for Team ID {teamId}: {ex.Message}");
                return false;
            }
            
        }

        public bool UpdateScore(int teamId, int goalsFor, int goalsAgainst)
        {
            try
            {
                using (var conn = _database.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Teams SET = GoalsFor + @GoalsFor, GoalsAgainst = GoalsAgainst + @GoalsAgainst WHERE Id = @Id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", teamId);
                        cmd.Parameters.AddWithValue("@GoalsFor", goalsFor);
                        cmd.Parameters.AddWithValue("@GoalsAgainst", goalsAgainst);
                        return cmd.ExecuteNonQuery() > 0;
                    }                    
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Database error while updating score for Team ID {teamId}: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error while updating score for Team ID {teamId}: {ex.Message}");
                return false;
            }
            
        }

        public bool DeleteTeam(int teamId)
        {
            try
            {
                using (var conn = _database.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Teams WHERE Id = @Id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", teamId);
                        return cmd.ExecuteNonQuery() > 0;
                    }

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Database error while deleting team with ID {teamId}: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred while deleting team with ID {teamId}: {ex.Message}");
                return false;
            }

        }
    }
}
