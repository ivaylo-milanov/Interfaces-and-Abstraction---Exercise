using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<Soldier> soldiers;

        public Engine()
        {
            this.soldiers = new List<Soldier>();
        }

        public void Run()
        {
            Soldier soldier = null;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] tokens = input.Split();

                string type = tokens[0];
                int id = int.Parse(tokens[1]);
                string firstName = tokens[2];
                string lastName = tokens[3];
                string forthParam = tokens[4];

                if (type == "Private")
                {
                    decimal salary = decimal.Parse(forthParam);
                    soldier = new Private(id, firstName, lastName, salary);
                }
                else if (type == "LieutenantGeneral")
                {
                    var dictionary = new Dictionary<int, IPrivate>();

                    for (int i = 5; i < tokens.Length; i++)
                    {
                        int curId = int.Parse(tokens[i]);
                        IPrivate curPrivate = (IPrivate)
                            soldiers.First(x => x.ID == curId);
                        
                        dictionary[curId] = curPrivate;
                    }

                    decimal salary = decimal.Parse(forthParam);
                    soldier = new LieutenantGeneral
                        (id, firstName, lastName, salary, dictionary);
                }
                else if (type == "Engineer")
                {
                    decimal salary = decimal.Parse(forthParam);

                    if (tokens[5] != "Airforces" && tokens[5] != "Marines")
                    {
                        continue;
                    }

                    Corps corps = (Corps)Enum.Parse(typeof(Corps), tokens[5]);

                    var repairs = new List<IRepair>();

                    for (int i = 6; i < tokens.Length; i += 2)
                    {
                        string partName = tokens[i];
                        int workedHours = int.Parse(tokens[i + 1]);

                        IRepair repair = new Repair(partName, workedHours);

                        repairs.Add(repair);
                    }

                    soldier = new Engineer
                        (id, firstName, lastName, salary, corps, repairs);
                }
                else if (type == "Commando")
                {
                    decimal salary = decimal.Parse(forthParam);
                    State state;

                    if (tokens[5] != "Airforces" && tokens[5] != "Marines")
                    {
                        continue;
                    }

                    Corps corps = (Corps)Enum.Parse(typeof(Corps), tokens[5]);

                    var missions = new List<IMission>();

                    for (int i = 6; i < tokens.Length; i += 2)
                    {
                        string partName = tokens[i];

                        if (tokens[i + 1] != "Finished" &&
                            tokens[i + 1] != "inProgress")
                        {
                            continue;
                        }

                        state = (State)Enum.Parse(typeof(State), tokens[i + 1]);

                        IMission mission = new Mission(partName, state);

                        missions.Add(mission);
                    }

                    soldier = new Commando
                        (id, firstName, lastName, salary, corps, missions);
                }
                else if (type == "Spy")
                {
                    int codeNumber = int.Parse(forthParam);

                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }

                soldiers.Add(soldier);
            }

            foreach (var item in soldiers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
