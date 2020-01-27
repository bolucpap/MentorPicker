using System.Collections.Generic;
namespace MentorPickerWeb.Models
{
    public class Mentor
    {
        public string Name{get;set;}
        public int MenteeCount{get;set;}
        public List<Mentee> Mentees {get;}
        public List<int> BannedMentes {get;set;}
        public Mentor()
        {
            Mentees=new List<Mentee>();
        }
    }
}