using System;

namespace api.Models
{
    public class RunningNo
    {
        public Guid Id { get; set; }
        public DateTime TodayDate { get; set; }
        public string Type { get; set; }
        public int referenceNo { get; set; }
    }
}