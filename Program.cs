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

            Console.WriteLine("***Программа ежедневник. Нажмите любую клавишу для продолжения...***");
            Console.ReadKey();

            bool flag = true;
            while (flag == true)
            {
                Console.Clear();       
                Console.WriteLine("***ГЛАВНОЕ МЕНЮ***");
                Console.WriteLine("1) Загрузить заметки из файла");
                Console.WriteLine("2) Выгрузить заметки в файл");
                Console.WriteLine("3) Создать заметку");
                Console.WriteLine("4) Редактировать заметку");
                Console.WriteLine("5) Удалить заметку");
                Console.WriteLine("6) Сортировать заметки");
                Console.WriteLine("7) Выход");

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        break;
                    case '2':
                        break;
                    case '3':
                        break;
                    case '4':
                        break;
                    case '5':
                        break;
                    case '6':
                        break;
                    case '7':
                        flag = false;
                        break;
                    default:
                        break;
                }
            }
           
        }

        public static void PrintNotes(Note[] notes)
        {
            Console.Clear();
            foreach (var note in notes)
            {
                Console.WriteLine($"Заметка №{note.Index}. {note.Date}. {note.Caption}\n{note.Description}\nАвтор:{note.Author}\nКатегория:{note.Category}\n\n");
            }
        }

        public static void AddNote(Notebook notebook)
        {
            int noteIndex = notebook.Notes.Length;
            Console.WriteLine($"Добавление записи: Запись №{noteIndex}");
            Console.Write($"Введите время: ");
            DateTime noteDataTime = DateTime.Parse(Console.ReadLine());
            Console.Write($"Введите название заметки: ");
            string noteCaption = Console.ReadLine();
            Console.Write($"Введите описание заметки: ");
            string noteDescription = Console.ReadLine();
            Console.Write($"Введите автора заметки: ");
            string noteAuthor = Console.ReadLine();
            Console.Write($"Введите категорию заметки: ");
            string noteCategory = Console.ReadLine();

            notebook.AddNote(noteIndex, noteDataTime, noteCaption, noteDescription, noteAuthor, noteCategory);
        }
    }

}
