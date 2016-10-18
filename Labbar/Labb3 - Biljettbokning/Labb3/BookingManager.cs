using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3
{
    public class BookingManager
    {
        public List<Event> CurrentEvents { get; set; }
        public List<Booking> BookedEvents { get; set; }

        public BookingManager()
        {
            CurrentEvents = new List<Event>();
            BookedEvents = new List<Booking>();
            CurrentEvents.Add(new Concert { Name = "Moody blues", Price = 50, Location = "The Globe" });
            CurrentEvents.Add(new Concert { Name = "The Grateful Dead", Price = 45, Location = "Friends Arena",});
            CurrentEvents.Add(new Film { Name = "12 Angry men", Price = 65, Location = "A Cinema",});
            CurrentEvents.Add(new Film { Name = "Another movie", Price = 205, Location = "Another cinema",});
            CurrentEvents.Add(new Festival { Name = "A music festival", Price = 55, Location = "Somewhere",});
        }

        public void ShowEvents()
        {
            CurrentConcerts();
            CurrentFilms();
            CurrentFestivals();
        }

        public void ShowConcerts()
        {
            ShowEventsList(CurrentConcerts());
        }

        private Concert[] CurrentConcerts()
        {
            Event[] tempEvents = CurrentEvents
                .Where(currentEvent => currentEvent.GetType().ToString() == "Labb3.Concert").ToArray();
            Concert[] concerts = new Concert[tempEvents.Length];

            for (int i = 0; i < tempEvents.Length; i++)
            {
                concerts[i] = (Concert)tempEvents[i];
            }
            return concerts;
        }

        public void AddConcert()
        {
            while (true)
            {
                Console.WriteLine("Choose a concert to book");
                int ConcertToBook;

                bool validInput = int.TryParse(Console.ReadLine(), out ConcertToBook);
                if (!validInput || ConcertToBook > CurrentConcerts().Length || ConcertToBook < 1)
                {
                    Console.WriteLine("No concert added.");
                    return;
                }

                BookedEvents.Add(new Booking {BookingHolder = Runtime.User, BookedEvent = CurrentConcerts()[ConcertToBook - 1] });

                Console.WriteLine("Concert added.");
                return;
            }
        }

        public void ShowFilms()
        {
            ShowEventsList(CurrentFilms());
        }

        private Film[] CurrentFilms()
        {
            Event[] tempEvents = CurrentEvents
                .Where(currentEvent => currentEvent.GetType().ToString() == "Labb3.Film").ToArray();
            Film[] films = new Film[tempEvents.Length];

            for (int i = 0; i < tempEvents.Length; i++)
            {
                films[i] = (Film)tempEvents[i];
            }
            return films;
        }

        public void AddFilm()
        {
            while (true)
            {
                Console.WriteLine("Choose a film to book");
                int FilmToBook;

                bool validInput = int.TryParse(Console.ReadLine(), out FilmToBook);
                if (!validInput || FilmToBook > CurrentFilms().Length || FilmToBook < 1)
                {
                    Console.WriteLine("No film added.");
                    return;
                }

                BookedEvents.Add(new Booking { BookingHolder = Runtime.User, BookedEvent = CurrentFilms()[FilmToBook - 1] });

                Console.WriteLine("film added.");
                return;
            }
        }

        public void ShowFestivals()
        {
            ShowEventsList(CurrentFestivals());
        }

        private Festival[] CurrentFestivals()
        {
            Event[] tempEvents = CurrentEvents
                .Where(currentEvent => currentEvent.GetType().ToString() == "Labb3.Festival").ToArray();
            Festival[] festivals = new Festival[tempEvents.Length];

            for (int i = 0; i < tempEvents.Length; i++)
            {
                festivals[i] = (Festival)tempEvents[i];
            }
            return festivals;
        }

        public void AddFestival()
        {
            while (true)
            {
                Console.WriteLine("Choose a festival to book");
                int FestivalToBook;

                bool validInput = int.TryParse(Console.ReadLine(), out FestivalToBook);
                if (!validInput || FestivalToBook > CurrentFestivals().Length || FestivalToBook < 1)
                {
                    Console.WriteLine("No festival added.");
                    return;
                }

                BookedEvents.Add(new Booking { BookingHolder = Runtime.User, BookedEvent = CurrentFestivals()[FestivalToBook - 1] });

                Console.WriteLine("festival added.");
                return;
            }
        }

        private void ShowEventsList(Event[] events)
        {
            for (int i = 0; i < events.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, events[i].Description());
            }
        }

        public void ShowBookings()
        {
            if (BookedEvents.Count != 0)
            {
                foreach (var bookedEvent in BookedEvents)
                {
                    Console.WriteLine(bookedEvent.Description());
                }
            }
            else Console.WriteLine("No bookings");
        }

    }
}