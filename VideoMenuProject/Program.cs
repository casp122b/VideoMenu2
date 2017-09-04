using System;
using System.Collections.Generic;

namespace VideoMenuProject
{
    class Program
    {

        static List<Video> videos = new List<Video>();

        static int id = 1;
        static void Main(string[] args)
        {
            

            Video vid = new Video()
            {
                Id = id++,
                Name = "Sjove dyr"
            };

            videos.Add(vid);

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
                        AddVideo();
                        break;
                    case 2:
                        ReadVideos();
                        break;
                    case 3:
                        EditVideo();
                        break;
                    case 4:
                        DeleteVideo();
                        break;
                    default:
                        break;
                }
                selected = VideoMenu(videoMenuItems);
            }

            Console.WriteLine("Exiting ...");

            Console.ReadLine();

        }

        private static void EditVideo()
        {
            var video = FindVideoById();
            Console.WriteLine("Name: ");
            video.Name = Console.ReadLine();
        }

        public static Video FindVideoById()
        {
            Console.WriteLine("Type in video id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id) || id < 1)
            {
                Console.WriteLine("You did not type an id. Try again.");
            }

            foreach (var video in videos)
            {
                if (video.Id == id)
                {
                    return video;
                }
            }
            return null;
        }

        private static void DeleteVideo()
        {
            var videoFound = FindVideoById();
            if(videoFound != null)
            {
                videos.Remove(videoFound);
            }
        }

        private static void AddVideo()
        {
            Console.WriteLine("Enter name: ");
            var name = Console.ReadLine();

            videos.Add(new Video()
            {
                Id = id++,
                Name = name
            });
        }

        private static void ReadVideos()
        {
            Console.Clear();
            foreach (var video in videos)
            {
                Console.WriteLine($"Id: { video.Id } Name: { video.Name }");
            }
            Console.WriteLine("\n");
        }

        private static int VideoMenu(string[] videoMenuItems)
        {
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