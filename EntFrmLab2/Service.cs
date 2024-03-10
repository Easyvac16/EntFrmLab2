using EntFrmLab2.DAL;
using EntFrmLab2.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;

namespace EntFrmLab2
{
    public class Service
    {


        /*public static void DisplayTeamWithMostWins()
        {
            using (var context = new Context())
            {
                var teamWithMostWins = context.Teams.OrderByDescending(t => t.GameWin).FirstOrDefault();
                if (teamWithMostWins != null)
                {
                    Console.WriteLine($"Team with the most wins: {teamWithMostWins.Name}, Wins:{teamWithMostWins.GameWin}");
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
                    Console.WriteLine($"Team with the most losses: {teamWithMostLosses.Name}, Lose's:{teamWithMostLosses.GameLoss}");
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
                    Console.WriteLine($"Team with the most draws: {teamWithMostDraws.Name}, Draws: {teamWithMostDraws.GameTie}");
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
                    Console.WriteLine($"Team with the most goals scored: {teamWithMostGoalsScored.Name}, Goal's scored: {teamWithMostGoalsScored.ScoredGoals}");
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
                    Console.WriteLine($"Team with the most goals conceded: {teamWithMostGoalsConceded.Name}, Goals conceded: {teamWithMostGoalsConceded.MissedHeads}");
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
                string Name = Console.ReadLine();
                var team = context.Teams.FirstOrDefault(t => t.Name.ToUpper() == Name.ToUpper());
                if (team != null)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine($"Team Name: {Name}");
                    Console.WriteLine($"City: {team.City}");
                    Console.WriteLine($"Wins: {team.GameWin}");
                    Console.WriteLine($"lose's: {team.GameLoss}");
                    Console.WriteLine($"Tie's: {team.GameTie}");
                    Console.WriteLine($"Scored goal's: {team.ScoredGoals}");
                    Console.WriteLine($"Missed goal's: {team.MissedHeads}");
                }
                else
                {
                    Console.WriteLine($"Team with name '{Name}' not found.");
                }
            }
        }

        public static void SearchTeamsByCity()
        {
            using (var context = new Context())
            {
                Console.WriteLine("Write searched team city:");
                string city = Console.ReadLine();
                var teams = context.Teams.Where(t => t.City.ToUpper() == city.ToUpper());
                if (teams.Any())
                {
                    Console.WriteLine($"Team's in City '{city}':");
                    foreach (var team in teams)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine($"Team Name: {team.Name}");
                        Console.WriteLine($"City: {team.City}");
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
                string Name = Console.ReadLine();
                var team = context.Teams.FirstOrDefault(t => t.Name.ToUpper() == Name.ToUpper() && t.City.ToUpper() == city.ToUpper());
                if (team != null)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine($"Information abt team '{Name}' in '{city}':");
                    Console.WriteLine($"Team Name: {Name}");
                    Console.WriteLine($"City: {team.City}");
                    Console.WriteLine($"Wins: {team.GameWin}");
                    Console.WriteLine($"lose's: {team.GameLoss}");
                    Console.WriteLine($"Tie's: {team.GameTie}");
                    Console.WriteLine($"Scored goal's: {team.ScoredGoals}");
                    Console.WriteLine($"Missed goal's: {team.MissedHeads}");
                }
                else
                {
                    Console.WriteLine($"Team with name '{Name}' in city '{city}' not found.");
                }
            }
        }*/
        private readonly Repository<Team> _teamRepository;
        private readonly Repository<Player> _playerRepository;
        private readonly Repository<Match> _matchRepository;
        private readonly Repository<GoalScorer> _scorerRepository;

        public Service()
        {
            _teamRepository = new Repository<Team>();
            _playerRepository = new Repository<Player>();
            _matchRepository = new Repository<Match>();
            _scorerRepository = new Repository<GoalScorer>();
        }


