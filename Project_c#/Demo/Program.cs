using System.Collections.Generic;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Demo
{
    internal class Program
    {
        public static List<Question> EnterAllQuestions()
        {
            string header1 = "Select One Option Only";
            string header2 = "Choose any applicable choices";
            string header3 = "Select True or False";
            List<Question> list = new List<Question>();

            AnswerList answer1 = new AnswerList() { };
            answer1.Add(new Answer("inherits"));
            answer1.Add(new Answer("not inheritable"));
            answer1.Add(new Answer("sealed"));
            answer1.Add(new Answer("extends"));

            AnswerList answer2 = new AnswerList() { };
            answer2.Add(new Answer("Generics require use of explicit type casting."));
            answer2.Add(new Answer("Generics provide type safety without the overhead of multiple implementations."));
            answer2.Add(new Answer("Generics eliminate the possibility of run-time errors."));
            answer2.Add(new Answer("None of the above."));

            AnswerList answer4 = new AnswerList() { };
            answer4.Add(new Answer("Constructors cannot be overloaded."));
            answer4.Add(new Answer("Constructors always have the name same as the name of the class."));
            answer4.Add(new Answer("Constructors are never called explicitly."));
            answer4.Add(new Answer("Constructors never return any value."));

            AnswerList answer5 = new AnswerList() { };
            answer5.Add(new Answer("Integer"));
            answer5.Add(new Answer("Long"));
            answer5.Add(new Answer("String"));
            answer5.Add(new Answer("Array"));

            AnswerList answer6 = new AnswerList() { };
            answer6.Add(new Answer("Structures can be declared within a procedure"));
            answer6.Add(new Answer("Structures can implement an interface but they cannot inherit from another structure"));
            answer6.Add(new Answer("Structure members cannot be declared as protected"));
            answer6.Add(new Answer("A structure cannot be empty"));

            AnswerList answer7 = new AnswerList() { };
            answer7.Add(new Answer("A structure can contain properties"));
            answer7.Add(new Answer("A structure can contain constructors"));
            answer7.Add(new Answer("A structure can contain protected data members"));
            answer7.Add(new Answer("A structure can contain constants"));

            AnswerList answer8 = new AnswerList() { };
            answer8.Add(new Answer("Math"));
            answer8.Add(new Answer("Process"));
            answer8.Add(new Answer("System"));
            answer8.Add(new Answer("Object"));

            AnswerList answer3 = new AnswerList() { };
            answer3.Add(new Answer("True"));
            answer3.Add(new Answer("False"));

            TrueOrFalse q1 = new TrueOrFalse(1, header3, "Multiple inheritance is different from multiple levels of inheritance."
            , 1, ["True"], answer3);
            list.Add(q1);
            TrueOrFalse q2 = new TrueOrFalse(2, header3, "We can derive a class from a base class even if the base class's source code is not available."
            , 1, ["True"], answer3);
            list.Add(q2);
            ChooseOne q4 = new ChooseOne(3, header1, "A derived class can stop virtual inheritance by declaring an override as"
            , 1, ["C"], answer1);
            list.Add(q4);
            ChooseOne q5 = new ChooseOne(4, header1, "Which of the following statements is valid about advantages of generics?"
            , 1, ["B"], answer2);      
            list.Add(q5);
            ChooseAll q6 = new ChooseAll(5, header2, "Which of the following statements are correct about constructors in C#.NET?", 1,
            ["B", "C","D"], answer4);
            list.Add(q6);
            ChooseAll q7= new ChooseAll(6, header2, "Which of the following are value types?", 1,
            ["A", "B"], answer5);
            list.Add(q7);

            TrueOrFalse q3 = new TrueOrFalse(7, header3, "The size of a derived class object is equal to the sum of sizes of data members in base class only."
            , 1, ["False"], answer3);
            list.Add(q3);
            ChooseOne q8 = new ChooseOne(8, header1, "Choose the wrong statement about structures in C#.NET?"
            , 1, ["C"], answer6);
            list.Add(q8);
            ChooseOne q9 = new ChooseOne(9, header1, "Select the wrong statements among the following?"
            , 1, ["C"], answer7);
            list.Add(q9);
            ChooseOne q10 = new ChooseOne(10, header1, "Which of these classes contains only floating point functions?"
            , 1, ["A"], answer8);
            list.Add(q10);

            return list;
        }

        static public T VerifyAccess<T>(List<T> list) where T : Login
        {
            int attempts = 3; // Number of allowed attempts

            while (attempts > 0)
            {
                int Id;
                int password;
                Console.Write("\nEnter your id     :  ");
                int.TryParse(Console.ReadLine(), out Id);
                Console.Write("Enter your password :  ");
                int.TryParse(Console.ReadLine(), out password);
                foreach (var item in list)
                {
                    if (item.Id == Id && item.Password == password)
                    {
                        Console.ForegroundColor = ConsoleColor.Green; 
                        Console.WriteLine("\nYou are logged in successfully.");
                        Console.ResetColor();
                        return item;
                    }
                }
                attempts--;
                Console.ForegroundColor = ConsoleColor.Red; 
                Console.WriteLine("\nInvalid Id or password. Please try again.");
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou have exceeded the maximum number of attempts. Exiting the program...");
            Console.ResetColor();
            Environment.Exit(0); 
            return default;

        }
        static public void EnterDate(ref DateTime startDate)
        {
            while (true)
            {
                Console.Write("Enter the exam start date (yyyy-MM-dd): ");
                string inputDate = Console.ReadLine();

                if (DateTime.TryParse(inputDate, out startDate))
                {
                    if (startDate >= DateTime.Today)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Exam scheduled for: {startDate:yyyy-MM-dd}");
                        Console.ResetColor();
                        return;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The date must be today or in the future. Please try again.");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Invalid date format. Use yyyy-MM-dd. Try again.");
                }
                Console.ResetColor();
            }
        }

        static public void EnterMode(ref StartingMode mode)
        {
            while (true)
            {
                Console.WriteLine("Enter the mode for the exam:");
                Console.WriteLine("1: Starting");
                Console.WriteLine("2: Queued");
                Console.WriteLine("3: Finished");
                Console.Write("Enter : ");
                int input = int.Parse(Console.ReadLine());
                if ((Enum.IsDefined(typeof(StartingMode), input)))
                {
                    mode = (StartingMode)input;
                    Console.WriteLine($"You selected: {mode}");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please choose a valid mode.try again ..");
                }
            }
        }
        static void DisplayMenu()
        {
            Console.WriteLine("Select your role:");
            Console.WriteLine("1. Instructor");
            Console.WriteLine("2. Student");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice (1/2/3): ");
        }
        static void Main(string[] args)
        {
            Student student = new Student(5555, "Ahmed", 5555, new Subject("C# programming"));
            Instructor Ins = new Instructor(1111, "Aya", 1111, new Subject("C# programming")); ;

            Instructor Ins1 = new Instructor(100, "Aya", 35388, new Subject("C# programming"));
            Instructor Ins2 = new Instructor(101, "Sama", 56578, new Subject("Java programming"));
            Instructor Ins3 = new Instructor(102, "Salma", 67689, new Subject("Python programming"));
            List<Instructor> Inslist = new List<Instructor>();
            Inslist.Add(Ins1);
            Inslist.Add(Ins2);
            Inslist.Add(Ins3);

            Student st1 = new Student(1001, "Ahmed", 12345, new Subject("C# programming"));
            Student st2 = new Student(1002, "Mohamed", 67890, new Subject("C# programming"));
            Student st3 = new Student(1003, "Amr", 54321, new Subject("C# programming"));
            Student st4 = new Student(1004, "Ahmed", 3367, new Subject("C# programming"));
            Student st5 = new Student(1005, "Mohamed", 45446, new Subject("C# programming"));
            Student st6 = new Student(1006, "Amr", 67835, new Subject("C# programming"));
            List<Student> Stulist = new List<Student>();            
            Stulist.Add(st1);
            Stulist.Add(st2);
            Stulist.Add(st3);
            Stulist.Add(st4);
            Stulist.Add(st5);
            Stulist.Add(st6);

           string File = "E:\\C#\\Project_c#\\Demo\\QuestionListFile.txt";

            while (true)
            {
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("*************************************************************************************************");
                Console.WriteLine("************************* Welcome to the Examination System! ************************************");
                Console.WriteLine("*************************************************************************************************");
                DisplayMenu();

                int choice = 0;
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:                       
                        Console.WriteLine("Welcome, Instructor!");
                        Ins = VerifyAccess(Inslist);
                        
                        while (Ins != null)
                        {
                            Thread.Sleep(2000);
                            Console.Clear();
                            Console.WriteLine("========== Main Menu ==========");
                            Console.WriteLine("0 - Exit");
                            Console.WriteLine("1 - Enter questions into a file");
                            Console.WriteLine("2 - Schedule the exam");
                            Console.WriteLine("3 - Notify students to start the exam");
                            Console.WriteLine("4 - View grades of all students in this subject");
                            Console.WriteLine("================================");
                            Console.Write("Enter your choice: ");
                            int Select = int.Parse(Console.ReadLine());
                            if (Select == 0) break;
                            switch (Select)
                            {
                                case 1:                               
                                    Ins.AddQuestionsFile(EnterAllQuestions(), File);                                   
                                    break;
                                case 2:
                                                            
                                    DateTime startDate = DateTime.Now;
                                    EnterDate(ref startDate);

                                    StartingMode mode = StartingMode.Starting;
                                    EnterMode(ref mode);

                                    Console.Write("Enter number of questions in exam : ");
                                    int num = 0;
                                    int.TryParse(Console.ReadLine(),out num);
                                    Ins.exam = new Exam(startDate, num, mode);
                                    Console.WriteLine("The exam has been added successfully.");
                                    
                                    break;
                                case 3:
                                    Ins.exam.AddToDict(File);

                                    foreach (Student stu in Stulist)
                                    {
                                        if (stu.Subject.NameSubject == Ins.Subject.NameSubject)
                                        {
                                            Ins.AddStudentToExam(stu);                                            
                                            Ins.NotifyExam += stu.NotifyStudent;
                                            Console.WriteLine($"notify : {stu}");
                                        }
                                    }
                                    if (Ins.exam.mode == StartingMode.Starting)
                                        Console.WriteLine("All students have been successfully notified in this subject.");
                                    else
                                        Console.WriteLine("Not allow to notify students in the exam because the mode is Queued or Finished.");
                                    
                                    break;
                                case 4:
                                    Ins.ListOfDegreeOfStudent();
                                    break;
                                default:
                                    Console.WriteLine("Invalid input. Please enter either 1 or 2 or 3 or 4.");
                                    break;
                            }
                        }                        
                        break;
                    case 2:
                        Console.WriteLine("Welcome, Student!");
                        student = VerifyAccess(Stulist);                        
                        Ins.NotifyExamMode(student);
                        Ins.NotifyExam -= student.NotifyStudent;
                        Thread.Sleep(100);
                        break;
                    case 3:
                        Console.WriteLine("Exiting the program. Goodbye!");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter either 1 or 2.");
                        break;
                }
            }



        }
    }
}
