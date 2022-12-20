﻿namespace aoc2022.day18.domain
{
    public readonly record struct Face (int lowerX, int upperX, int lowerY, int upperY, int lowerZ, int upperZ)
    {
        public static Face AddXYFace(int x, int y, int z)
        {
            return new(x, x + 1, y, y + 1, z, z);
        }

        public static Face AddXZFace(int x, int y, int z)
        {
            return new(x, x + 1, y, y, z, z + 1);
        }

        public static Face AddYZFace(int x, int y, int z)
        {
            return new(x, x, y, y + 1, z, z + 1);
        }
    }
}
