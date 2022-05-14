using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid_training
{
    // most bad scenario
    internal class Step1
    {
        public Step1()
        {
            Console.WriteLine("-----Step1-----");

            Force t80 = new Force() { Type = ForceType.Tank };
            t80.Setup();
            t80.Move(10, 20, 30);

            Force readTeam = new Force() { Type = ForceType.Infantry };
            readTeam.Setup();
            readTeam.Move(10, 20, 30);
        }

        class Force
        {
            public ForceType Type { get; set; }
            public void Setup()
            {
                // Some setup operations
            }
            public void Move(int x, int y, int z)
            {
                switch (Type)
                {
                    case ForceType.Tank:
                        // do something
                        break;
                    case ForceType.Infantry:
                        // do something
                        break;
                    case ForceType.Artillery:
                        // do something
                        break;
                    default:
                        break;
                }

                var routeInfo = $"{Type} to {x} {y} {z}";
                Console.WriteLine(routeInfo);
                File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "route1.txt"), routeInfo + "\n");
            }
        }

        enum ForceType
        {
            Tank,
            Infantry,
            Artillery
        }
    }
}
