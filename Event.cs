using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_07
{
    /// <summary>
    /// Событие
    /// </summary>
    class Event
    {
        /// <summary>
        /// Дата события
        /// </summary>
        DateTime Date { get; set; }
        
        /// <summary>
        /// Название события
        /// </summary>
        string Caption { get; set; }
        
        /// <summary>
        /// Описание события
        /// </summary>
        string Desctiption { get; set; }
        
        /// <summary>
        /// Автор события
        /// </summary>
        string Author { get; set; }
        
        /// <summary>
        /// Участники события
        /// </summary>
        string[] Partisipants { get; set; }
        
        /// <summary>
        /// Категория события
        /// </summary>
        string Category { get; set; }

        public Event(DateTime date, string caption, string desctiption, string author, string[] partisipants, string category)
        {
            Date = date;
            Caption = caption;
            Desctiption = desctiption;
            Author = author;
            Partisipants = partisipants;
            Category = category;
        }
    }
}
