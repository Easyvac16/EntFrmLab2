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