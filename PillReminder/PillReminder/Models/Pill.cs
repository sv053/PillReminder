using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using SQLite;
using SQLitePCL;

namespace PillReminder.Models
{
    enum PilUnits
    {
        unit,
        gr,
        ml,
        mkg,

    }

    enum PillsTakingDays
    {
        once,
        everyday,
        daysOfWeek
    } 
    [Table ("Pills")]
   public class Pill  : Item
    {
       
       new public string Name { get; set; }
        [Ignore]
        public string Unit { get; set; }
        [Ignore]
      new  public string Text { get; set; }
      new  public string Description { get; set; }
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [Ignore]
        public DateTime StartDate { get; set; } = DateTime.Today;
        [Ignore]
        public DateTime EndDate { get; set; }
        public DateTime Date { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public string Time { get; set; }
        public TimeSpan TimeToTakePill { get; set; }
       //     public DateTime TimeToTakePill { get; set; }
        public bool toRemind { get; set; } = true;
        
        [Ignore]
        public int PillsTakingTerm { get; set; } = 7; // длительность приёма лекарств в днях, по умолчанию - неделя
        [Ignore]
        public List<DateTime> timeOfDay { get; set; } // в какое время дня приёмы лекарств
        [Ignore]
        public int TimesPerDay { get; set; } // сколько раз в день приём
        [Ignore]
        public List<string> WeekTimes { get; set; } // если приём по некоторым дням недели

    }

    public class PillsList
    {
        public ObservableCollection<Pill> Pills = new ObservableCollection<Pill>()
        {
            new Pill(){Name = "Ремантадин", Text = "после обеда", Id = 1},
            new Pill(){Name = "Парацетамол", Text = "на голодный желудок", Id = 2},
            new Pill(){Name = "Аспирин", Text = "через час после еды", Id = 3},
            new Pill(){Name = "Пустырник", Text = "за полчаса до еды", Id = 4},
            new Pill(){Name = "Ибупрофен", Text = "хоть когда", Id = 5},
        };
    }
    
}
