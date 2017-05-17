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

        static IEnumerable<Window> List(IEnumerable<Window> allwins, Func<Window, bool> pred)
        {
            var wins = allwins.Where(pred);
            foreach (var win in wins)
            {
                Console.WriteLine($"{win.Id,10} {win.Text}  " + (win.IsTopMost ? "[T]" : string.Empty));
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

        static void ResetAllWindows(ref IList<Window> allwins)
        {
            allwins = null;
            Window.ResetIdGenerator();
        }

        static void Main(string[] args)
        {
            IList<Window> allwins = null;
            IList<Window> lastwins = new Window[0];
            var cont = true;
            while (cont)
            {
                Console.Write(">");
                var cmd = Console.ReadLine().Trim().ToLower();
                switch (cmd)
                {
                    case "a":
                    case "activate":
                    case "tm":
                    case "topmost":
                    case "ntm":
                    case "notopmost":
                        {
                            var act = cmd == "a" || cmd == "activate";
                            var tm = cmd == "tm" || cmd == "topmost";
                            LoadAllWindowsIfNot(ref allwins);
                            Console.Write("-");
                            var title = Console.ReadLine();
                            IEnumerable<Window> wins;
                            if (title == "*" && !tm && !act)
                            {
                                wins = allwins;
                            }
                            else if (title == "~")
                            {
                                wins = lastwins;
                            }
                            else
                            {
                                wins = allwins.Where(x => x.Text.Equals(title, StringComparison.CurrentCultureIgnoreCase));
                            }
                            foreach (var win in wins)
                            {
                                bool r;
                                if (act)
                                {
                                    r = win.BringToTop();
                                    Console.Write($"Bring '{win.Text}' to front ... ");
                                }
                                else if (tm == win.IsTopMost)
                                {
                                    continue;
                                }
                                else
                                {
                                    r = tm ? win.NailToTopmost() : win.RestoreFromTopmost();
                                    if (tm)
                                    {
                                        Console.Write($"Nailing '{win.Text}' to topmost ... ");
                                    }
                                    else
                                    {
                                        Console.Write($"Take '{win.Text}' off from topmost ... ");
                                    }
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
                            lastwins = List(allwins, w=>w.Text.StartsWith(start, StringComparison.CurrentCultureIgnoreCase)).ToList();
                        }
                        break;
                    case "ltm":
                        {
                            LoadAllWindowsIfNot(ref allwins);
                            lastwins = List(allwins, w=>w.IsTopMost).ToList();
                        }
                        break;
                    case "reset":
                        {
                            ResetAllWindows(ref allwins);
                        }
                        break;
                    case "q":
                    case "quit":
                        cont = false;
                        break;
                    case "":
                        break;
                    default:
                        Console.WriteLine("Unrecognized command");
                        break;
                }
            }
        }
    }
}
