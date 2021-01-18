using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_07
{
    /// <summary>
    /// Заметка
    /// </summary>
    class Note
    {
       
        /// <summary>
        /// Индекс
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Caption { get; set; }
        
        /// <summary>
        /// Описание заметки
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Автор заметки
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Категория
        /// </summary>
        public string Category { get; set; }

        public Note(int index, DateTime date, string caption, string description, string author, string category)
        {
            Index = index;
            Date = date;
            Caption = caption;
            Description = description;
            Author = author;
            Category = category;
        }

        
    }
}
