using System.Text;

namespace String1125_2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // строки
            //string - ссылочный тип данных
            //string хранит внутри себя char[] 
            //string может хранить большое кол-во текста в одной переменной
            //главное, чтобы хватало ОЗУ
            //значение строки хранится в области памяти "куча"
            //string - неизменяемый тип данных
            // простое назначение
            string text = "произвольный текст";
            // null - пустая ссылка
            text = null; // нельзя вывести через Console.Write();
            // переменная string может вести себя как char[]
            // но только для чтения
            //char ch1 = text[1];

            text = "text1 "; // в переменную содержащую null добавляется значение
            // конкатенация (сложение строк) 
            // создается новая строка, ссылка text указывает
            // на новую строку
            text += "text2";
            Console.WriteLine(text);
            string newText = text.Remove(1);
            Console.WriteLine(newText);
            Console.WriteLine(text);

            for (int i = 0; i < 1000; i++)
                newText = "первая " + "вторая " + "третья " + "строка";

            //"первая вторая "
            //"первая вторая третья "
            //"первая вторая третья строка"

            // интернирование строки - сохранение строки в памяти
            // в единственном экземпляре
            // работает автоматически с литералами
            // интернированные строки не удаляются из памяти

            // сравнение строк
            // == на равенство 
            // != на неравенство

            // == для ссылочных типов проверяет совпадение по ссылке
            // для строк == будет проверять сначала совпадение по ссылке
            // затем (в случае разных ссылок) будет проверять алфавит
            // строки регистрозависимые

            string inter1 = "sample";
            // строку можно интернировать вручную
            // это подходит только для малого кол-ва строк
            // использующихся в программе постоянно!
            string inter2 = string.Intern(Console.ReadLine());

            Console.WriteLine(inter1 == inter2);
            Console.WriteLine(inter2.Equals(inter1));
            // ReferenceEquals - сравнение по ссылке
            Console.WriteLine(ReferenceEquals(inter1, inter2));

            // длину текста можно узнать через свойство Length
            int charCount = text.Length;
            inter1 = "no text";
            text = "some text end";

            bool check = text.Contains(inter1);// false
            check = text.EndsWith("end");//true
            check = text.EndsWith('d');//true
            check = text.StartsWith("some"); // true
            // обрезка текста от лишних пробелов 
            inter1 = text.Trim(); // с обеих сторон
            inter1 = text.TrimStart(); // слева
            inter1 = text.TrimEnd(); // справа

            // вставка подстроки, начиная с индекса 2
            inter1 = text.Insert(2, "substring");
            // увеличение строки до указанной длины
            // путем добавления пробелов
            inter1 = text.PadLeft(10); // слева
            inter1 = text.PadRight(10);// справа

            // заменить все подстроки inter1 подстрокой inter2
            inter1 = text.Replace(inter1, inter2);
            inter1 = text.Replace('a', 'э');
            // разделение строки на массив подстрок, используя
            // указанные разделители (по умолчанию пробел)
            string[] array = text.Split();
            char[] splitters = new char[] { ' ', ',', '.' };
            // разделить строку с помощью пробелов, запятых и точек
            array = text.Split(splitters);
            // выделение подстроки, начиная с заданного индекса (0)
            // указанной длины (5)
            inter1 = text.Substring(0, 5);

            // строку можно перебрать с помощью foreach
            foreach (char c in text)
            {
                Console.WriteLine(c);
            }

            //строки хранят текст в utf-16 (но бывают исключения)
            //по 2 байта на символ

            // 12.21
            /* Дано слово. Получить его часть, образованную идущими 
            подряд буквами, начиная с m-й и заканчивая n-й
            */
            string word = Console.ReadLine();
            Console.Write("m - ");
            int.TryParse(Console.ReadLine(), out int m);
            Console.Write("n - ");
            int.TryParse(Console.ReadLine(), out int n);

            // т.к. строка это массив, при попытке получить значение
            // по несуществующему индексу мы получим исключение (программа грохнется)
            if (m < 0 ||
                m >= word.Length ||
                m >= n ||
                n >= word.Length)
            { 
                Console.WriteLine("до свидания");
                return;
            }
            // через метод Substring
            int lastIndex = n - m + (m > 0 ? 1 : 0);
            string result = word.Substring(m, lastIndex);
            Console.WriteLine(result);

            // второй вариант (плохой)
            result = "";
            for (int i = m; i <= n; i++)
                result += word[i]; // в каждой итерации создается новая строка и засоряет собой память
            Console.WriteLine(result);

            // StringBuilder нужен для задач,
            // когда требуется собирать строку из множества
            // подстрок
            // StringBuilder не создает промежуточные строки
            // он работает с массивом символов, который может увеличиваться
            StringBuilder sb = new StringBuilder(2000);
            sb.Append(10);
            sb.AppendLine("текст").Append('ы');
            for (int i = 0; i < 5; i++)
                sb.Append(i);
            // получение итоговой строки
            result = sb.ToString();
        }
    }
}
