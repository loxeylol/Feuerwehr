using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Feuerwehr
{
    public class Feuerwache
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adresse { get; set; }
        public string Trivia { get; set; }
        public string Coords { get; set; }
        public int Strength { get; set; }
        //public Leitstelle Leitstelle {get; set;}
        public int InventarFk { get; set; }
        public string TelNr { get; set; }
        

        public override string ToString()
        {
            return this.Name;
        }

        public static List<Feuerwache> GetFireStationList()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DB_PATH))
            {


                return conn.Table<Feuerwache>().ToList();
              
            }
           
        }

        public static void getSingle(string welcheWache)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DB_PATH))
            {

                //Feuerwache wache = conn.Table<Feuerwache>().Where(conn.Table<Feuerwache>().Name == welcheWache);
               var dump = conn.Table<Feuerwache>().Where(p => p.Name == welcheWache);
                Console.WriteLine(dump + "welche Wache ist gewählt?");

            }
            
        }

        public static Inventar GetInventar(int pk)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DB_PATH))
            {

                return conn.Get<Inventar>(pk) as Inventar;

            }


        }
       
        

    }
}
