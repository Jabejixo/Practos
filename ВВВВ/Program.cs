using System.ComponentModel;

namespace Практос4
{
/*
Тру стори сначала написал одну парашу в 3 три ночу (писал часов 7, да я долгий и что) решил что пора сдавать захожу в задание смотрю и понимаю что вообще не по тз, разозлился и в четверг за 4 часа до дедлайна
Начал писать уже по тз, но так как мне было жалко мой предыдущий код я решил интегрировать задание в уже ранее написанный кусок кала и получилось воть это, я думаю норм,а вам как кажется?)) 
*/
    internal class Program
    {
        static List<Note> notes = new List<Note>();
        static int menu = 1;
        static int position = 3, maxposition, minposition;
        static void Main()
        {
            ConsoleKey key;
            DateTime date = DateTime.Today;
            Diary diary = new Diary();
            var DaysNotes = from note in notes where note.date == date select note;
            Menu();
            bool check = true;
            maxposition = 7;
            minposition = 3;
            do
            {
                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        Menu();
                        break;
                    case 2:
                        Console.Clear();
                        SecondMenu(date);
                        break;
                    case 3:
                        Console.Clear();
                        thirdMenu(date, DaysNotes.ToList()[position - 1]);
                        break;
                }
                WriteCursor(position);
                key = Console.ReadKey().Key;
                position = CursorPosition(position, maxposition, minposition, key);
                switch (menu)
                {
                    case 1:
                        if (position == 3 && key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                            diary.AddEntry();
                        }
                        if (position == 4 && key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                            diary.SearchEntries();
                        }
                        if (position == 5 && key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                            diary.DeleteEntries();
                        }
                        if (position == 6 && key == ConsoleKey.Enter)
                        {
                            position = 1;
                            menu = 2;
                        }
                        if (position == 7 && key == ConsoleKey.Enter)
                        {
                            check = false;
                        }
                        break;
                    case 2:
                        minposition = 1;
                        maxposition = 3;
                        if (key == ConsoleKey.LeftArrow)
                        {
                            date = date.AddDays(-1);
                        }
                        if (key == ConsoleKey.RightArrow)
                        {
                            date = date.AddDays(1);
                        }
                        if (position == 1 && key == ConsoleKey.Enter)
                        {
                            menu = 3;
                        }
                        if (position == 2 && key == ConsoleKey.Enter)
                        {
                            AddingNotes(date, notes);
                        }
                        if (position == 3 && key == ConsoleKey.Enter)
                        {
                            maxposition = 7;
                            minposition = 3;
                            menu = 1;
                        }
                        break;
                }
            } while (check);
                
            }

        static void Menu()
        {
            Console.WriteLine("Сейчас: {0}", DateTime.Now);
            Console.WriteLine("\r\nВыберите действие:\r\n  1 - Добавить запись\r\n  2 - Найти запись\r\n  3 - Удалить запись\r\n  4 - Заметки по дням\r\n  5 - Выход из программы");
        }
        static void SecondMenu(DateTime date)
        {
                Console.WriteLine($"{date.ToString("D")}");
                Console.WriteLine("   1. Посмотреть заметки");
                Console.WriteLine("   2. Создать заметку");
                Console.WriteLine("   3. Выйти в предыдущее меню");
        }
        static void thirdMenu(DateTime date, Note note)
        {
            Console.Clear();
            Console.WriteLine($"{date.ToString("D")}");
            Console.WriteLine("/*-+/*-+/*-+/*-+/*-+/*-+/*-+/*-+/*-+/*-+/*-+");
            Console.WriteLine($"НАЗВАНИЕ:  {note.name}\r\n");
            Console.WriteLine($"СОДЕЖИМОЕ:  {note.text}");
            Console.WriteLine("/*-+/*-+/*-+/*-+/*-+/*-+/*-+/*-+/*-+/*-+/*-+");
            Console.WriteLine("Любую клавишу Escape(два раза) и тогда выйти сможешь ты");
            ConsoleKey key;
            key = Console.ReadKey().Key;
            if (key == ConsoleKey.Escape)
            {
                Console.Clear();
                position = 3;
                maxposition = 7;
                minposition = 3;
                menu = 1;
                return;
            }
            else
            {
                Console.WriteLine("Клавишу нажми Escape(два раза) и тогда выйти сможешь ты");
            }
        }
        static void AddingNotes(DateTime date, List<Note> notes)
        {
            Console.Clear();
            Console.WriteLine("Введите название заметки:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите основной текст заметки:");
            string text = Console.ReadLine();
            notes.Add(new Note() { date = date, name = name, text = text });
        }
        static int CursorPosition(int position, int maxposition, int minposition, ConsoleKey key)
            {
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        position--;
                        if (position < minposition)
                        {
                            position = minposition;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        position++;
                        if (position > maxposition)
                        {
                            position = maxposition;
                        };
                        break;
                }
                return position;
            }

        static void WriteCursor(int position)
        {
            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");
        }
    }
}