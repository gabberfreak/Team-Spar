﻿using System.Drawing;

namespace Engine.Models.MobClasses
{
    public class Zombie : Mob
    {
        private const int baseStr = 6;
        private const int baseAgi = 1;
        private const int baseInt = 1;
        private const int baseSpeed = 5;
        private const int size = 50;

        public Zombie(int x, int y, int level) : base(x,y,baseStr,baseAgi,baseInt,level,baseSpeed, size)
        {
            this.Image = Image.FromFile("../../../resources/init.png");
        }
        public override Image Image { get; set; }
        public override void Render(System.Drawing.Graphics g)
        {
            g.FillRectangle(Brushes.Red, X, Y, 50, 50);
        }
    }
}
