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
                /*Console.WriteLine("1. Відобразити всю інформацію про команди.");
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
                Console.WriteLine("12. Видалити команду.");*/
                Console.WriteLine("0. Вийти з програми");

                Console.Write("Виберіть опцію: ");
                choice = int.Parse(Console.ReadLine());
                try
                {
                    switch (choice)
                    {
                        /*case 1:
                            Service.ShowData();
                            break;
                        case 2:
                            Service.SearchTeamByName();
                            break;
                        case 3:
                            Service.SearchTeamsByCity();
                            break;
                        case 4:
                            Service.SearchTeamByNameAndCity();
                            break;
                        case 5:
                            Service.DisplayTeamWithMostWins();
                            break;
                        case 6:
                            Service.DisplayTeamWithMostLosses();
                            break;
                        case 7:
                            Service.DisplayTeamWithMostDraws();
                            break;
                        case 8:
                            Service.DisplayTeamWithMostGoalsScored();
                            break;
                        case 9:
                            Service.DisplayTeamWithMostGoalsConceded();
                            break;
                        case 10:
                            Service.InsertData();
                            break;
                        case 11:
                            Service.UpdateTeamData();
                            break;
                        case 12:
                            Service.DeleteTeam();
                            break;*/
                        case 1:
                            Service.ShowData();
                            break;
                        case 2:
                            Service.InsertDataTeam();
                            break;
                        case 3:
                            Service.InsertDataPlayer();
                            break;
                        case 4:
                            Service.DisplayPlayersByTeamName();
                            break;
                        case 5:
                            Service.PopulateMatchesTable();
                            break;
                        case 6:
                            Service.UpdateMatch();
                            break;
                        case 7:
                            Service.DisplayMatchDetails();
                            break;
                        case 8:
                            Service.ShowGoalDifference();
                            break;
                        case 9:
                            Service.ShowMatchesByDate();
                            break;
                        case 10:
                            Service.ShowMatchesByTeam();
                            break;
                        case 11:
                            Service.ShowGoalScorersByDate();
                            break;
                        case 12:
                            Service.DeleteMatch();
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