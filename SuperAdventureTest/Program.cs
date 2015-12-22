﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Graphics;

namespace SuperAdventureTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new SuperAdventure(new Engine.Engine());
            Application.Run(game);
        }
    }
}
