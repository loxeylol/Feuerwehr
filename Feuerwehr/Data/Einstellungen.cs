using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Feuerwehr.Data
{
    public class Einstellungen
    {

        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Language { get; set; }
        public int FontSize { get; set; }
        public string Help { get; set; }
    }
}
