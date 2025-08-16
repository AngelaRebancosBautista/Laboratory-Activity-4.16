using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_Activity_16
{

    class Movie
    {
        public string Title;
        public string Rating;
        public int Duration;
        public List<string> Tags;
        public int Score()
        {
            if (Rating == "G") return 1;
            if (Rating == "PG") return 2;
            if (Rating == "PG-13") return 3;
            if (Rating == "R") return 4;
            if (Rating == "NC-17") return 5;
            return 0;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("How many movies? ");
            int n = int.Parse(Console.ReadLine());
            List<Movie> movies = new List<Movie>();

            for (int i = 0; i < n; i++)
            {
                Movie m = new Movie();
                Console.WriteLine("\nMovie #" + (i + 1));
                Console.Write("Title: ");
                m.Title = Console.ReadLine();
                Console.Write("Rating (G/PG/PG-13/R/NC-17): ");
                m.Rating = Console.ReadLine().ToUpper();
                Console.Write("Duration (min): ");
                m.Duration = int.Parse(Console.ReadLine());
                Console.Write("Tags (comma separated): ");
                m.Tags = new List<string>(Console.ReadLine().ToLower().Split(','));
                movies.Add(m);
            }

            Console.Write("\nMax duration: ");
            int maxDur = int.Parse(Console.ReadLine());
            Console.Write("Allowed ratings (comma separated): ");
            List<string> allowed = new List<string>(Console.ReadLine().ToUpper().Split(','));
            Console.Write("Mood tag: ");
            string mood = Console.ReadLine().ToLower();

            List<Movie> match = new List<Movie>();
            foreach (var m in movies)
            {
                if (m.Duration <= maxDur &&
                    allowed.Contains(m.Rating) &&
                    m.Tags.Contains(mood))
                {
                    match.Add(m);
                }
            }

            match.Sort((a, b) => b.Score().CompareTo(a.Score()));

            Console.WriteLine("Recommendations ");
            if (match.Count == 0)
                Console.WriteLine("No movies match.");
            else
            {
                foreach (var m in match)
                    Console.WriteLine($"{m.Title} | {m.Rating} | {m.Duration} min | tags: {string.Join("/", m.Tags)}");
                Console.WriteLine("\nBest pick: " + match[0].Title);
            }
        }
    }
}
            
    

