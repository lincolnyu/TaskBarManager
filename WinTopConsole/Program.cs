using System;
using System.Collections.Generic;
using System.Linq;
using WinTop;

namespace WinTopConsole
{
    class Program
    {
        static IEnumerable<Window> GetAllMainWindows()
            => Window.FindWindows().Where(x => x.IsMain).OrderBy(x => x.Text);

        static IEnumerable<Window> List(IEnumerable<Window> allwins, string start)
        {
            var wins = allwins.Where(w => w.Text.StartsWith(start, StringComparison.CurrentCultureIgnoreCase));
            foreach (var win in wins)
            {
                Console.WriteLine($"{win.Text}");
            }
            return wins;
        }

        static void LoadAllWindowsIfNot(ref IList<Window> allwins)
        {
            if (allwins == null)
            {
                allwins = GetAllMainWindows().ToList();
            }
        }

        static void Main(string[] args)
        {
            IList<Window> allwins = null;
            IList<Window> lastwins = new Window[0];
            var cont = true;
            while (cont)
            {
                Console.Write(">");
                var cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "tm":
                    case "topmost":
                    case "ntm":
                    case "notopmost":
                        {
                            LoadAllWindowsIfNot(ref allwins);
                            Console.Write("-");
                            var title = Console.ReadLine();
                            var wins = title == "~" ? lastwins : allwins.Where(x => x.Text.Equals(title, StringComparison.CurrentCultureIgnoreCase));
                            var tm = cmd == "tm" || cmd == "topmost";
                            foreach (var win in wins)
                            {
                                var r = tm? win.NailToTopmost() : win.RestoreFromTopmost();
                                if (tm)
                                {
                                    Console.Write($"Nailing {win.Text} to topmost ... ");
                                }
                                else
                                {
                                    Console.Write($"Take {win.Text} off from topmost ... ");
                                }
                                Console.WriteLine(r ? "succeeded" : "failed");
                            }
                        }
                        break;
                    case "l":
                    case "list":
                        {
                            LoadAllWindowsIfNot(ref allwins);
                            Console.Write("-");
                            var start = Console.ReadLine();
                            lastwins = List(allwins, start).ToList();
                        }
                        break;
                    case "q":
                    case "quit":
                        cont = false;
                        break;
                }
            }
        }
    }
}