        public void ShowDataTeam()
        {
            var teams = _teamRepository.GetAll().ToList();
            foreach (var football in teams)
            {
                Console.WriteLine("\n");
                Console.WriteLine($"Name:{football.Name}");
                Console.WriteLine($"City:{football.City}");
                Console.WriteLine($"Wins:{football.GameWin}");
                Console.WriteLine($"Loss:{football.GameLoss}");
                Console.WriteLine($"Tie's:{football.GameTie}");
                Console.WriteLine($"Scored goals:{football.ScoredGoals}");
                Console.WriteLine($"Missed Goals:{football.MissedHeads}");
                Console.WriteLine("\n");
            }

        }

        public void ShowGoalDifference()
        {

            var teams = _teamRepository.GetAll().ToList();

            foreach (var team in teams)
            {
                int goalsScored = 0;
                int goalsConceded = 0;

                var matches = _matchRepository.GetAll().Where(m => m.Team1 == team || m.Team2 == team).ToList();

                foreach (var match in matches)
                {
                    if (match.Team1 == team)
                    {
                        goalsScored += match.GoalsTeam1;
                        goalsConceded += match.GoalsTeam2;
                    }
                    else
                    {
                        goalsScored += match.GoalsTeam2;
                        goalsConceded += match.GoalsTeam1;
                    }
                }

                int goalDifference = goalsScored - goalsConceded;

                Console.WriteLine($"Team: {team.Name}, Goals Scored: {goalsScored}, Goals Conceded: {goalsConceded}, Goal Difference: {goalDifference}");
            }

        }

        public void PopulateMatchesTable()
        {
            Match match = new Match();

            Console.WriteLine("Enter Team 1:");
            string team1Name = Console.ReadLine();
            var team1 = _teamRepository.GetAll().FirstOrDefault(t => t.Name.ToUpper() == team1Name.ToUpper());
            if (team1 == null)
            {
                Console.WriteLine($"Team '{team1Name}' not found.");
                return;
            }
            match.Team1Id = team1.id;

            Console.WriteLine("Enter Team 2:");
            string team2Name = Console.ReadLine();
            var team2 = _teamRepository.GetAll().FirstOrDefault(t => t.Name.ToUpper() == team2Name.ToUpper());
            if (team2 == null)
            {
                Console.WriteLine($"Team '{team2Name}' not found.");
                return;
            }
            match.Team2Id = team2.id;

            Console.WriteLine("Enter Goals for Team 1:");
            int goalsTeam1;
            while (!int.TryParse(Console.ReadLine(), out goalsTeam1) || goalsTeam1 < 0)
            {
                Console.WriteLine("Please enter a valid non-negative number.");
            }
            match.GoalsTeam1 = goalsTeam1;

            Console.WriteLine("Enter Goals for Team 2:");
            int goalsTeam2;
            while (!int.TryParse(Console.ReadLine(), out goalsTeam2) || goalsTeam2 < 0)
            {
                Console.WriteLine("Please enter a valid non-negative number.");
            }
            match.GoalsTeam2 = goalsTeam2;

            Console.WriteLine("Enter Match Date (yyyy-MM-dd):");
            DateTime matchDate;
            while (!DateTime.TryParse(Console.ReadLine(), out matchDate))
            {
                Console.WriteLine("Please enter a valid date in the format yyyy-MM-dd.");
            }
            match.MatchDate = matchDate;
            _matchRepository.Add(match);
            AddGoalScorersToMatch(match.Id);

            Console.WriteLine("Matches added successfully.");
        }

        public void AddGoalScorersToMatch(int matchId)
        {

            using (var context = new Context())
            {

                var matchToUpdate = context.Matches.Include(m => m.GoalScorers).FirstOrDefault(m => m.Id == matchId);
                if (matchToUpdate != null)
                {
                    Console.WriteLine("Enter the number of goal scorers:");
                    int numberOfScorers = int.Parse(Console.ReadLine());

                    for (int i = 0; i < numberOfScorers; i++)
                    {
                        Console.WriteLine($"Enter the player ID for goal scorer {i + 1}:");
                        int playerId = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Enter the number of goals scored by player {playerId}:");
                        int goalsScored = int.Parse(Console.ReadLine());

                        var player = context.Players.FirstOrDefault(p => p.Id == playerId);
                        if (player != null)
                        {
                            matchToUpdate.GoalScorers.Add(new GoalScorer { Player = player, GoalsScored = goalsScored });
                        }
                        else
                        {
                            Console.WriteLine($"Player with ID '{playerId}' not found.");
                        }
                    }

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"Match with id '{matchId}' not found.");
                }
            }
        }//s




