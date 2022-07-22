namespace Telephony.Core
{
    using System;
    using Models.Interfaces;
    using IO.Interfaces;
    using Telephony.Models;

    public class Engine : IEngine
    {

        private readonly Smartphone smartphone;
        private readonly StationaryPhone stationaryPhone;
        private readonly IReader reader;
        private readonly IWriter writer;

        private Engine()
        {
            smartphone = new Smartphone();
            stationaryPhone = new StationaryPhone();
        }

        public Engine(IReader reader, IWriter writer)
            :this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] phoneNumbers = reader.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] urls = reader.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var number in phoneNumbers)
            {
                if (!ValidateNumber(number))
                {
                    writer.WriteLine("Invalid number!");
                }
                else if (number.Length == 7)
                {
                    writer.WriteLine(stationaryPhone.Call(number));
                }
                else if (number.Length == 10)
                {
                    writer.WriteLine(smartphone.Call(number));
                }
            }

            foreach (var url in urls)
            {
                if (!ValidateURL(url))
                {
                    writer.WriteLine("Invalid URL!");
                }
                else
                {
                    writer.WriteLine(smartphone.BrowseURL(url));
                }
            }
        }

        private static bool ValidateNumber(string number)
        {
            foreach (var ch in number)
            {
                if (!Char.IsDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }
        private static bool ValidateURL(string url)
        {
            foreach (var ch in url)
            {
                if (Char.IsDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
