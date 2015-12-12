using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using Engine.InputHandler;
using Engine.Models;
using Engine.Models.MobClasses;
using Engine.Models.PlayerClasses;

namespace Engine
{
    public class Engine
    {
        private const int UPDATES_PER_SECOND = 30;
        private const int WAIT_TICKS = 1000 / UPDATES_PER_SECOND;
        private const int MAX_FRAMESKIP = 5;
        private static readonly DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private const int MAX_UPDATES_PER_SECOND = 60;
        private const int MIN_WAIT_TICKS = 1000 / MAX_UPDATES_PER_SECOND;

        //private Engine instance;
        private bool running = false;
        private Thread thread;
        private Player player;
        private List<Mob> enemies;
        private Graphics g;

        public Engine()
        {
        }

        private void Init()
        {
            player = new Warrior(100,280);
            //enemies = new List<Mob>()
            //{
            //    new Zombie(100,122,6),
            //};
            this.Input = new Input(player);
        }

        public void Tick()
        {
            player.Tick();
            //foreach (var enemy in enemies)
            //{
            //    enemy.SetTarget(Player);
            //    enemy.Tick();
            //}
        }

        public void Render()
        {
            //this.Graphics.Clear(Color.Black);
            player.Render(this.Graphics);
            //foreach (var enemy in enemies)
            //{
            //    enemy.Render(this.Graphics);
            //}
        }

        public void Run()
        {
            Init();
            long next_update = CurrentTimeMillis();
            int frames_skipped;
            long last_update = CurrentTimeMillis();

            while (running)
            {
                // Delay if needed
                while (CurrentTimeMillis() < last_update + MIN_WAIT_TICKS)
                {
                    Thread.Sleep(0);
                }
                last_update = CurrentTimeMillis();
                // Update game:
                frames_skipped = 0;
                while (CurrentTimeMillis() > next_update && frames_skipped < MAX_FRAMESKIP)
                {
                    // Update input, move objects, do collision detection...
                    // Schedule next update:
                    Tick();
                    next_update += WAIT_TICKS;
                    frames_skipped++;
                }
                Render();
            }
            Stop();
        }

        public void Start()
        {
            if (!this.running)
            {
                this.running = true;
                this.thread = new Thread(new ThreadStart(this.Run));
                thread.Start();
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
                thread.Abort();
                
            }
            catch (Exception e)
            {
                throw;
            }
            
        }

        public bool Running { get { return this.running; } }
        public Player Player
        {
            get { return this.player; }
        }

        public Input Input{get; private set; }


        public static long CurrentTimeMillis()
        {
            return (long) (DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }

        public Graphics Graphics
        {
            get { return this.g; }
            set { this.g = value; }
        }

        //public Engine Instance
        //{
        //    get { return this.instance ?? (this.instance = new Engine()); }
        //}



    }
}
