using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Feuerwehr
{
    class Leitstelle
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Adresse { get; set; }
        public string Coords { get; set; }
        public string TelNr { get; set; }

    }
}
