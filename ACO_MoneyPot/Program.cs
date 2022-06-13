namespace ACO_MoneyPot
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Console.WriteLine("$$$ MONEY POT $$$");

            int users = 0;
            while (users == 0)
            {
                users = GetUserCount();
            }
            Console.WriteLine($"Total Users: {users}");

            people people = GetPeopleData(users);

            people.sum = SumTotalSpent(people);
            Console.WriteLine($"Total Spent: {people.sum}");

            foreach (person p in people.persons)
            {
                people.split = people.sum / people.totalUsr;
                p.diff = people.split - p.spent;
            }


            foreach (person person in people.persons)
            {
                Console.WriteLine($"{person.id} | {person.name} | {person.spent} | {person.diff}");
            }

        }

        static int GetUserCount()
        {
            Console.Write("Please Enter a number of users: ");
            string u = Console.ReadLine();
            int usrs = 0;
            try
            {
                usrs = Convert.ToInt32(u);
            }
            catch
            {
                Console.WriteLine("Please Enter valid number...");
            }

            return usrs;
        }

        class people
        {
            public int totalUsr { get; set; }
            public List<person> persons { get; set; }
            public decimal sum { get; set; }
            public decimal split { get; set; }
        }

        class person
        {
            public int id { get; set; }
            public string name { get; set; }
            public decimal spent { get; set; }
            public decimal diff { get; set; }
        }

        static decimal SumTotalSpent(people p)
        {
            decimal sum = 0;
            foreach (person person in p.persons)
            {
                if (person.spent > 0)
                {
                    sum = sum + person.spent;
                }
            }
            return sum;
        }

        static people GetPeopleData(int users)
        {
            people people = new people();
            people.totalUsr = users;
            people.persons = new List<person>();

            for (int i = 0; i < users; i++)
            {
                Console.Write($"What is {i}'s Name: ");
                string name = Console.ReadLine();

                Console.Write($"How have has {name} spent?: ");
                decimal spent = Convert.ToDecimal(Console.ReadLine());

                person p = new person();

                p.id = i;
                p.name = name;
                p.spent = spent;

                people.persons.Add(p);

                Console.WriteLine();
            }
            return people;
        }
    }
}