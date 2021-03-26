using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleList
{
    class Article
    {
        string title, text;
        Autor[] autors;
        uint likes, dislikes;
        List<Tag> tags;
        DateTime publicationDate, lastModified;
        public Article()
        {
            tags = new List<Tag>();
            autors = new Autor[1];
            autors[0].Name = "unknown";
            likes = 0; dislikes = 0;
        }
        public Article(Autor[] autors,string title,string text)
        {
            tags = new List<Tag>();
            this.autors = autors;
            Title = title;
            Text = text;
            likes = 0; dislikes = 0;
            publicationDate = DateTime.Now;
            lastModified = DateTime.Now;
        }
        #region Properties
        public uint Likes
        { get { return likes; } }
        public uint Dislikes
        { get { return dislikes; } }
        public Autor[] Autors
        {
            get { return autors; }
            set { if (autors[0].Name == "unknown") autors=value; }//se va pune un new Autor(...) daca inca este anonim
        }
        public string Title
        {
            get { return title; }
            set { lastModified = DateTime.Now;title = value; } 
        }
        public string Text
        {
            get { return text; }
            set { lastModified = DateTime.Now;text = value; } 
        }
        public List<Tag> Tags
        {
            get { return tags; }
        }
        public DateTime PublicationDate
        { get { return publicationDate; } }
        #endregion

        #region Methods
        public void Liked()//methods used for the User
        { likes++; }
        public void Disliked()
        { dislikes++; }
        public void LikeCancelled()
        { likes--; }
        public void DislikeCancelled()
        { dislikes--; }
        public void AddTag(Tag tag)
        {
            if(tags.Contains(tag))
                Console.WriteLine($"Tag {tag.Text} already exists.");
            else
            tags.Add(tag);
        }
        public void RemoveTag(Tag tag)
        { tags.Remove(tag); }
        public bool ContainsTag(Tag tag)
        { return tags.Contains(tag); }

        internal bool ContainsKeywords(string[] keywords)
        {
            foreach (var keyword in keywords)
                if (title.Contains(keyword) || text.Contains(keyword))
                    return true;
            return false;
        }
        #endregion
    }
}
