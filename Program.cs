using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_07
{
    class Program
    {
        static void Main(string[] args)
        {
            /// Разработать ежедневник.
            /// В ежедневнике реализовать возможность 
            /// - создания
            /// - удаления
            /// - реактирования 
            /// записей
            /// 
            /// В отдельной записи должно быть не менее пяти полей
            /// 
            /// Реализовать возможность 
            /// - Загрузки даннах из файла
            /// - Выгрузки даннах в файл
            /// - Добавления данных в текущий ежедневник из выбранного файла
            /// - Импорт записей по выбранному диапазону дат
            /// - Упорядочивания записей ежедневника по выбранному полю

            Notebook notebook = new Notebook();
            notebook.ReadFromFile(Notebook.ReadMode.Replace);
            PrintNotes(notebook.Notes);
            notebook.DeleteByIndex(2);
            PrintNotes(notebook.Notes);
            Console.ReadKey();
        }

        public static void PrintNotes(Note[] notes)
        {
            Console.Clear();
            foreach (var note in notes)
            {
                Console.WriteLine($"Заметка №{note.Index}. {note.Date}. {note.Caption}\n{note.Description}\nАвтор:{note.Author}\nКатегория:{note.Category}\n\n");
            }
        }
    }
}
