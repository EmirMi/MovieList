using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArrayMovie
{
    class Program
    {
        private static bool dataLoaded = false;
        public static void Main(string[] args)
        {
            Movie[] objMovies = new Movie[1];
            int choice;

            do
            {
                Console.WriteLine("1. Load data");
                Console.WriteLine("2. Display all movies");
                Console.WriteLine("3. Add a movie");
                Console.WriteLine("4. Exit");
                Console.Write("Make a choice from 1-4: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        LoadData(ref objMovies);
                        break;
                    case 2:
                        DisplayAllMovies(objMovies);
                        break;
                    case 3:
                        AddMovie(ref objMovies);
                        break;
                    default:
                        break;
                }

                Console.Clear();

            } while (choice != 4);

           
        }

        public static void LoadData(ref Movie[] objMovies)
        {
            StreamReader reader = new StreamReader("Movies.txt");
            int size = Convert.ToInt32(reader.ReadLine());
            objMovies = new Movie[size];

            for(int i = 0; i < objMovies.Length; i++)
            {
                objMovies[i] = new Movie();
                objMovies[i].Title = reader.ReadLine();
                objMovies[i].Director = reader.ReadLine();
                objMovies[i].Year = Convert.ToInt32(reader.ReadLine());
            }
            dataLoaded = true;
            reader.Close();
            Console.WriteLine("Data has been loaded. Press any key to continue...");
            Console.ReadKey();
        }

        public static void DisplayAllMovies(Movie[] objMovies)
        {
            if (dataLoaded == true)
                {
                Console.Clear();
                for (int i = 0; i < objMovies.Length; i++)
                {
                    objMovies[i].DisplayInformation();
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Data has not been loaded. Please load the data first.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        public static void AddMovie(ref Movie[] objMovies)
        {
            Console.Clear();
            StreamWriter write = new StreamWriter("Movies.txt");
            write.WriteLine(objMovies.Length + 1);

            //creating new object
            Movie temp = new Movie();

            //get data from user
            Console.Write("Enter title: ");
            temp.Title = Console.ReadLine();
            Console.Write("Enter director: ");
            temp.Director = Console.ReadLine();
            Console.Write("Enter year: ");
            temp.Year = Convert.ToInt32(Console.ReadLine());

            //writint to our text file
            write.WriteLine(temp.Title);
            write.WriteLine(temp.Director);
            write.WriteLine(temp.Year);

            //put old data back to text file
            for (int i = 0; i < objMovies.Length; i++)
            {
                write.WriteLine(objMovies[i].Title);
                write.WriteLine(objMovies[i].Director);
                write.WriteLine(objMovies[i].Year);
            }

            //close the file
            write.Close();

            //update the array
            LoadData(ref objMovies);
        }
    }
}
