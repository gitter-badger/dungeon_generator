﻿using System;

namespace DungeonGenerator.Navigation
{
    public interface ITileMap
    {
        ushort this[int x, int y] { get; set; }

        int Height { get; }
        int Width { get; }
    }

    public struct Room
    {
        public int X;
        public int Y;

        public int Width;
        public int Height;


        public Point GetCenterWallPoint(Direction direction)
        {
            int x = X;
            int y = Y;
            switch (direction)
            {
                case Direction.N:
                    x += Width/2;
                    break;
                case Direction.E:
                    y += Height/2;
                    x += Width;
                    break;
                case Direction.S:
                    y += Height;
                    x += Width/2;
                    break;
                case Direction.W:
                    y += Height/2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("direction");
            }

            return new Point
            {
                Direction = direction, 
                X = x,
                Y = y,
            };
        }
    }


    public struct Item
    {
        public Point Location;
        public byte Type;

        public static Item Entrance = new Item { Type = 0x00 };
        public static Item Exit = new Item { Type = 0x01 };
        public static Item BossSpawn = new Item { Type = 0x02 };
        public static Item LootSpawn = new Item { Type = 0x03 };
    }
    
}