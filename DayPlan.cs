using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_07
{
    /// <summary>
    /// План на день
    /// </summary>
    class DayPlan
    {
        /// <summary>
        /// События дня
        /// </summary>
        DayEvent[] dayEvents;
        
        /// <summary>
        /// Дата 
        /// </summary>
        DateTime Date { get; set; }
        
        /// <summary>
        /// Примечание
        /// </summary>
        string Notification { get; set; }
        
        /// <summary>
        /// Категория события
        /// </summary>
        string Category { get; set; }
    }
}