        public void DisplayPlayersByTeamName()
        {
            Console.WriteLine("Enter the name of the team:");
            string Name = Console.ReadLine();


            var team = GetTeamByName(Name);
            if (team == null)
            {
                Console.WriteLine($"Team with the name '{Name}' does not exist.");
                return;
            }

            if (team.Players == null || !team.Players.Any())
            {
                Console.WriteLine($"There are no players for team '{Name}'.");
                return;
            }

            Console.WriteLine($"Players for team '{Name}':");
            foreach (var player in team.Players)
            {
                Console.WriteLine($"Name: {player.FullName}, Jersey Number: {player.JerseyNumber}, Position: {player.Position}");
            }

        }




        public Team MapDataTeam()
        {
            Team football = new Team();

            Console.WriteLine("Football Team Name:");
            string Name = Console.ReadLine();

            if (GetTeamByName(Name) != null)
            {
                Console.WriteLine($"Team with the name '{Name}' already exists in the application.");
                return null;
            }

            football.Name = Name;

            Console.WriteLine("Football Team City:");
            football.City = Console.ReadLine();

            Console.WriteLine("Football Team Wins:");
            int.TryParse(Console.ReadLine(), out int buffer);
            football.GameWin = buffer;

            Console.WriteLine("Football Team Loss");
            int.TryParse(Console.ReadLine(), out int buffer1);
            football.GameLoss = buffer1;

            Console.WriteLine("Football Team Tie's");
            int.TryParse(Console.ReadLine(), out int buffer2);
            football.GameTie = buffer2;

            Console.WriteLine("Scored goals:");
            int.TryParse(Console.ReadLine(), out int buffer3);
            football.ScoredGoals = buffer3;

            Console.WriteLine("Missed goals:");
            int.TryParse(Console.ReadLine(), out int buffer4);
            football.MissedHeads = buffer4;

            return football;
        }


        public void InsertDataTeam()
        {
            Team team = MapDataTeam();
            if (team != null)
            {
                _teamRepository.Add(team);
            }
        }

        public Player MapDataPlayer()
        {
            Player player = new Player();

            Console.WriteLine("Player Full Name:");
            string fullName = Console.ReadLine();

            if (PlayerExistsInAnyTeam(fullName))
            {
                Console.WriteLine("Player exist's in team");
                return null;
            }


            player.FullName = fullName;

            Console.WriteLine("Player City:");
            player.Country = Console.ReadLine();

            Console.WriteLine("Player Jersey Number:");
            int.TryParse(Console.ReadLine(), out int jerseyNumber);
            player.JerseyNumber = jerseyNumber;

            Console.WriteLine("Player Position:");
            player.Position = Console.ReadLine();

            Console.WriteLine("Team Name:");
            string Name = Console.ReadLine();

            if (GetTeamByName(Name) == null)
            {
                Console.WriteLine($"Team '{Name}' not found. Player cannot be added without a valid team.");
                return null;
            }

            if (PlayerExistsInTeam(fullName, GetTeamByName(Name))) return null;

            player.TeamId = GetTeamByName(Name).id;


            return player;
        }

        private bool PlayerExistsInAnyTeam(string fullName)
        {
            return _playerRepository.GetAll().Any(p => p.FullName.ToUpper() == fullName.ToUpper());
        }

        public Team GetTeamByName(string Name)
        {
            var player = _teamRepository.GetAll().AsQueryable()
                .Include(t => t.Players)
                            .FirstOrDefault(t => t.Name.ToUpper() == Name.ToUpper());

            if (player != null)
            {
                return player;
            }
            else
            {
                return null;
            }
        }




        private bool PlayerExistsInTeam(string fullName, Team team)
        {
            return _playerRepository.GetAll().Any(p => p.FullName.ToUpper() == fullName.ToUpper() && p.Team.id == team.id);
        }


