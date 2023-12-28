//Lab 7 вариант 7 средний уровень
try
{
    Console.WriteLine("Введите кол-во работников: ");
    int n = int.Parse(Console.ReadLine());
    Employee[] emp = new Employee[n];
    for (int i = 0; i < n; i++)
    {
        emp[i] = new Employee();
        Console.WriteLine("Введите имя сотрудника: ");
        emp[i].FirstName = Console.ReadLine();
        Console.WriteLine("Введите фамилию сотрудника: ");
        emp[i].LastName = Console.ReadLine();
        Console.WriteLine("Введите отчество сотрудника: ");
        emp[i].Patronymic = Console.ReadLine();
        Console.WriteLine("Введите должность сотрудника: ");
        emp[i].Post = Console.ReadLine();
        Console.WriteLine("Введите пол сотрудника: ");
        char[] genderCharArray = Console.ReadLine().ToCharArray();

        Console.WriteLine("Введите год приема на работу: ");
        int year = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите месяц приема на работу: ");
        int month = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите день приема на работу: ");
        int day = int.Parse(Console.ReadLine());
        emp[i].DateOfEmployment = new DateTime(year, month, day);
    }
    double[] experience = emp.Select(e => (DateTime.Now - e.DateOfEmployment).TotalDays / 365).ToArray();
    double averageExperience = experience.Average();
    Console.WriteLine($"Средний стаж работы: {averageExperience:F2} года(лет)");
    foreach (var employee in emp.Where((e, idx) => experience[idx] > averageExperience))
    {
        Console.WriteLine($"Имя: {employee.FirstName}, Фамилия: {employee.LastName}, " +
                          $"Отчество: {employee.Patronymic}, Должность: {employee.Post}, " +
                          $"Пол: {employee.Gender}, Дата приема на работу: {employee.DateOfEmployment.ToShortDateString()}, " +
                          $"Стаж работы: {experience[Array.IndexOf(emp, employee)]:F2} года(лет)");
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
struct Employee
{
    public string FirstName;
    public string LastName;
    public string Patronymic;
    public string Post;
    public char Gender;
    public DateTime DateOfEmployment;
}