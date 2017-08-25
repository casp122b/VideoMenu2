using System;
using System.Collections.Generic;
using VideoAppBLL;
using VideoAppEntity;

namespace VideoAppUI
{
    class Program
    {
        static BLLFacade bllFacade = new BLLFacade(); 
        static void Main(string[] args)
        {


            Video vid = new Video()
            {
                Name = "Sjove dyr"
            };

            bllFacade.VideoService.Create(vid);

            bllFacade.VideoService.Create(new Video()
            {
                Name = "Sjove kartofler"
            });

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
            if (video != null)
            {
                Console.WriteLine("Name: ");
                video.Name = Console.ReadLine();
                bllFacade.VideoService.Update(id);
            }
            else
            {
                Console.WriteLine("Video not found!");
            }
            
        }

        public static Video FindVideoById()
        {
            Console.WriteLine("Type in video id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id) || id < 1)
            {
                Console.WriteLine("You did not type an id. Try again.");
            }

            return bllFacade.VideoService.Get(id);
        }

        private static void DeleteVideo()
        {
            var videoFound = FindVideoById();
            bllFacade.VideoService.Delete(videoFound.Id);
            var response = videoFound == null ?
                "Video not found!" :
                "The video was deleted!";
            Console.WriteLine(response);
        }

        private static void AddVideo()
        {
            Console.WriteLine("Enter name: ");
            var name = Console.ReadLine();

            bllFacade.VideoService.Create(new Video()
            {
                Name = name
            });
        }

        private static void ReadVideos()
        {
            Console.Clear();
            foreach (var video in bllFacade.VideoService.GetAll())
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