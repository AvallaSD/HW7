using System;
using System.Linq;

namespace HW7
{
    class NotebookConsoleManager
    {
        Notebook notebook;

        public NotebookConsoleManager()
        {
            notebook = new Notebook();
        }

        public void Run()
        {
            notebook.ReadFromFile(Notebook.ReadMode.Replace, "index.txt", DateTime.MinValue, DateTime.MaxValue);
            OpenMainMenu();
        }

        private void OpenMainMenu()
        {
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
                        ReadFromFile();
                        break;
                    case '2':
                        WriteInFile();
                        break;
                    case '3':
                        AddNote();
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

        private void PrintNotes()
        {
            Console.Clear();
            foreach (var note in notebook.Notes)
            {
                Console.WriteLine($"Заметка №{note.Index}. {note.Date}. {note.Caption}\n{note.Description}\nАвтор:{note.Author}\nКатегория:{note.Category}\n\n");
            }
        }

        private void AddNote()
        {
            int noteIndex = 0;
            while (notebook.Notes.Select(x => x.Index).Contains(noteIndex))
            {
                noteIndex++;
            }

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

        private void ReadFromFile()
        {
            Console.Clear();
            Console.WriteLine("Подготовка чтения данных из файла. Укажите путь. При отсутствии ввода будет считан файл по умолчанию");
            string path = Console.ReadLine();

            Console.WriteLine("Выберите режим чтения:\n1) Заменить уже существующие данные\n2) Добавить к существующим данным");
            Console.WriteLine("Внимание! При совпадении индексов уже существующих заметок и добавляемых индексы будут переназначены");

            Notebook.ReadMode readMode;
            switch (Console.ReadLine())
            {
                case "1":
                    readMode = Notebook.ReadMode.Replace;
                    break;
                case "2":
                    readMode = Notebook.ReadMode.Add;
                    break;
                default:
                    Console.WriteLine("Неверный ввод. Возврат в главное меню.");
                    Console.ReadKey();
                    return;
            }

            Console.WriteLine("Хотите ввести диапазон дат?:\n1) Да\n2) Нет");
            DateTime dateFrom = DateTime.Now;
            DateTime dateTo = DateTime.Now;
            bool dateFlag = false;
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    Console.WriteLine("Введите дату *От*: ");
                    if (!DateTime.TryParse(Console.ReadLine(), out dateFrom))
                    {
                        Console.WriteLine("Неверный ввод. Возврат в главное меню.");
                        Console.ReadKey();
                        return;
                    }
                    Console.WriteLine("Введите дату *До*: ");
                    if (!DateTime.TryParse(Console.ReadLine(), out dateTo))
                    {
                        Console.WriteLine("Неверный ввод. Возврат в главное меню.");
                        Console.ReadKey();
                        return;
                    }
                    dateFlag = true;
                    break;

                case '2':
                    break;

                default:
                    Console.WriteLine("Неверный ввод. Возврат в главное меню.");
                    Console.ReadKey();
                    return;
            }

            if (path != "")
            {
                if (dateFlag)
                {
                    notebook.ReadFromFile(readMode, path, dateFrom, dateTo);
                }
                else
                {
                    notebook.ReadFromFile(readMode, path, DateTime.MinValue, DateTime.MaxValue);
                }
            }
            else
            {
                if (dateFlag)
                {
                    notebook.ReadFromFile(readMode, path, dateFrom, dateTo);
                }
                else
                {
                    notebook.ReadFromFile(readMode, path, DateTime.MinValue, DateTime.MaxValue);
                }
            }
            notebook.CorrectIndexes();
        }

        private void WriteInFile()
        {
            Console.Clear();
            Console.WriteLine("Подготовка записи данных в файлй. Укажите путь. При отсутствии ввода запись будет произведена в файл по умолчанию");
            string path = Console.ReadLine();

            notebook.WriteInFile(path);
        }

        private void EditNote()
        {
            Console.WriteLine("Введите индекс редактируемой заметки:");
            if (!int.TryParse(Console.ReadLine(), out int index))
            {
                Console.WriteLine("Неверный ввод. Возврат в главное меню.");
                Console.ReadKey();
                return;
            }        

            Console.WriteLine($"Редактрирование заметки {index}. Выберите свойство, которе хотите изменить:");

            var fieldsList = typeof(Note).GetFields().ToList();
            fieldsList.ForEach(x => Console.WriteLine($"{fieldsList.IndexOf(x)}){x.Name}"));

            if (!int.TryParse(Console.ReadLine(), out int des))
            {
                Console.WriteLine("Неверный ввод. Возврат в главное меню.");
                Console.ReadKey();
                return;
            }

            var selectedField = fieldsList[Console.ReadLine()]
        }
    }
}
