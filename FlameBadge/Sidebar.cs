﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlameBadge
{
    class Sidebar
    {
        private static int left = 20 * 3 + 3;
        private static int top = 20 / 2;

        public static void announce(String msg, Boolean printKey = false)
        {
            int origRow = Console.CursorTop;
            int origCol = Console.CursorLeft;
            Console.SetCursorPosition(left, top);
            Console.Write(new String(' ', 30));
            Console.SetCursorPosition(left, top);
            Console.Write(msg);

            if (printKey)
                printControlKey();
            else
                clearControlKey();

            Console.SetCursorPosition(origCol, origRow);
        }

        public static void printControlKey()
        {
            int i = top + 2;
            Console.SetCursorPosition(left, i);
            Console.Write("8 - Move Up");
            i++;
            Console.SetCursorPosition(left, i);
            Console.Write("4 - Move Left");
            i++;
            Console.SetCursorPosition(left, i);
            Console.Write("6 - Move Right");
            i++;
            Console.SetCursorPosition(left, i);
            Console.Write("2 - Move Down");
            i++;
            Console.SetCursorPosition(left, i);
            Console.Write("7 - Move Up and Left");
            i++;
            Console.SetCursorPosition(left, i);
            Console.Write("9 - Move Up and Right");
            i++;
            Console.SetCursorPosition(left, i);
            Console.Write("1 - Move Down and Left");
            i++;
            Console.SetCursorPosition(left, i);
            Console.Write("3 - Move Down and Right");
            i++;
            Console.SetCursorPosition(left, i);
            Console.Write("Press the 's' key to save the game.");
            for (int j = 0; j < FlameBadge.player_units.Count; j++)
            {
                i++;
                Console.SetCursorPosition(left, i);
                Console.Write("{0}- level: {1}, health: {2}", FlameBadge.player_units[j].id, FlameBadge.player_units[j].level, FlameBadge.player_units[j].health);
            }
            for (int j = 0; j < FlameBadge.cpu_units.Count; j++)
            {
                i++;
                Console.SetCursorPosition(left, i);
                Console.Write("{0}- level: {1}, health: {2}", FlameBadge.cpu_units[j].id, FlameBadge.cpu_units[j].level, FlameBadge.cpu_units[j].health);
            }
        }

        public static void clearControlKey()
        {
            int i = top + 2;
            for (int j = i; j < i + 10; j++)
            {
                Console.SetCursorPosition(left, j);
                Console.Write(new String(' ', 24));
            }
        }
    }
}
