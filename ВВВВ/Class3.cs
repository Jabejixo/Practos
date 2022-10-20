using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практос4
{
    class Diary
    {

        private Database database;

        public Diary()
        {
            database = new Database();
        }
        private DateTime ReadDateTime()
        {
            Console.WriteLine("Введите дату и время (время не обязательно, можно записать так: [13/10] ) образец: [13/10/2022 14:53]:");
            DateTime dateTime;
            while (!DateTime.TryParse(Console.ReadLine(), out dateTime))
                Console.WriteLine("Ошибка пожалуйста повторите: ");
            return dateTime;
        }
        public void PrintEntries(DateTime day)
        {
            List<Entry> entries = database.FindEntries(day, false);
            foreach (Entry entry in entries)
                Console.WriteLine(entry);
        }
        public void AddEntry()
        {
            DateTime dateTime = ReadDateTime();
            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine();
            database.AddEntry(dateTime, text);
        }
        public void SearchEntries()
        {
            DateTime dateTime = ReadDateTime();
            List<Entry> entries = database.FindEntries(dateTime, false);
            if (entries.Count() > 0)
            {
                Console.WriteLine("Вот найденная запись: ");
                foreach (Entry entry in entries)
                    Console.WriteLine(entry);
            }
            else
                Console.WriteLine("Записи не найдены.");
        }
        public void DeleteEntries()
        {
            DateTime dateTime = ReadDateTime();
            database.DeleteEntries(dateTime);
        }

    }
}
