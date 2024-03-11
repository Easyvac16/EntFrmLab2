using EntFrmLab2.DAL;
using EntFrmLab2.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EntFrmLab2.Test
{
    public class UnitTest1
    {
        private readonly Repository<Team> _teamRepository;
        private readonly Repository<Player> _playerRepository;
        private readonly Repository<Match> _matchRepository;
        private readonly Repository<GoalScorer> _scorerRepository;

        public UnitTest1()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "Univer")
                .Options;
            _teamRepository = new Repository<Team>(options);
            _playerRepository = new Repository<Player>(options);
            _matchRepository = new Repository<Match>(options);
            _scorerRepository = new Repository<GoalScorer>(options);
        }

        /*[Fact]
        public void CreateTableTest()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "Univer")
                .Options;


            using (var context = new Context(options))
            {
                Player player = new Player()
                {
                    FullName = "Messi",
                    Country = "Liverka",
                    JerseyNumber = 15,
                    Position = "Forward",
                    TeamId = 1,

                };
                Team team = new Team()
                {
                    TeamName = "Real",
                    TeamCity = "Barcelona",
                    GameLoss = 120,
                    GameTie = 100,
                    GameWin = 100,
                    ScoredGoals = 55,
                    MissedHeads = 60

                };
                Match match = new Match()
                {
                    GoalsTeam1 = 150,
                    GoalsTeam2 = 60,
                };
                GoalScorer scorer = new GoalScorer()
                {
                    PlayerId = 1,
                    MatchId = 1,
                    GoalsScored = 5,
                };
                context.GoalScorers.Add(scorer);
                context.Matches.Add(match);
                context.Teams.Add(team);
                context.Players.Add(player);
                context.SaveChanges();
            }

            using (var context = new Context(options))
            {
                Assert.Equal(1, context.Players.CountAsync().Result);
                Assert.Equal("Messi", context.Players.SingleAsync().Result.FullName);
                Assert.Equal("Liverka", context.Players.SingleAsync().Result.Country);
                Assert.Equal(15, context.Players.SingleAsync().Result.JerseyNumber);
                Assert.Equal("Forward", context.Players.SingleAsync().Result.Position);
                Assert.Equal(1, context.Players.SingleAsync().Result.TeamId);
            }
            using (var context = new Context(options))
            {
                Assert.Equal(1, context.Teams.CountAsync().Result);
                Assert.Equal("Real", context.Teams.SingleAsync().Result.TeamName);
                Assert.Equal("Barcelona", context.Teams.SingleAsync().Result.TeamCity);
                Assert.Equal(120, context.Teams.SingleAsync().Result.GameLoss);
                Assert.Equal(100, context.Teams.SingleAsync().Result.GameTie);
                Assert.Equal(100, context.Teams.SingleAsync().Result.GameWin);
                Assert.Equal(55, context.Teams.SingleAsync().Result.ScoredGoals);
                Assert.Equal(60, context.Teams.SingleAsync().Result.MissedHeads);
            }
            using (var context = new Context(options))
            {
                Assert.Equal(1, context.GoalScorers.CountAsync().Result);
                Assert.Equal(1, context.GoalScorers.SingleAsync().Result.PlayerId);
                Assert.Equal(1, context.GoalScorers.SingleAsync().Result.MatchId);
                Assert.Equal(5, context.GoalScorers.SingleAsync().Result.GoalsScored);


            }
            using (var context = new Context(options))
            {
                Assert.Equal(1, context.Matches.CountAsync().Result);
                Assert.Equal(150, context.Matches.SingleAsync().Result.GoalsTeam1);
                Assert.Equal(60, context.Matches.SingleAsync().Result.GoalsTeam2);

            }
        }*/
        public void DisplayTopScorers()
        {
            Console.WriteLine("Write Team Name:");
            string teamName = Console.ReadLine();

            var topScorers = _scorerRepository.GetAll()
            .AsQueryable()
            .Include(s => s.Player)
            .Include(s => s.Match)
            .Where(s => s.Player.Team.Name == teamName)
            .ToList()
            .GroupBy(s => s.Player)
            .Select(g => new { Player = g.Key, GoalsScored = g.Sum(s => s.GoalsScored) })
            .OrderByDescending(g => g.GoalsScored)
            .Take(3)
            .ToList();


            Console.WriteLine($"Топ-3 найкращих бомбардирів команди '{teamName}':");
            foreach (var scorer in topScorers)
            {
                Console.WriteLine($"Ім'я: {scorer.Player.FullName}, Кількість забитих м'ячів: {scorer.GoalsScored}");
            }
        }

        public void DisplayTopScorer()
        {

            Console.WriteLine("Write Team Name:");
            string teamName = Console.ReadLine();

            var topScorer = _scorerRepository.GetAll()
                .AsQueryable()
                .Include(s => s.Player)
                .Where(s => s.Player.Team.Name == teamName)
                .OrderByDescending(s => s.GoalsScored)
                .FirstOrDefault();

            if (topScorer != null)
            {
                Console.WriteLine($"Найкращий бомбардир команди '{teamName}':");
                Console.WriteLine($"Ім'я: {topScorer.Player.FullName}, Кількість забитих м'ячів: {topScorer.GoalsScored}");
            }
            else
            {
                Console.WriteLine($"Бомбардирів команди '{teamName}' не знайдено.");
            }
        }

        public void DisplayTopScorersOverall()
        {
            var topScorers = _scorerRepository.GetAll()
                .AsQueryable()
                .Include(s => s.Player)
                .AsEnumerable()
                .GroupBy(s => s.Player)
                .Select(g => new { Player = g.Key, TotalGoals = g.Sum(s => s.GoalsScored) })
                .OrderByDescending(g => g.TotalGoals)
                .Take(3)
                .ToList();

            Console.WriteLine("Топ-3 найкращих бомбардирів усього чемпіонату:");
            foreach (var scorer in topScorers)
            {
                Console.WriteLine($"Ім'я: {scorer.Player.FullName}, Кількість забитих м'ячів: {scorer.TotalGoals}");
            }
        }

        public void DisplayTopScorerOverall()
        {
            var topScorer = _scorerRepository.GetAll()
                .AsQueryable()
                .Include(s => s.Player)
                .GroupBy(s => s.Player)
                .Select(g => new { Player = g.Key, TotalGoals = g.Sum(s => s.GoalsScored) })
                .OrderByDescending(g => g.TotalGoals)
                .FirstOrDefault();

            if (topScorer != null && topScorer.Player != null)
            {
                Console.WriteLine($"Найкращий бомбардир усього чемпіонату: {topScorer.Player.FullName}, Кількість забитих м'ячів: {topScorer.TotalGoals}");
            }
            else
            {
                Console.WriteLine("Інформація про найкращого бомбардира відсутня.");
            }
        }

        public void DisplayTopTeamsByPoints()
        {
            var topTeams = _teamRepository.GetAll()
                .OrderByDescending(t => (t.GameWin * 3) + t.GameTie)
                .Take(3)
                .ToList();

            Console.WriteLine("Топ-3 команди за кількістю очок:");
            foreach (var team in topTeams)
            {
                int points = (team.GameWin * 3) + team.GameTie;
                Console.WriteLine($"Команда: {team.Name}, Очки: {points}");
            }
        }


        public void DisplayTopTeamByPoints()
        {
            var topTeam = _teamRepository.GetAll()
                .OrderByDescending(t => (t.GameWin * 3) + t.GameTie)
                .FirstOrDefault();

            if (topTeam != null)
            {
                int points = (topTeam.GameWin * 3) + topTeam.GameTie;
                Console.WriteLine($"Команда з найбільшою кількістю очок: {topTeam.Name}, Очки: {points}");
            }
            else
            {
                Console.WriteLine("Не вдалося знайти команду.");
            }
        }

        public void DisplayBottomTeamsByPoints()
        {
            var bottomTeams = _teamRepository.GetAll()
                .OrderBy(t => (t.GameWin * 3) + t.GameTie)
                .Take(3)
                .ToList();

            if (bottomTeams.Any())
            {
                Console.WriteLine("Топ-3 команди з найменшою кількістю очок:");
                foreach (var team in bottomTeams)
                {
                    int points = (team.GameWin * 3) + team.GameTie;
                    Console.WriteLine($"Команда: {team.Name}, Очки: {points}");
                }
            }
            else
            {
                Console.WriteLine("Не вдалося знайти команди.");
            }
        }

        public void DisplayTeamWithLeastPoints()
        {
            var teamWithLeastPoints = _teamRepository.GetAll()
                .OrderBy(t => (t.GameWin * 3) + t.GameTie)
                .FirstOrDefault();

            if (teamWithLeastPoints != null)
            {
                int points = (teamWithLeastPoints.GameWin * 3) + teamWithLeastPoints.GameTie;
                Console.WriteLine($"Команда з найменшою кількістю очок: {teamWithLeastPoints.Name}, Очки: {points}");
            }
            else
            {
                Console.WriteLine("Не вдалося знайти команду.");
            }
        }

        public void DisplayTopScoringTeams()
        {
            var topScoringTeams = _teamRepository.GetAll()
                .OrderByDescending(t => t.ScoredGoals)
                .Take(3)
                .ToList();

            Console.WriteLine("Топ-3 команди, які забили найбільше голів:");
            foreach (var team in topScoringTeams)
            {
                Console.WriteLine($"Команда: {team.Name}, Забиті голи: {team.ScoredGoals}");
            }
        }

        public void DisplayTeamWithMostGoals()
        {
            var teamWithMostGoals = _teamRepository.GetAll()
                .OrderByDescending(t => t.ScoredGoals)
                .FirstOrDefault();

            if (teamWithMostGoals != null)
            {
                Console.WriteLine($"Команда, яка забила найбільше голів: {teamWithMostGoals.Name}, Забиті голи: {teamWithMostGoals.ScoredGoals}");
            }
            else
            {
                Console.WriteLine("Не вдалося знайти команду.");
            }
        }

        public void DisplayTopDefensiveTeams()
        {
            var topDefensiveTeams = _teamRepository.GetAll()
                .OrderBy(t => t.MissedHeads)
                .Take(3)
                .ToList();

            Console.WriteLine("Топ-3 команди, які пропустили найменше голів:");
            foreach (var team in topDefensiveTeams)
            {
                Console.WriteLine($"Команда: {team.Name}, Пропущені голи: {team.MissedHeads}");
            }
        }

        public void DisplayTeamWithLeastGoalsConceded()
        {
            var teamWithLeastGoalsConceded = _teamRepository.GetAll()
                .OrderBy(t => t.MissedHeads)
                .FirstOrDefault();

            if (teamWithLeastGoalsConceded != null)
            {
                Console.WriteLine($"Команда, яка пропустила найменше голів: {teamWithLeastGoalsConceded.Name}, Пропущені голи: {teamWithLeastGoalsConceded.MissedHeads}");
            }
            else
            {
                Console.WriteLine("Не вдалося знайти команду.");
            }
        }

        /*public void PopulateMatchesTable()
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
            match.Team1 = team1;

            Console.WriteLine("Enter Team 2:");
            string team2Name = Console.ReadLine();
            var team2 = _teamRepository.GetAll().FirstOrDefault(t => t.Name.ToUpper() == team2Name.ToUpper());
            if (team2 == null)
            {
                Console.WriteLine($"Team '{team2Name}' not found.");
                return;
            }
            match.Team2 = team2;

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
            //AddGoalScorersToMatch(match.Id);

            Console.WriteLine("Matches added successfully.");
        }*/

        [Fact]
        public void CreateTableTestRepository()
        {
            Player player = new Player()
            {
                FullName = "Messi",
                Country = "Liverka",
                JerseyNumber = 15,
                Position = "Forward",
                TeamId = 1,

            };
            Team team1 = new Team()
            {
                Name = "Real",
                City = "Barcelona",
                GameLoss = 120,
                GameTie = 100,
                GameWin = 100,
                ScoredGoals = 55,
                MissedHeads = 60

            };
            Team team2 = new Team()
            {
                Name = "Madrid",
                City = "Barcelona",
                GameLoss = 120,
                GameTie = 100,
                GameWin = 100,
                ScoredGoals = 55,
                MissedHeads = 60

            };
            Match match = new Match()
            {
                GoalsTeam1 = 150,
                GoalsTeam2 = 60
            };
            GoalScorer scorer = new GoalScorer()
            {
                PlayerId = 1,
                MatchId = 1,
                GoalsScored = 5,
            };


            _matchRepository.Add(match);
            _playerRepository.Add(player);
            _teamRepository.Add(team1);
            _teamRepository.Add(team2);
            _scorerRepository.Add(scorer);

            var playerO = _playerRepository.GetAll().FirstOrDefault();
            var teamO = _teamRepository.GetAll().FirstOrDefault();
            var scorerO = _scorerRepository.GetAll().FirstOrDefault();
            var matchO = _matchRepository.GetAll().FirstOrDefault();
            var teamA = _teamRepository.GetAll().FirstOrDefault(t => t.Name == team2.Name);

            //Player
            Assert.Equal(1, _playerRepository.GetAll().ToList().Count);
            Assert.Equal(player.FullName, playerO.FullName);
            Assert.Equal(player.Country, playerO.Country);
            Assert.Equal(player.JerseyNumber, playerO.JerseyNumber);
            Assert.Equal(player.Position, playerO.Position);
            Assert.Equal(player.TeamId, playerO.TeamId);

            //Team
            Assert.Equal(2, _teamRepository.GetAll().ToList().Count);
            Assert.Equal(team1.Name, teamO.Name);
            Assert.Equal(team1.City, teamO.City);
            Assert.Equal(team1.GameLoss, teamO.GameLoss);
            Assert.Equal(team1.GameTie, teamO.GameTie);
            Assert.Equal(team1.GameWin, teamO.GameWin);
            Assert.Equal(team1.ScoredGoals, teamO.ScoredGoals);
            Assert.Equal(team1.MissedHeads, teamO.MissedHeads);
            Assert.Equal(team2.Name, teamA.Name);
            Assert.Equal(team2.City, teamA.City);
            Assert.Equal(team2.GameLoss, teamA.GameLoss);
            Assert.Equal(team2.GameTie, teamA.GameTie);
            Assert.Equal(team2.GameWin, teamA.GameWin);
            Assert.Equal(team2.ScoredGoals, teamA.ScoredGoals);
            Assert.Equal(team2.MissedHeads, teamA.MissedHeads);

            //Scorer
            Assert.Equal(1, _scorerRepository.GetAll().ToList().Count);
            Assert.Equal(scorer.PlayerId, scorerO.PlayerId);
            Assert.Equal(scorer.MatchId, scorerO.MatchId);
            Assert.Equal(scorer.GoalsScored, scorerO.GoalsScored);

            //Match
            Assert.Equal(1, _matchRepository.GetAll().ToList().Count);
            Assert.Equal(match.GoalsTeam1, matchO.GoalsTeam1);
            Assert.Equal(match.GoalsTeam2, matchO.GoalsTeam2);

            /*DisplayTopScorerOverall();
            DisplayTopScorer();
            DisplayTopScorers();*/
            DisplayBottomTeamsByPoints();
            DisplayTeamWithLeastPoints();
            DisplayTopTeamByPoints();
            DisplayTopTeamsByPoints();
            DisplayTopScorersOverall();
            DisplayTopScoringTeams();
            DisplayTeamWithMostGoals();
            DisplayTopDefensiveTeams();
            DisplayTeamWithLeastGoalsConceded();

        }
    }
}