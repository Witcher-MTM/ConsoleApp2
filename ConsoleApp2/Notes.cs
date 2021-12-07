using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Notes
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }

        public override string ToString()
        {
            return String.Format("ID: {0} Title: {1} Body: {2} DateCreate: {3}", this.ID, this.Title, this.Body, this.CreationDate);
        }
    }
}
