using System.Text;

namespace EntFrmLab2
{
    internal class Program
    {
        static void Main()
        {
            Service service = new Service();
            Console.OutputEncoding = UTF8Encoding.UTF8;
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Відобразити всю інформацію про команди.");
                Console.WriteLine("2. Додати команду.");
                Console.WriteLine("3. Додати гравця.");
                Console.WriteLine("4. Відобразити гравців які грають в команді(Назва).");
                Console.WriteLine("5. Додати матч.");
                Console.WriteLine("6. Оновити дані матчу");
                Console.WriteLine("7. Відобразити деталі матчу");
                Console.WriteLine("8. Відобразити різницю голів");
                Console.WriteLine("9. Відобразити матч за датою");
                Console.WriteLine("10. Відобразити матч за командою.");
                Console.WriteLine("11. Відобразити гравця який забив гол в цю дату.");
                Console.WriteLine("12. Видалити матч.");
                Console.WriteLine("DZ4_________________________________");
                Console.WriteLine("13. Відобразити Топ-3 найкращих бомбардирів конкретної команди..");
                Console.WriteLine("14.Відобразити найкращого бомбардира конкретної команди.");
                Console.WriteLine("15.Відобразити Топ-3 найкращих бомбардирів усього чемпіонату.");
                Console.WriteLine("16.Відобразити найкращого бомбардира усього чемпіонату");
                Console.WriteLine("17.Відобразити Топ-3 команди, які набрали найбільше очок");
                Console.WriteLine("18.Відобразити команду, яка набрала найбільше очок");
                Console.WriteLine("19.Відобразити Топ-3 команди, які набрали найменшу кількість очок. ");
                Console.WriteLine("20.Відобразити команду, яка набрала найменшу кількість очок ");
                Console.WriteLine("21.Відобразити Топ-3 команди, які забили найбільше голів ");
                Console.WriteLine("22.Відобразити команду, яка забила найбільше голів ");
                Console.WriteLine("23.Відобразити Топ-3 команди, які пропустили найменше голів ");
                Console.WriteLine("24.Відобразити команду, яка пропустила найменше голів ");


                Console.WriteLine("0. Вийти з програми");

                Console.Write("Виберіть опцію: ");
                choice = int.Parse(Console.ReadLine());
                try
                {
                    switch (choice)
                    {
                        
                        case 1:
                            service.ShowDataTeam();
                            break;
                        case 2:
                            service.InsertDataTeam();
                            break;
                       case 3:
                            service.InsertDataPlayer();
                            break;
                        case 4:
                            service.DisplayPlayersByTeamName();
                            break;
                         case 5:
                            service.PopulateMatchesTable();
                            break;
                        case 6:
                            service.UpdateMatch();
                            break;
                        case 7:
                            service.DisplayMatchDetails();
                            break;
                        case 8:
                            service.ShowGoalDifference();
                            break;
                        case 9:
                            service.ShowMatchesByDate();
                            break;
                        case 10:
                            service.ShowMatchesByTeam();
                            break;
                        case 11:
                            service.ShowGoalScorersByDate();
                            break;
                        case 12:
                            service.DeleteMatch();
                            break;
                        case 13:
                            service.DisplayTopScorers();
                            break;
                        case 14:
                            service.DisplayTopScorer();
                            break;
                        case 15:
                            service.DisplayTopScorersOverall();
                            break;
                        case 16:
                            service.DisplayTopScorerOverall();
                            break;
                        case 17:
                            service.DisplayTopTeamsByPoints();
                            break;
                        case 18:
                            service.DisplayTopTeamByPoints();
                            break;
                        case 19:
                            service.DisplayBottomTeamsByPoints();
                            break;
                        case 20:
                            service.DisplayTeamWithLeastPoints();
                            break;
                        case 21:
                            service.DisplayTopScoringTeams();
                            break;
                        case 22:
                            service.DisplayTeamWithMostGoals();
                            break;
                        case 23:
                            service.DisplayTopDefensiveTeams();
                            break;
                        case 24:
                            service.DisplayTeamWithLeastGoalsConceded();
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

    }
}