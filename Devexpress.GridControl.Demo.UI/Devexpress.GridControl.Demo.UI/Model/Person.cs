using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devexpress.GridControl.Demo.UI.Model
{
    public class Person
    {
        private string _fullName;
        private long _incomePerMonth;

        public bool IsSelected { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName 
        {
            get => FirstName + LastName;
            set
            {
                _fullName = value;
            }
        }
        public string NickName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Occupation { get; set; }
        public string Address { get; set; }
        public string CurrentOrganisation { get; set; }
        public long IncomePerYear { get; set; }
        public long IncomePerMonth 
        { 
            get => IncomePerYear/12; 
            set
            {
                _incomePerMonth = value;
            }
        }


    }
}
