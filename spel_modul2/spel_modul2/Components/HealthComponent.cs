﻿namespace GameEngine
{
    class HealthComponent : IComponent
    {
        public bool IsAlive { get; set; } = true;
        public int Max { get; set; }
        public int Current { get; set; }
    }
}
