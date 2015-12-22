using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine.InputHandler;
using Engine.Models;
using Engine.Models.MobClasses;
using Engine.Models.PlayerClasses;

namespace Engine
{
    public class Engine
    {
        private const int framerate = 60;

        private static int lastTick;
        private static int lastFrameRate;
        private static int frameRate;

        private bool running = false;
        private Task thread;
        private Player player;
        private List<Mob> enemies;
        private List<BaseObject> objects;
        private Box finish;
        private System.Drawing.Graphics gfx;

        private long fpsStartTime;
        private long fpsFrameCount;
       
        public Engine()
        {
        }

        private void Init()
        {
            fpsStartTime = System.Diagnostics.Stopwatch.GetTimestamp();
            fpsFrameCount = 0;
            player = new Warrior(250,300);
            this.Input = new Input(this);

            this.enemies = new List<Mob>()
            {
               new Zombie(221,430,6),
               new Zombie(345,250,11),
               new Boss(400,400,10)
            };
            this.objects = new List<BaseObject>()
            {
               player,
               new Box(60,10),
               new Box(60,60),
               new Box(60,110),
               new Box(60,160),
               new Box(110,160),
               new Box(110,270),
               new Box(10,270),
               new Box(60,270),
            };
            foreach (var enemy in enemies)
            {
                objects.Add(enemy);
            }
            finish = new Box(10, 10);

            Running = true;
        }

        public void Tick()
        {
            if (player.box.IntersectsWith(finish.box))
            {
                this.running = false;
                this.Graphics.DrawImage(Image.FromFile("../../../resources/gamewon.png"), 0, 0, Constants.gWidth, Constants.gHeight);
            }
            player.Tick(objects);
            foreach (var enemy in enemies)
            {
                if (enemy.Intersects(player))
                {
                    this.running = false;
                    this.Graphics.DrawImage(Image.FromFile("../../../resources/gameover.png"), 0, 0 ,Constants.gWidth, Constants.gHeight);
                }
                enemy.SetTarget(player);
                enemy.Tick(objects);
            }
        }

        public void Render()
        {
            gfx.Clear(Color.Green);
            gfx.FillRectangle(Brushes.DeepSkyBlue, 5,5,50,50);
            foreach (var creature in objects)
            {
                creature.Render(this.Graphics);
            }
        }

        public void Run()
        {
            Init();

            while (running)
            {
                LimitFrameRate(framerate);
                Console.WriteLine(CalculateFrameRate());
                this.Render();
                this.Tick();
            }
            Stop();
        }

        public void Start()
        {
            if (!this.running)
            {
                this.running = true;
                thread = Task.Factory.StartNew(this.Run);
            }
        }

        public void Stop()
        {
            if (!this.running)
            {
                return;
            }
            this.running = false;
            try
            {
                this.Dispose();
                Application.Exit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Dispose()
        {
            this.gfx.Dispose();
            thread.Dispose();
        }

        public bool Running
        {
            get
            {
                return this.running;
            }
            set { this.running = value; }
        }

        public Player Player
        {
            get { return this.player; }
        }

        public Input Input{get; private set; }


        public System.Drawing.Graphics Graphics
        {
            get { return this.gfx; }
            set { this.gfx = value; }
        }

        //public Engine Instance
        //{
        //    get { return this.instance ?? (this.instance = new Engine()); }
        //}


        public virtual void LimitFrameRate(int fps)
        {
            var freq = System.Diagnostics.Stopwatch.Frequency;
            var frame = System.Diagnostics.Stopwatch.GetTimestamp();
            
            while ((frame - fpsStartTime) * fps < freq * fpsFrameCount)
            {
                int sleepTime = (int)((fpsStartTime * fps + freq * fpsFrameCount - frame * fps) * 1000 / (freq * fps));
                if (sleepTime > 0) System.Threading.Thread.Sleep(sleepTime);
                frame = System.Diagnostics.Stopwatch.GetTimestamp();
            }
            if (++fpsFrameCount > fps)
            {
                fpsFrameCount = 0;
                fpsStartTime = frame;
            }
        }
        public static int CalculateFrameRate()
        {
            if (System.Environment.TickCount - lastTick >= 1000)
            {
                Console.WriteLine(lastFrameRate);
                lastFrameRate = frameRate;
                frameRate = 0;
                lastTick = System.Environment.TickCount;
            }
            frameRate++;
            return lastFrameRate;
        }


    }
}
