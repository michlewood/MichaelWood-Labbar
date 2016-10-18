using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3
{
    public class Runtime
    {
        BookingManager bm = new BookingManager();
        public static string User { get; set; }

        public void Start()
        {
            Console.WriteLine("Enter name of user: ");
            User = Console.ReadLine();

            MainMenu();
            
        }

        private void MainMenu()
        {
            while (true)
            {
                Menus.MainMenu();

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        bm.ShowBookings();
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        AddBookingMenu();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        return;

                    default:
                        break;
                }
            }
        }

        private void AddBookingMenu()
        {
            Menus.AddBookingMenu();

            var input = Console.ReadKey(true).Key;

            switch (input)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    NewConcertBooking();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    NewFilmBooking();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    NewFestivalBooking();
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    return;

                default:
                    break;
            }
        }

        private void NewConcertBooking()
        {
            Console.Clear();
            bm.ShowConcerts();
            bm.AddConcert();
            Console.ReadLine();
        }

        private void NewFilmBooking()
        {
            Console.Clear();
            bm.ShowFilms();
            bm.AddFilm();
            Console.ReadLine();
        }

        private void NewFestivalBooking()
        {
            Console.Clear();
            bm.ShowFestivals();
            bm.AddFestival();
            Console.ReadLine();
        }
    }
}