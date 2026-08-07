namespace w11b
{
    class Student 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }

        public void PrintDetails()
        {
            Console.WriteLine($"First Name: {FirstName}");
            Console.WriteLine($"Last Name: {LastName}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Gender: {Gender}");
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate students
            Student student1 = new Student
            {
                FirstName = "John",
                LastName = "Smith",
                Age = 18,
                Gender = "M",
                Department = "Computer Science"
            };

            Student student2 = new Student
            {
                FirstName = "Emily",
                LastName = "Johnson",
                Age = 17,
                Gender = "F",
                Department = "Fine Arts"
            };

            Student student3 = new Student
            {
                FirstName = "Michael",
                LastName = "Williams",
                Age = 19,
                Gender = "M",
                Department = "Mechanical Engineering"
            };

            // Print details of students
            Console.WriteLine("Student 1 Details:");
            student1.PrintDetails();

            Console.WriteLine("Student 2 Details:");
            student2.PrintDetails();

            Console.WriteLine("Student 3 Details:");
            student3.PrintDetails();
        }
    }

}
