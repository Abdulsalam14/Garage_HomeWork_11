
CustomCollection<Employee>employees=new CustomCollection<Employee>();

while (true)
{
    Console.WriteLine(@"1-Add Employee
2-GetEmployeeByID
3-PrintAllEmployee
");
    bool isNumber = byte.TryParse(Console.ReadLine(), out byte select);
    if (!isNumber)
    {
        Console.WriteLine("Yanlis daxiletme");
    }
    if (select == 1)
    {
        Console.Write("Name:");
        string? Name = Console.ReadLine();
        Console.Write("Surname:");
        string? Surname = Console.ReadLine();
        Console.Write("Age:");
        bool isage = byte.TryParse(Console.ReadLine(), out byte age);
        if(string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Surname) || !isage)
        {
            Console.WriteLine("Yanlish daxiletme Employe elave olunmadi");
        }
        else
        {
            Employee temp = new Employee(Name,Surname, age,1000);
            employees.AddElement(temp);
            Console.WriteLine("Employe elave olundu");
        }
    }
    else if(select == 2)
    {
        Console.Write("Id:");
        bool isId = int.TryParse(Console.ReadLine(), out int id);
        if (isId)
        {
            var emp=employees.GetElementById(id);
            if (emp != null) Console.WriteLine(emp);
            else Console.WriteLine("Bu id de Employee yoxdur.");
        }
        else Console.WriteLine("Yanlis daxiletme");
    }
    else if (select == 3)
    {
        employees.PrintAll();
    }
    else Console.WriteLine("Yanlish daxiletme");
    if (!IsQuit()) break;
}


bool IsQuit()
{
    bool b = false;
    string? ans=null;
    while (!b)
    {
        Console.WriteLine("Davam etmek isteyirsiz? Yes or No");
        ans=Console.ReadLine();
        if (ans!.ToLower() == "yes" || ans.ToLower() == "no") b = true;
    }
    return ans!.ToLower() == "yes";
}

class CustomCollection<T> where T : Person
{
    private T[] arr=new T[0];
    public T? GetElementById(int id)=> id >= 0 && arr.Length > id ? arr[id] : null;

    public void  AddElement(T element)
    {
        Array.Resize(ref arr, arr.Length+1);
        arr[arr.Length-1] = element;
    }

    public void PrintAll()
    {
        if (arr.Length == 0)
        {
            Console.WriteLine("Employe yoxdur.");
            return;
        }
        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }
}

class Employee : Person
{
    public Employee(string? name, string? surname, byte age, double salary) : base(name, surname, age)
    {
        Salary = salary;
    }
    public double Salary { get; set; }
}

class Person
{
    public Person(string? name, string? surname, byte age)
    {
        Id = ++_id;
        Name = name;
        Surname = surname;
        Age = age;
    }

    static int _id = 0;
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }
    public byte Age { get; set; }

    public override string ToString()
    {
        return $"Name:{Name}\nSurname:{Surname}\nAge:{Age}\n";
    }
}

