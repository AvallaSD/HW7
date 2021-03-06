﻿using System;
using System.IO;
using System.Linq;

namespace HW7
{
    /// <summary>
    /// Класс, содержащий в себе заметки и методы работы с ними.
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
        /// Перечисление режимов чтения: добавление и замещение
        /// </summary>
        public enum ReadMode
        {
            Add,
            Replace
        }

        /// <summary>
        /// Массив записок
        /// </summary>
        public Note[] Notes { get; private set; }

        /// <summary>
        /// Конструктор. Инициализирует пустой ежедневник
        /// </summary>
        public Notebook()
        {
            Notes = new Note[0];
        }


        /// <summary>
        /// Загружает заметки из файла, имеющего указанный путь. Выбор режима загрузки: добавить или заменить. Выбор диапазона времени и дат
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="mode">Режим загрузки</param>
        /// <param name="dateFrom">Дата и время От</param>
        /// <param name="dateTo">Дата и время До</param>
        public void ReadFromFile(ReadMode mode, string path, DateTime dateFrom, DateTime dateTo)
        {
            if (mode == ReadMode.Replace)
            {
                Notes = new Note[0];
            }

            if (path == "") path = "input.txt";

            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var firstStringProrerties = reader.ReadLine().Split(". ");
                    var noteIndex = int.Parse(firstStringProrerties[0].Skip(9).ToArray());
                    var noteDate = DateTime.Parse(firstStringProrerties[1]);
                    var noteCaption = firstStringProrerties[2];
                    var noteDescription = reader.ReadLine();
                    var noteAuthor = new string(reader.ReadLine().Skip(6).ToArray());
                    var noteCategory = new string(reader.ReadLine().Skip(10).ToArray());

                    Note note = new Note(noteIndex, noteDate, noteCaption, noteDescription, noteAuthor, noteCategory);

                    if (noteDate > dateFrom && noteDate < dateTo)
                    {
                        Notes = Notes.Append(note).ToArray();
                    }
                    Notes = Notes.Append(note).ToArray();

                    reader.ReadLine();
                    reader.ReadLine();
                }
            }
        }

        /// <summary>
        /// Добавление заметки
        /// </summary>
        public void AddNote(int noteIndex, DateTime noteDateTime, string noteCaption, string noteDescription, string noteAuthor, string noteCategory)
        {


            Note note = new Note(noteIndex, noteDateTime, noteCaption, noteDescription, noteAuthor, noteCategory);
            Notes = Notes.Append(note).ToArray();
        }

        /// <summary>
        /// Удаление заметки по ее индексу
        /// </summary>
        /// <param name="index"></param>
        public void DeleteByIndex(int index)
        {
            var tmpList = Notes.ToList();
            tmpList.RemoveAt(index);
            Notes = tmpList.ToArray();
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
                    Notes[index].Date = DateTime.Parse(Console.ReadLine());
                    break;
                case "2":
                    Console.WriteLine("Введите название:");
                    Notes[index].Caption = Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("Введите описание:");
                    Notes[index].Description = Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine("Введите автора:");
                    Notes[index].Author = Console.ReadLine();
                    break;
                case "5":
                    Console.WriteLine("Введите категорию:");
                    Notes[index].Category = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Неверный ввод");
                    break;
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
                    Notes = Notes.OrderBy(x => x.Index).ToArray();
                    break;
                case NoteProperties.Date:
                    Notes = Notes.OrderBy(x => x.Date).ToArray();
                    break;
                case NoteProperties.Caption:
                    Notes = Notes.OrderBy(x => x.Caption).ToArray();
                    break;
                case NoteProperties.Description:
                    Notes = Notes.OrderBy(x => x.Description).ToArray();
                    break;
                case NoteProperties.Author:
                    Notes = Notes.OrderBy(x => x.Author).ToArray();
                    break;
                case NoteProperties.Category:
                    Notes = Notes.OrderBy(x => x.Category).ToArray();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Запись заметок в файл
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void WriteInFile(string path)
        {
            if (path == "")
            {
                path = "output.txt";
            }
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var note in Notes)
                {
                    writer.WriteLine($"Заметка №{note.Index}. {note.Date}. {note.Caption}");
                    writer.WriteLine(note.Description);
                    writer.WriteLine($"Автор:{note.Author}");
                    writer.WriteLine($"Категория:{note.Category}\n\n");
                }
            }
        }

        public void CorrectIndexes()
        {
            if (Notes.Select(x => x.Index) == Notes.Select(x => x.Index).Distinct())
            {
                return;
            }
            else
            {
                for (int i = 0; i < Notes.Length; i++)
                {
                    while (Notes.Select(x => x.Index).Contains(Notes[i].Index))
                    {
                        Notes[i].Index++;
                    }              
                }
            }
        }
    }
}
