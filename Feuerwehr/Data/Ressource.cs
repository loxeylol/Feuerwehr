using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Feuerwehr
{
    public class Ressource
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Einsatztyp { get; set; }
        public string Einsatzgebiet { get; set; }
        public int InventarFk { get; set; }
        public string imageSource { get; set; }

    }
}
