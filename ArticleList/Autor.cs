using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleList
{
    public class Autor
    {
        static List<Autor> autorList = new List<Autor>();
        uint articlesPublished;
        public Autor() { autorList.Add(this); }
        public Autor(string name, string surname,DateTime dateOfBirth)
        {
            articlesPublished = 0;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            autorList.Add(this);
        }
        public Autor(string name,string surname)
        {
            articlesPublished = 0;
            Name = name;
            Surname = surname;
            autorList.Add(this);
        }
        public Autor(string name)
        {
            articlesPublished = 0;
            Name = name;
            autorList.Add(this);
        }
        ~Autor() { autorList.Remove(this); }


        public static List<Autor> Autors
        {
            get { return autorList; }
        }
        public string FullName
        {
            get 
            {
                if (Surname != null && Surname != "")
                    return Name + " " + Surname;
                else
                    return Name;
            }
        }
        public string Surname
        { get; set; }
        public string Name
        { get; set; }
        public DateTime DateOfBirth
        { get; set; }
        public uint ArticlesPublished
        { get { return articlesPublished; } }




        
        public void ArticleAdded()
        { articlesPublished++; }
        public void ArticleRemoved()
        { articlesPublished--; }
    }
    public static class AutorExtensionMethods
    {
        public static uint TotalArticlesPublished(this Autor[] autors)
        {
            uint sum = 0;
            foreach (var autor in autors)
                sum += autor.ArticlesPublished;
            return sum;
        }
    }
}
