using EntFrmLab2.DAL;
using EntFrmLab2.DAL.Models;
using System.Linq;
using System.Text;

namespace EntFrmLab2
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Відобразити всю інформацію про команди.");
                Console.WriteLine("2. Пошук команди за назвою.");
                Console.WriteLine("3. Пошук команди за назвою міста.");
                Console.WriteLine("4. Пошук команди за назвою міста та команди.");
                Console.WriteLine("5. Відображення команди з найбільшою кількістю перемог.");
                Console.WriteLine("6. Відображення команди з найбільшою кількістю поразок..");
                Console.WriteLine("7. Відображення команди з найбільшою кількістю ігор у нічию..");
                Console.WriteLine("8. Відображення команди з найбільшою кількістю забитих голів.");
                Console.WriteLine("9. Відображення команди з найбільшою кількістю пропущених голів.");
                Console.WriteLine("10. Додати команду.");
                Console.WriteLine("11. Обновити дані команди.");
                Console.WriteLine("12. Видалити команду.");
                Console.WriteLine("0. Вийти з програми");

                Console.Write("Виберіть опцію: ");
                choice = int.Parse(Console.ReadLine());
                try
                {
                    switch (choice)
                    {
                        case 1:
                            ShowData();
                            break;
                        case 2:
                            SearchTeamByName();
                            break;
                        case 3:
                            SearchTeamsByCity();
                            break;
                        case 4:
                            SearchTeamByNameAndCity();
                            break;
                        case 5:
                            DisplayTeamWithMostWins();
                            break;
                        case 6:
                            DisplayTeamWithMostLosses();
                            break;
                        case 7:
                            DisplayTeamWithMostDraws();
                            break;
                        case 8:
                            DisplayTeamWithMostGoalsScored();
                            break;
                        case 9:
                            DisplayTeamWithMostGoalsConceded();
                            break;
                        case 10:
                            InsertData();
                            break;
                        case 11:
                            UpdateTeamData();
                            break;
                        case 12:
                            DeleteTeam();
                            break;
                        case 0:
                            Console.WriteLine("Poka!");
                            break;
                        default:
                            Console.WriteLine("Неправильний вибір.");
                            break;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
                Console.ReadLine();
            } while (choice != 0);

        }


        public static void DisplayTeamWithMostWins()
        {
            using (var context = new Context())
            {
                var teamWithMostWins = context.Teams.OrderByDescending(t => t.GameWin).FirstOrDefault();
                if (teamWithMostWins != null)
                {
                    Console.WriteLine($"Team with the most wins: {teamWithMostWins.TeamName}, Wins:{teamWithMostWins.GameWin}");
                }
                else
                {
                    Console.WriteLine("No team information available.");
                }
            }
        }

        public static void DisplayTeamWithMostLosses()
        {
            using (var context = new Context())
            {
                var teamWithMostLosses = context.Teams.OrderByDescending(t => t.GameLoss).FirstOrDefault();
                if (teamWithMostLosses != null)
                {
                    Console.WriteLine($"Team with the most losses: {teamWithMostLosses.TeamName}, Lose's:{teamWithMostLosses.GameLoss}");
                }
                else
                {
                    Console.WriteLine("No team information available.");
                }
            }
        }

        public static void DisplayTeamWithMostDraws()
        {
            using (var context = new Context())
            {
                var teamWithMostDraws = context.Teams.OrderByDescending(t => t.GameTie).FirstOrDefault();
                if (teamWithMostDraws != null)
                {
                    Console.WriteLine($"Team with the most draws: {teamWithMostDraws.TeamName}, Draws: {teamWithMostDraws.GameTie}");
                }
                else
                {
                    Console.WriteLine("No team information available.");
                }
            }
        }

        public static void DisplayTeamWithMostGoalsScored()
        {
            using (var context = new Context())
            {
                var teamWithMostGoalsScored = context.Teams.OrderByDescending(t => t.ScoredGoals).FirstOrDefault();
                if (teamWithMostGoalsScored != null)
                {
                    Console.WriteLine($"Team with the most goals scored: {teamWithMostGoalsScored.TeamName}, Goal's scored: {teamWithMostGoalsScored.ScoredGoals}");
                }
                else
                {
                    Console.WriteLine("No team information available.");
                }
            }
        }

        public static void DisplayTeamWithMostGoalsConceded()
        {
            using (var context = new Context())
            {
                var teamWithMostGoalsConceded = context.Teams.OrderByDescending(t => t.MissedHeads).FirstOrDefault();
                if (teamWithMostGoalsConceded != null)
                {
                    Console.WriteLine($"Team with the most goals conceded: {teamWithMostGoalsConceded.TeamName}, Goals conceded: {teamWithMostGoalsConceded.MissedHeads}");
                }
                else
                {
                    Console.WriteLine("No team information available.");
                }
            }
        }


        public static void SearchTeamByName()
        {
            using (var context = new Context())
            {
                Console.WriteLine("Write searched team name:");
                string teamName = Console.ReadLine();
                var team = context.Teams.FirstOrDefault(t => t.TeamName.ToUpper() == teamName.ToUpper());
                if (team != null)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine($"Team Name: {teamName}");
                    Console.WriteLine($"City: {team.TeamCity}");
                    Console.WriteLine($"Wins: {team.GameWin}");
                    Console.WriteLine($"lose's: {team.GameLoss}");
                    Console.WriteLine($"Tie's: {team.GameTie}");
                    Console.WriteLine($"Scored goal's: {team.ScoredGoals}");
                    Console.WriteLine($"Missed goal's: {team.MissedHeads}");
                }
                else
                {
                    Console.WriteLine($"Team with name '{teamName}' not found.");
                }
            }
        }

        public static void SearchTeamsByCity()
        {
            using (var context = new Context())
            {
                Console.WriteLine("Write searched team city:");
                string city = Console.ReadLine();
                var teams = context.Teams.Where(t => t.TeamCity.ToUpper() == city.ToUpper());
                if (teams.Any())
                {
                    Console.WriteLine($"Team's in City '{city}':");
                    foreach (var team in teams)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine($"Team Name: {team.TeamName}");
                        Console.WriteLine($"City: {team.TeamCity}");
                        Console.WriteLine($"Wins: {team.GameWin}");
                        Console.WriteLine($"lose's: {team.GameLoss}");
                        Console.WriteLine($"Tie's: {team.GameTie}");
                        Console.WriteLine($"Scored goal's: {team.ScoredGoals}");
                        Console.WriteLine($"Missed goal's: {team.MissedHeads}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine($"Team with city name '{city}' not found.");
                }
            }
        }

        public static void SearchTeamByNameAndCity()
        {
            using (var context = new Context())
            {
                Console.WriteLine("Write searched team city:");
                string city = Console.ReadLine();
                Console.WriteLine("Write searched team name:");
                string teamName = Console.ReadLine();
                var team = context.Teams.FirstOrDefault(t => t.TeamName.ToUpper() == teamName.ToUpper() && t.TeamCity.ToUpper() == city.ToUpper());
                if (team != null)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine($"Information abt team '{teamName}' in '{city}':");
                    Console.WriteLine($"Team Name: {teamName}");
                    Console.WriteLine($"City: {team.TeamCity}");
                    Console.WriteLine($"Wins: {team.GameWin}");
                    Console.WriteLine($"lose's: {team.GameLoss}");
                    Console.WriteLine($"Tie's: {team.GameTie}");
                    Console.WriteLine($"Scored goal's: {team.ScoredGoals}");
                    Console.WriteLine($"Missed goal's: {team.MissedHeads}");
                }
                else
                {
                    Console.WriteLine($"Team with name '{teamName}' in city '{city}' not found.");
                }
            }
        }


        public static void ShowData()
        {
            using (var context = new Context())
            {
                var teams = context.Teams;
                foreach (var football in teams)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine($"Name:{football.TeamName}");
                    Console.WriteLine($"City:{football.TeamCity}");
                    Console.WriteLine($"Wins:{football.GameWin}");
                    Console.WriteLine($"Loss:{football.GameLoss}");
                    Console.WriteLine($"Tie's:{football.GameTie}");
                    Console.WriteLine($"Scored goals:{football.ScoredGoals}");
                    Console.WriteLine($"Missed Goals:{football.MissedHeads}");
                    Console.WriteLine("\n");
                }
            }
        }

        public static FootballTeams MapData()
        {
            FootballTeams football = new FootballTeams();

            Console.WriteLine("Football Team Name:");
            string teamName = Console.ReadLine();

            bool teamExists; 

            using (var context = new Context())
            {

                teamExists = context.Teams.Any(t => t.TeamName.ToUpper() == teamName.ToUpper());
            }

            if (teamExists)
            {
                Console.WriteLine($"Team with that name '{teamName}' already exists in the application.");
                return null;
            }

            football.TeamName = teamName;

            Console.WriteLine("Football Team City:");
            football.TeamCity = Console.ReadLine();

            Console.WriteLine("Football Team Wins:");
            int.TryParse(Console.ReadLine(), out int buffer);
            football.GameWin = buffer;

            Console.WriteLine("Football Team Loss");
            int.TryParse(Console.ReadLine(), out int buffer1);
            football.GameLoss = buffer1;

            Console.WriteLine("Football Team Tie's");
            int.TryParse(Console.ReadLine(), out int buffer2);
            football.GameTie = buffer2;

            return football;
        }

        public static void InsertData()
        {
            using (var context = new Context())
            {

                context.Teams.Add(MapData());
                context.SaveChanges();

            }
        }


        public static void UpdateTeamData()
        {
            Console.WriteLine("Football Team Name:");
            string teamName = Console.ReadLine();
            using (var context = new Context())
            {
                var team = context.Teams.FirstOrDefault(t => t.TeamName.ToUpper() == teamName.ToUpper());

                if (team != null)
                {
                    Console.WriteLine($"Team '{teamName}' found. Select the parameter to change:");

                    Console.WriteLine("1. Team Name");
                    Console.WriteLine("2. Team City");
                    Console.WriteLine("3. Number of Wins");
                    Console.WriteLine("4. Number of Losses");
                    Console.WriteLine("5. Number of Draws");
                    Console.WriteLine("6. Goals Scored");
                    Console.WriteLine("7. Goals Conceded");

                    Console.Write("Select an option: ");
                    int choice;
                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Football Team Name:");
                                team.TeamName = Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("Football Team City:");
                                team.TeamCity = Console.ReadLine();
                                break;
                            case 3:
                                Console.WriteLine("Football Team Wins:");
                                int.TryParse(Console.ReadLine(), out int wins);
                                team.GameWin = wins;
                                break;
                            case 4:
                                Console.WriteLine("Football Team Losses:");
                                int.TryParse(Console.ReadLine(), out int losses);
                                team.GameLoss = losses;
                                break;
                            case 5:
                                Console.WriteLine("Football Team Draws:");
                                int.TryParse(Console.ReadLine(), out int draws);
                                team.GameTie = draws;
                                break;
                            case 6:
                                Console.WriteLine("Football Team Goals Scored:");
                                int.TryParse(Console.ReadLine(), out int scoredGoals);
                                team.ScoredGoals = scoredGoals;
                                break;
                            case 7:
                                Console.WriteLine("Football Team Goals Conceded:");
                                int.TryParse(Console.ReadLine(), out int concededGoals);
                                team.MissedHeads = concededGoals;
                                break;
                            default:
                                Console.WriteLine("Invalid choice.");
                                break;
                        }

                        context.SaveChanges();
                        Console.WriteLine($"Team '{teamName}' data updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }
                else
                {
                    Console.WriteLine($"Team '{teamName}' not found.");
                }
            }
        }

        public static void DeleteTeam()
        {
            Console.WriteLine("Football Team Name or City:");
            string teamName = Console.ReadLine();
            using (var context = new Context())
            {
                var teamToDelete = context.Teams.FirstOrDefault(t => t.TeamName.ToUpper() == teamName.ToUpper() || t.TeamCity.ToUpper() == teamName.ToUpper());

                if (teamToDelete != null)
                {
                    Console.WriteLine($"Team {teamName}");
                    Console.Write("Do you want to delete this team? (Y/N): ");
                    string confirmation = Console.ReadLine();

                    if (confirmation.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        context.Teams.Remove(teamToDelete);
                        context.SaveChanges();
                        Console.WriteLine($"Team '{teamName}' deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Deletion cancelled.");
                    }
                }
                else
                {
                    Console.WriteLine($"Team '{teamName}' not found.");
                }
            }
        }




    }
}