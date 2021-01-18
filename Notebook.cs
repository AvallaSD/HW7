using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_07
{
    /// <summary>
    /// Класс, содержащий в себе заметки, события и расписания и методы работы с ними.
    /// </summary>
    class Notebook
    {
        /// <summary>
        /// Перечисление полей записок
        /// </summary>
        public enum NoteProperties
        {
            Index, Date, Caption, Description, Author, Category
        }

        /// <summary>
        /// Массив записок
        /// </summary>
        private Note[] notes;

        public Notebook()
        {
            notes = new Note[0];
            
        }

        /// <summary>
        /// Загружает заметки из файла. ПРОВЕРИТЬ!!!
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void ReadFromFile(string path = "input.txt")
        {
            notes = new Note[0];
            using (StreamReader reader = new StreamReader(path))
            {
                while (reader.EndOfStream)
                {
                    var firstStringProrerties = reader.ReadLine().Split(". ");
                    var noteIndex = int.Parse(firstStringProrerties[0].Skip(9).ToArray());
                    var noteDate = DateTime.Parse(firstStringProrerties[1]);
                    var noteCaption = firstStringProrerties[2];
                    var noteDescription = reader.ReadLine();
                    var noteAuthor = new string(reader.ReadLine().Skip(6).ToArray());
                    var noteCategory = new string(reader.ReadLine().Skip(10).ToArray());
                    
                    Note note = new Note(noteIndex, noteDate, noteCaption, noteDescription, noteAuthor, noteCategory);
                    notes = notes.Append(note).ToArray();

                    reader.ReadLine();
                    reader.ReadLine();
                }
            }
        }


        /// <summary>
        /// Добавление заметки
        /// </summary>
        public void AddNote()
        {
            int noteIndex = notes.Length;
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

            Note note = new Note(noteIndex, noteDataTime, noteCaption, noteDescription, noteAuthor, noteCategory);
            notes = notes.Append(note).ToArray();
        }

        /// <summary>
        /// Удаление заметки по ее индексу
        /// </summary>
        /// <param name="index"></param>
        public void DeleteByIndex(int index)
        {
            var tmpList = notes.ToList();
            tmpList.RemoveAt(index);
            notes = tmpList.ToArray();
        }

        /// <summary>
        /// Редактирование заметки по ее индексу
        /// </summary>
        /// <param name="index"></param>
        public void EditByIndex(int index)
        {
            Console.WriteLine($"Редактрирование заметки {index}. Выберите свойство, которе хотите изменить:\n1) Дата и время\n2) Название\n3) Описание\n4) Автор\n5) Категория");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Введите дату и время:");
                    notes[index].Date = DateTime.Parse(Console.ReadLine());
                    break;
                case "2":
                    Console.WriteLine("Введите название:");
                    notes[index].Caption = Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("Введите описание:");
                    notes[index].Description = Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine("Введите автора:");
                    notes[index].Author = Console.ReadLine();
                    break;
                case "5":
                    Console.WriteLine("Введите категорию:");
                    notes[index].Category = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Неверный ввод");
                    break;
            }
        }

        /// <summary>
        /// Печать всех заметок в консоль
        /// </summary>
        public void Print()
        {
            Console.Clear();
            foreach (var note in notes)
            {
                Console.WriteLine($"Заметка №{note.Index}. {note.Date}. {note.Caption}\n{note.Description}\nАвтор:{note.Author}\nКатегория:{note.Category}\n\n");
            }
        }

        /// <summary>
        /// Сортировка заметок по одному из свойств
        /// </summary>
        /// <param name="noteProperties">Свойство, являющееся ключом для сортировки</param>
        public void Sort(NoteProperties noteProperties)
        {
            switch (noteProperties)
            {
                case NoteProperties.Index:
                    notes = notes.OrderBy(x => x.Index).ToArray();
                    break;
                case NoteProperties.Date:
                    notes = notes.OrderBy(x => x.Date).ToArray();
                    break;
                case NoteProperties.Caption:
                    notes = notes.OrderBy(x => x.Caption).ToArray();
                    break;
                case NoteProperties.Description:
                    notes = notes.OrderBy(x => x.Description).ToArray();
                    break;
                case NoteProperties.Author:
                    notes = notes.OrderBy(x => x.Author).ToArray();
                    break;
                case NoteProperties.Category:
                    notes = notes.OrderBy(x => x.Category).ToArray();
                    break;
                default:
                    break;
            }
        }
    }
}
