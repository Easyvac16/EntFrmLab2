using EntFrmLab2.DAL;
using EntFrmLab2.DAL.Models;

namespace EntFrmLab2
{
    internal class Program
    {
        static void Main()
        {
            InsertData(2);
            Console.WriteLine("---------------------");
            UpdateData();
            Console.WriteLine("---------------------");
            InsertData(2);
        }

        public static void ShowData()
        {
            using (var context = new Context())
            {
                var teams = context.Teams;
                foreach (var football in teams)
                {   
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
            football.TeamName = Console.ReadLine();

            Console.WriteLine("Football Team City:");
            football.TeamCity = Console.ReadLine();

            Console.WriteLine("Football Team Wins:");
            int.TryParse(Console.ReadLine(), out int buffer);
            football.GameWin = buffer;

            Console.WriteLine("Football Team loss");
            int.TryParse(Console.ReadLine(), out int buffer1);
            football.GameLoss = buffer1;

            Console.WriteLine("Football Team Tie's");
            int.TryParse(Console.ReadLine(), out int buffer2);
            football.GameTie = buffer2;



            return football;
        }
        public static void InsertData(int teams)
        {
            using (var context = new Context())
            {
                for (int i = 0; i < teams; i++)
                {
                    if (context.Teams == null)
                    {
                        context.Teams.Add(MapData());
                        context.SaveChanges();
                    }
                    else
                    {
                        ShowData();
                        break;
                    }
                }
            }
        }

        public static void UpdateData()
        {
            using (var context = new Context())
            {
                var teams = context.Teams.ToList();
                if (teams[0].ScoredGoals == null || teams[1].ScoredGoals == null || teams[2].ScoredGoals == null && teams[0].MissedHeads == null ||teams[1].MissedHeads == null ||teams[2].MissedHeads == null)
                {
                    teams[0].ScoredGoals = 520;
                    teams[1].ScoredGoals = 420;
                    teams[2].ScoredGoals = 320;

                    teams[0].MissedHeads = 310;
                    teams[1].MissedHeads = 420;
                    teams[2].MissedHeads = 510;
                    context.Teams.UpdateRange(teams);
                    context.SaveChanges();
                }
            }
        }

    }
}