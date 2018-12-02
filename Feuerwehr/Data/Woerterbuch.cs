using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Feuerwehr.Data
{
    public class Woerterbuch
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string SituationGer { get; set; }
        public string SituationDk { get; set; }
        public string WordGer { get; set; }
        public string WordDk { get; set; }
        public string FormulierungGer { get; set; }
        public string FormulierungDk { get; set; }
    }
}
