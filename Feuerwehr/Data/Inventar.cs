using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Feuerwehr
{
    public class Inventar
    {
       
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        //public Feuerwache FeuerWache { get; set; }
        


    }

  
}
