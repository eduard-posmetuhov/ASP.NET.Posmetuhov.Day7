using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinSearch.Test
{
    class Book : IComparable<Book>
    {     
        public int Page { get; set; }
        public int Year { get; set; }

        public Book(int page,int year)
        {
            Page=page;
            Year=year;
        }           

        public int CompareTo(Book other)
        {
            if (ReferenceEquals(other,null))
                return 1;
            if (this.Page>other.Page)
                return 1;
            if (this.Page<other.Page)
                return -1;
            return 0;

        }            
        
    }
}
