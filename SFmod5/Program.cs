using System;

namespace SFmod5
{
    class Program
    {
        static (string, string, int, bool, string[], int, string[]) CreateCortezh()
        {
            (string Name, string Surname, int Age, bool HavePet, string[] PetNames, int FavColorsCount, string[] FavColors) Cortezh;
            Cortezh.PetNames = new string[1] { "" };
            Console.WriteLine("Введите ваше имя:");
            Cortezh.Name = Console.ReadLine();
            Console.WriteLine("Введите вашу фамилию:");
            Cortezh.Surname = Console.ReadLine();
            Console.WriteLine("Ваш возраст:");
            Cortezh.Age = IsIntCorrect();
            Console.WriteLine("Есть ли у вас домашние животные? y/n");
            string havepets = CanItBeBool();
            Cortezh.HavePet = false;
            if (havepets == "y")
                Cortezh.HavePet = true;
            if(Cortezh.HavePet)
            {
                Console.WriteLine("Сколько у вас домашних животных?");
                int c = IsIntCorrect();
                Console.WriteLine("Введите их имена:");
                Cortezh.PetNames = AgrCreate(c);
            }
            Console.WriteLine("Сколько у вас любимых цветов?");
            Cortezh.FavColorsCount = IsIntCorrect();
            Console.WriteLine("Введите их названия:");
            Cortezh.FavColors = AgrCreate(Cortezh.FavColorsCount);
            return Cortezh;
        }
        static int IsIntCorrect()
        {
            while(true)
            {
                string possint = Console.ReadLine();
                if (int.TryParse(possint, out int ourint) && (ourint > 0))
                    return ourint;
                Console.WriteLine("Введите целое число больше 0");
            }
        }
        static string CanItBeBool()
        {
            while (true)
            {
                string possbool = Console.ReadLine();
                if ((possbool == "y")||(possbool == "n"))
                    return possbool;
                Console.WriteLine("Ответьте на этот вопрос в формате y/n");
            }
        }
        static string [] AgrCreate(int count)
        {
            string [] arg = new string[count];
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine("№" + (i + 1));
                arg[i] = Console.ReadLine();
            }
            return arg;
        }
        static void ShowCortezh((string Name, string Surname, int Age, bool HavePet, string[] PetName, int FavColorsCount, string[] FavColor) Cort)
        {
            Console.WriteLine("Ваше имя: " + Cort.Name);
            Console.WriteLine("Ваша фамилия: " + Cort.Surname);
            Console.WriteLine("Ваш возраст: " + Cort.Age);
            if (Cort.HavePet)
            {
                Console.WriteLine("У вас есть домашние животные. Их имена:");
                for (int i = 0; i < Cort.PetName.Length; i++)
                    Console.Write(Cort.PetName[i] + ", ");
                Console.WriteLine();
            }
            else
                Console.WriteLine("У вас нет домашних животных");
            Console.WriteLine("У вас {0} любимых цвета:", Cort.FavColorsCount);
            for(int i = 0; i < Cort.FavColorsCount; i ++)
                Console.Write(Cort.FavColor[i] + ", ");
        }
        static void Main(string[] args)
        {
            ShowCortezh(CreateCortezh());
        }
    }
}
