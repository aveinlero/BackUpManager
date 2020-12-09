using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackUpManager
{
    [Serializable]
    public struct CopyByPeriod
    {
        public bool Status { get; set; }
        public int Period { get; set; }
        public DateTime Time { get; set; }
        public DateTime DateNextUpdate { get; private set; }
        
        public CopyByPeriod(bool status, int period, DateTime time)
        {
            this.Status = status;
            this.Period = period;
            
            int hours = time.Hour;
            int minutes = time.Minute;
            int seconds = time.Second;
            this.Time = DateTime.Now.Date.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds);
            if (this.Time > DateTime.Now) { this.DateNextUpdate = Time; }
            else { this.DateNextUpdate = Time.AddDays(period); }
        }

        public CopyByPeriod(CopyByPeriod value)
        {
            this.Status = value.Status;
            this.Period = value.Period;
            this.Time = value.Time;
            this.DateNextUpdate = value.DateNextUpdate;
        }

        public void SetDateNextUpdate()
        {
            if (this.Time > DateTime.Now) { this.DateNextUpdate = Time; }
            else { this.DateNextUpdate = Time.AddDays(Period); }
        }

    }
}
