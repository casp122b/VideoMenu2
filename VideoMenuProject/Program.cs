using System;

namespace VideoMenuProject
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] videoMenuItems =
            {
                "Create video",
                "Read video",
                "Update video",
                "Delete video"
            };

            int selected = VideoMenu(videoMenuItems);

            while (selected != 5)
            {
                switch (selected)
                {
                    case 1:
                        Console.WriteLine("Create video");
                        break;
                    case 2:
                        Console.WriteLine("Read video");
                        break;
                    case 3:
                        Console.WriteLine("Update video");
                        break;
                    case 4:
                        Console.WriteLine("Delete video");
                        break;
                    default:
                        //Console.WriteLine("Exiting ...");
                        break;
                }
                selected = VideoMenu(videoMenuItems);
            }

            Console.WriteLine("Exiting ...");

            Console.ReadLine();

        }

        private static int VideoMenu(string[] videoMenuItems)
        {
            //Console.Clear();

            Console.WriteLine("Select an option: ");

            for (int i = 0; i < videoMenuItems.Length; i++)
            {
                Console.WriteLine((i + 1) + ":" + videoMenuItems[i]);
            }

            int select;
            while (!int.TryParse(Console.ReadLine(), out select) || select < 1 || select > 5)
            {
                Console.WriteLine("Select a number between 1-5");
            }

            return select;
        }
    }
}