        public void InsertDataPlayer()
        {
            Player player = MapDataPlayer();
            if (player != null)
            {
                _playerRepository.Add(player);
            }

        }


        public void UpdateTeamData()
        {
            Console.WriteLine("Football Team Name:");
            string Name = Console.ReadLine();
            using (var context = new Context())
            {
                var team = GetTeamByName(Name);

                if (team != null)
                {
                    Console.WriteLine($"Team '{Name}' found. Select the parameter to change:");

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
                                team.Name = Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("Football Team City:");
                                team.City = Console.ReadLine();
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
                        Console.WriteLine($"Team '{Name}' data updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }
                else
                {
                    Console.WriteLine($"Team '{Name}' not found.");
                }
            }
        }

        public void UpdateMatch()
        {
            Console.WriteLine("Enter Match ID:");
            int matchId = int.Parse(Console.ReadLine());

            
                var matchToUpdate = _matchRepository.GetAll().FirstOrDefault(m => m.Id == matchId);

                if (matchToUpdate != null)
                {
                    Console.WriteLine($"Match found with ID: {matchId}");
                    Console.WriteLine("Select the parameter to change:");
                    Console.WriteLine("1. Team 1");
                    Console.WriteLine("2. Team 2");
                    Console.WriteLine("3. Goals for Team 1");
                    Console.WriteLine("4. Goals for Team 2");
                    Console.WriteLine("5. Match Date");
                    Console.WriteLine("6. Update Goal Scorers");

                    Console.Write("Enter your choice: ");
                    int choice;
                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Enter new Team 1:");
                                string team1Name = Console.ReadLine();
                                var team1 = _teamRepository.GetAll().FirstOrDefault(t => t.Name.ToUpper() == team1Name.ToUpper());
                                if (team1 != null)
                                {
                                    matchToUpdate.Team1 = team1;
                                    Console.WriteLine("Team 1 updated successfully.");
                                }
                                else
                                {
                                    Console.WriteLine($"Team '{team1Name}' not found.");
                                }
                                break;
                            case 2:
                                Console.WriteLine("Enter new Team 2:");
                                string team2Name = Console.ReadLine();
                                var team2 = _teamRepository.GetAll().FirstOrDefault(t => t.Name.ToUpper() == team2Name.ToUpper());
                                if (team2 != null)
                                {
                                    matchToUpdate.Team2 = team2;
                                    Console.WriteLine("Team 2 updated successfully.");
                                }
                                else
                                {
                                    Console.WriteLine($"Team '{team2Name}' not found.");
                                }
                                break;
                            case 3:
                                Console.WriteLine("Enter new goals for Team 1:");
                                int goalsTeam1;
                                if (int.TryParse(Console.ReadLine(), out goalsTeam1))
                                {
                                    matchToUpdate.GoalsTeam1 = goalsTeam1;
                                    Console.WriteLine("Goals for Team 1 updated successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Goals must be a non-negative integer.");
                                }
                                break;
                            case 4:
                                Console.WriteLine("Enter new goals for Team 2:");
                                int goalsTeam2;
                                if (int.TryParse(Console.ReadLine(), out goalsTeam2))
                                {
                                    matchToUpdate.GoalsTeam2 = goalsTeam2;
                                    Console.WriteLine("Goals for Team 2 updated successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Goals must be a non-negative integer.");
                                }
                                break;
                            case 5:
                                Console.WriteLine("Enter new Match Date (yyyy-MM-dd):");
                                DateTime matchDate;
                                if (DateTime.TryParse(Console.ReadLine(), out matchDate))
                                {
                                    matchToUpdate.MatchDate = matchDate;
                                    Console.WriteLine("Match Date updated successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid date in the format yyyy-MM-dd.");
                                }
                                break;
                            case 6:
                                UpdateGoalScorers(matchToUpdate);
                                break;
                            default:
                                Console.WriteLine("Invalid choice.");
                                break;
                        }

                        _matchRepository.Update(matchId, matchToUpdate);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }
                else
                {
                    Console.WriteLine($"Match with ID '{matchId}' not found.");
                }
            
        }

        public void DeleteMatch()
        {
            Console.WriteLine("Enter Team 1 Name:");
            string team1Name = Console.ReadLine();

            Console.WriteLine("Enter Team 2 Name:");
            string team2Name = Console.ReadLine();

            Console.WriteLine("Enter Match Date (yyyy-MM-dd):");
            DateTime matchDate;
            while (!DateTime.TryParse(Console.ReadLine(), out matchDate))
            {
                Console.WriteLine("Please enter a valid date in the format yyyy-MM-dd.");
            }


            var matchToDelete = _matchRepository
                .GetAll()
                .AsQueryable()
                .Include(m => m.Team1)
                .Include(m => m.Team2)
                .FirstOrDefault(m =>
                    (m.Team1.Name.ToUpper() == team1Name.ToUpper() && m.Team2.Name.ToUpper() == team2Name.ToUpper() ||
                     m.Team1.Name.ToUpper() == team2Name.ToUpper() && m.Team2.Name.ToUpper() == team1Name.ToUpper()) &&
                    m.MatchDate.Date == matchDate.Date);

            if (matchToDelete != null)
            {
                Console.WriteLine("Match found:");
                Console.WriteLine($"Match ID: {matchToDelete.Id}");
                Console.WriteLine($"Team 1: {matchToDelete.Team1.Name}");
                Console.WriteLine($"Team 2: {matchToDelete.Team2.Name}");
                Console.WriteLine($"Match Date: {matchToDelete.MatchDate}");

                Console.Write("Do you want to delete this match? (Y/N): ");
                string confirmation = Console.ReadLine();

                if (confirmation.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    _matchRepository.Remove(matchToDelete.Id);
                    Console.WriteLine("Match deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Deletion cancelled.");
                }
            }
            else
            {
                Console.WriteLine("No match found with the specified details.");
            }

        }


        private void UpdateGoalScorers(Match match)
        {
            Console.WriteLine("Enter the number of goal scorers:");
            int numberOfScorers = int.Parse(Console.ReadLine());

            using (var context = new Context())
            {
                context.Matches.Attach(match);

                context.Entry(match).Collection(m => m.GoalScorers).Load();

                match.GoalScorers.Clear();

                for (int i = 0; i < numberOfScorers; i++)
                {
                    Console.WriteLine($"Enter the player ID for goal scorer {i + 1}:");
                    int playerId = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Enter the number of goals scored by player {playerId}:");
                    int goalsScored = int.Parse(Console.ReadLine());

                    var player = context.Players.FirstOrDefault(p => p.Id == playerId);
                    if (player != null)
                    {
                        match.GoalScorers.Add(new GoalScorer { Player = player, GoalsScored = goalsScored });
                    }
                    else
                    {
                        Console.WriteLine($"Player with ID '{playerId}' not found.");
                    }
                }

                context.SaveChanges();
            }
        }




        public void DisplayMatchDetails()
        {
            Console.WriteLine("Enter Match id");
            int matchId = int.Parse(Console.ReadLine());

            var match = _matchRepository.GetAll()
                .AsQueryable()
                .Include(m => m.GoalScorers)
                .Include(m => m.Team1)
                .Include(m => m.Team2)
                .FirstOrDefault(m => m.Id == matchId);
            if (match == null)
            {
                Console.WriteLine($"Match with id '{matchId}' not found.");
                return;
            }

            Console.WriteLine($"Match ID: {match.Id}");
            Console.WriteLine($"Match Date: {match.MatchDate}");
            Console.WriteLine($"Goals scored by Team 1 ({match.Team1.Name}): {match.GoalsTeam1}");
            Console.WriteLine($"Goals scored by Team 2 ({match.Team2.Name}): {match.GoalsTeam2}");

            Console.WriteLine("Players who participated in the match:");
            foreach (var goalScorer in match.GoalScorers)
            {
                if (goalScorer != null)
                {
                    var player = _playerRepository.GetAll()
                    .AsQueryable()
                    .Include(p => p.Team)
                    .FirstOrDefault(p => p.Id == goalScorer.PlayerId);
                    if (player != null)
                    {
                        Console.WriteLine($"Player Name: {player.FullName}, Team: {player.Team.Name}, Goals Scored: {goalScorer.GoalsScored}");
                    }
                    else
                    {
                        Console.WriteLine("Player information not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Encountered null entry in goal scorers list.");
                }
            }


        }

        public void ShowGoalScorersByDate()
        {
            Console.WriteLine("Enter Scorers Date (yyyy-MM-dd):");
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Please enter a valid date in the format yyyy-MM-dd.");
            }

            var goals = _scorerRepository
                    .GetAll()
                    .AsQueryable()
                    .Include(g => g.Player)
                    .ThenInclude(p => p.Team)
                    .Where(g => g.Match.MatchDate.Date == date.Date)
                    .ToList();

            if (goals.Any())
            {
                Console.WriteLine($"Goal scorers on {date.ToShortDateString()}:");
                foreach (var goal in goals)
                {
                    var player = goal.Player;
                    Console.WriteLine($"Player: {player.FullName}, Team: {player.Team.Name}, Goals Scored: {goal.GoalsScored}");
                }
            }
            else
            {
                Console.WriteLine($"No goals scored on {date.ToShortDateString()}.");
            }

        }

        public void ShowMatchesByDate()
        {
            Console.WriteLine("Enter Match Date (yyyy-MM-dd):");
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Please enter a valid date in the format yyyy-MM-dd.");
            }

            var matches = _matchRepository
            .GetAll()
            .AsQueryable()
            .Include(m => m.Team1)
            .Include(m => m.Team2)
            .Where(m => m.MatchDate.Date == date.Date).ToList();

            if (matches.Any())
            {
                Console.WriteLine($"Matches on {date.ToShortDateString()}:");
                foreach (var match in matches)
                {
                    Console.WriteLine($"Match ID: {match.Id}");
                    Console.WriteLine($"Date: {match.MatchDate}");
                    Console.WriteLine($"Team 1: {match.Team1.Name}, Goals: {match.GoalsTeam1}");
                    Console.WriteLine($"Team 2: {match.Team2.Name}, Goals: {match.GoalsTeam2}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"No matches found on {date.ToShortDateString()}.");
            }

        }
        public void ShowMatchesByTeam()
        {
            Console.WriteLine("Enter Team Name:");
            string Name = Console.ReadLine();
            using (var context = new Context())
            {
                var matches = context.Matches
                    .Include(m => m.Team1)
                    .Include(m => m.Team2)
                    .Where(m => m.Team1.Name == Name || m.Team2.Name == Name)
                    .ToList();

                if (matches.Any())
                {
                    Console.WriteLine($"Matches involving {Name}:");
                    foreach (var match in matches)
                    {
                        Console.WriteLine($"Match ID: {match.Id}");
                        Console.WriteLine($"Date: {match.MatchDate}");
                        Console.WriteLine($"Team 1: {match.Team1.Name}, Goals: {match.GoalsTeam1}");
                        Console.WriteLine($"Team 2: {match.Team2.Name}, Goals: {match.GoalsTeam2}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine($"No matches found involving {Name}.");
                }
            }
        }



        public void DeleteTeam()
        {
            Console.WriteLine("Football Team Name or City:");
            string Name = Console.ReadLine();
            using (var context = new Context())
            {
                var teamToDelete = context.Teams.FirstOrDefault(t => t.Name.ToUpper() == Name.ToUpper() || t.City.ToUpper() == Name.ToUpper());

                if (teamToDelete != null)
                {
                    Console.WriteLine($"Team {Name}");
                    Console.Write("Do you want to delete this team? (Y/N): ");
                    string confirmation = Console.ReadLine();

                    if (confirmation.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        context.Teams.Remove(teamToDelete);
                        context.SaveChanges();
                        Console.WriteLine($"Team '{Name}' deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Deletion cancelled.");
                    }
                }
                else
                {
                    Console.WriteLine($"Team '{Name}' not found.");
                }
            }
        }


    }
}
