using System;
using UnityEngine;

namespace SUtility
{
    public sealed class PCG_XSH_RR
    {
        public ulong state { get; private set; }
        private readonly ulong increment;

        public PCG_XSH_RR(ulong seed, ulong inc = 6364136223846793005)
        {
            state = 0uL;
            increment = inc | 1uL;
            NextInt();
            state += seed;
            NextInt();
        }

        public void Seed(ulong seed)
        {
            state = 0uL;
            NextInt();
            state += seed;
            NextInt();
        }

        public uint NextInt()
        {
            ulong oldState = state;
            state = oldState * increment + increment;
            uint xorshifted = (uint)(((oldState >> 18) ^ oldState) >> 27);
            int rot = (int)(oldState >> 59);
            return (xorshifted >> rot) | (xorshifted << ((-rot) & 31));
        }

        public double NextDouble()
        {
            return (double)NextInt() / uint.MaxValue;
        }
    }

    public static class Random
    {
        public static readonly PCG_XSH_RR rand = new PCG_XSH_RR((uint)(DateTime.Now.Millisecond));

        public static void Seed(ulong seed)
            => rand.Seed(seed);

        public static int Next()
            => (int)rand.NextInt();

        public static float Nextf()
            => (float)rand.NextDouble();

        public static int Range(int min, int max)
            => (int)(rand.NextInt() % (max - min)) + min;

        public static float Range(float min, float max)
            => (float)(min + (max - min) * rand.NextDouble());

        public static float Range(Vector2 range)
            => Range(range.x, range.y);

        public static Vector3 Range(Vector3 max, Vector3 min)
        {
            var x = Range(max.x, min.x);
            var y = Range(max.y, min.y);
            var z = Range(max.z, min.z);
            return new Vector3(x, y, z);
        }
    }
}
