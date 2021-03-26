using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleList
{
    static class SearchEngine
    {
        static List<Article> articleList = new List<Article>();
        static List<Autor> autorList = new List<Autor>();

        public static int ArticleCount
        {
            get { return articleList.Count; }
        }
        public static int AutorCount
        {
            get { return autorList.Count; }
        }
        public static List<Autor> Autors
        {
            get { return autorList; }
        }
        public static List<Article> Articles
        {
            get { return articleList; }
        }
        public static void AddArticle(Article article)
        {
            if (articleList.Contains(article))
                Console.WriteLine($"Article {article.Title} already exists");
            else
                articleList.Add(article);
        }
        public static void AddAutor(Autor autor)
        {
            if (autorList.Contains(autor))
                Console.WriteLine($"Autor {autor.FullName} already exists");
            else
                autorList.Add(autor);
        }
        #region Filtrare
        public static List<Article> Filtrare(Autor autor)
        {
            List<Article> lista = new List<Article>();
            foreach (var article in articleList)
                if (article.Autor == autor)
                    lista.Add(article);
            return lista;
        }
        public static List<Article> Filtrare(Tag tag)
        {
            List<Article> lista = new List<Article>();
            foreach (var article in articleList)
                if (article.ContainsTag(tag))
                    lista.Add(article);
            return lista;
        }
        public static List<Article> Filtrare(DateTime date1,DateTime date2)
        {
            List<Article> lista = new List<Article>();
            foreach (var article in articleList)
                if (article.PublicationDate <= date2 && article.PublicationDate >= date1)
                    lista.Add(article);
            return lista;
        }
        public static List<Article> Filtrare(string[] keywords)
        {
            List<Article> lista = new List<Article>();
            foreach (var article in articleList)
                if (article.ContainsKeywords(keywords))
                    lista.Add(article);
            return lista;
        }
        #endregion
        #region Sortare
        public static List<Article> SortByDate()
        {
            List<Article> lista = new List<Article>(articleList.ToList());
            for(int i=0;i<lista.Count-1;i++)
                for(int j=i+1;j<lista.Count;j++)
                    if(lista[i].PublicationDate>lista[j].PublicationDate)//sort by oldest
                    {
                        Article aux = lista[i];
                        lista[i] = lista[j];
                        lista[j] = aux;
                    }
            return lista;
        }
        public static List<Article> SortByLikes()//ordine descrescatoare ar fi mai logic
        {
            List<Article> lista = new List<Article>(articleList.ToList());
            for (int i = 0; i < lista.Count - 1; i++)
                for (int j = i + 1; j < lista.Count; j++)
                    if (lista[i].Likes < lista[j].Likes)
                    {
                        Article aux = lista[i];
                        lista[i] = lista[j];
                        lista[j] = aux;
                    }
            return lista;
        }
        public static List<Article> SortByDislikes()//ordine descrescatoare ar fi mai logic
        {
            List<Article> lista = new List<Article>(articleList.ToList());
            for (int i = 0; i < lista.Count - 1; i++)
                for (int j = i + 1; j < lista.Count; j++)
                    if (lista[i].Dislikes < lista[j].Dislikes)
                    {
                        Article aux = lista[i];
                        lista[i] = lista[j];
                        lista[j] = aux;
                    }
            return lista;
        }
        public static List<Article> SortByAutorArticlesPublished()
        {
            List<Article> lista = new List<Article>(articleList.ToList());
            for (int i = 0; i < lista.Count - 1; i++)
                for (int j = i + 1; j < lista.Count; j++)
                    if (lista[i].Autors.TotalArticlesPublished() < lista[j].Autors.TotalArticlesPublished())
                    {
                        Article aux = lista[i];
                        lista[i] = lista[j];
                        lista[j] = aux;
                    }
            return lista;
        }
        public static List<Article> SortByTitle()//alfabetic
        {
            List<Article> lista = new List<Article>(articleList.ToList());
            for (int i = 0; i < lista.Count - 1; i++)
                for (int j = i + 1; j < lista.Count; j++)
                    if (lista[i].Title.CompareTo(lista[j].Title)>0)//aceasta instanta(lista[i]) urmeaza dupa parametrul dat(lista[j])
                    {
                        Article aux = lista[i];
                        lista[i] = lista[j];
                        lista[j] = aux;
                    }
            return lista;
        }
        #endregion
        #region Agregare
        public static void AutorsInfo()
        {
            foreach(var autor in Autor.Autors)
                Console.WriteLine($"{autor.FullName} published {autor.ArticlesPublished} articles");
        }
        public static int ArticlesPublished(DateTime date1,DateTime date2)
        {
            if (date1 > date2)
            { Console.WriteLine("Date1's value is higher than Date2(meaning date1 is the most recent)"); return 0; }
            int counter = 0;
            foreach (var article in articleList)
                if (article.PublicationDate > date2 && article.PublicationDate < date1)
                    counter++;
            return counter;
        }



        #endregion

    }
}
