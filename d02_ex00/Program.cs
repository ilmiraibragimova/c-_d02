using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using d02_ex00.Models;

namespace d02_ex00
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input search text:");
            string str = Console.ReadLine();
            List<ISearchable> media = new List<ISearchable>();
            createBooks(media);
            createMovie(media);
            IEnumerable<ISearchable> mediaSelected = search(media, str);
            printMedia(mediaSelected, str);
        }
        static void createBooks(List<ISearchable> books)
        {
            var json = File.ReadAllText(
                    "/Users/ilmira/Desktop/git_c#/d02/d02_ex00/ex00 example files/book_reviews.json");
            JsonDocument doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;
            var booksJsonElement = root.GetProperty("results");
            var booksArrayEnumerator = booksJsonElement.EnumerateArray();
            while (booksArrayEnumerator.MoveNext())
            { 
                var bookJsonElement = booksArrayEnumerator.Current.ToString();
                Book book = JsonSerializer.Deserialize<Book>(bookJsonElement);
                JsonDocument doc1 = JsonDocument.Parse(bookJsonElement);
                JsonElement root1 = doc1.RootElement;
                var a = root1.GetProperty("book_details");
                JsonDocument doc2 = JsonDocument.Parse(a.ToString());
                JsonElement root2 = doc2.RootElement;
                var a1 = root2[0];
                book.Title = root2[0].GetProperty("title").ToString();
                book.Author = root2[0].GetProperty("author").ToString();
                book.SummaryShort = root2[0].GetProperty("description").ToString();
                book.TypeMedia = "Book";
                books.Add(book);
            }
        }
        static void createMovie(List<ISearchable> movies)
        {
            var json = File.ReadAllText(
                "/Users/ilmira/Desktop/git_c#/d02/d02_ex00/ex00 example files/movie_reviews.json");
            JsonDocument doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;
            var booksJsonElement = root.GetProperty("results");
            var booksArrayEnumerator = booksJsonElement.EnumerateArray();
            while (booksArrayEnumerator.MoveNext())
            {
                var bookJsonElement = booksArrayEnumerator.Current.ToString();
                Movie movie = JsonSerializer.Deserialize<Movie>(bookJsonElement);
                JsonDocument doc1 = JsonDocument.Parse(bookJsonElement);
                JsonElement root1 = doc1.RootElement;
                var a = root1.GetProperty("link");
                JsonDocument doc2 = JsonDocument.Parse(a.ToString());
                JsonElement root2 = doc2.RootElement;
                movie.Url = root2.GetProperty("url").ToString();
                movie.TypeMedia = "Movie";
                movies.Add(movie);
            }
        }
        static IEnumerable<ISearchable> search(List<ISearchable> obj, string str)
        {
            var objSelected = from b in obj
                where b.Title.IndexOf(str, StringComparison.OrdinalIgnoreCase) > -1
                select b;
            return objSelected;
        }
        static void printMedia(IEnumerable<ISearchable> mediaSelected, string str)
        { 
            if (mediaSelected.Count() == 0)
            {
                Console.WriteLine("There are no \"" + str + "\" in media today.");
                return;
            }
            Console.WriteLine("\nItems found: " + mediaSelected.Count());
            var objGrouped = from b in mediaSelected
            group b by b.TypeMedia;
           
            foreach (var group in objGrouped)
            {
                Console.WriteLine("\n" + group.Key +" search result [" + group.Count() + "]:");
                foreach(var media in group)
                {
                    Console.WriteLine(media);
                }
            }
            
        }
    }
}
