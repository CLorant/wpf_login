using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTelefonszam
{
    public partial class Felhasznalo
    {
        public string Email { get; set; }
        public string Telefonszam { get; set; }

        public Felhasznalo(string email, string telefonszam)
        {
            Email = email;
            Telefonszam = telefonszam;
        }

        public static List<Felhasznalo> felhasznaloLista = new List<Felhasznalo> {
            new Felhasznalo("asd@gmail.com","06-20-6942069"),
            new Felhasznalo("zolika@gmail.com","06-40-7457843"),
            new Felhasznalo("sanyi@gmail.com","06-40-9876543"),
            new Felhasznalo("thomaszider@gmail.com","06-30-1234567"),
            new Felhasznalo("damn@gmail.com","06-30-0123456"),
        };
    }
}
