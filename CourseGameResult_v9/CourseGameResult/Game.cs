using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseGameResult
{
    class Game
    {
        int size;
        int[,] map;
        int spacex;
        int spacey;
        static Random rand = new Random();

        public Game (int size)
        {
            if (size < 2) size = 2;
            if (size > 5) size = 5;
            this.size = size;
            map = new int[size, size];
        }

        public void Start()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    map[x, y] = crdintopos(x, y) + 1;
            spacex = size - 1;
            spacey = size - 1;
            map[spacex, spacey] = 0;
        }

        public void shift(int position)
        {
            int x, y;
            posintocrd(position, out x, out y);
            if (Math.Abs(spacex - x) + Math.Abs(spacey - y) != 1) return;
            map[spacex, spacey] = map[x, y];
            map[x, y] = 0;
            spacex = x;
            spacey = y;
        }

        public void shift_random()
        {
            int a = rand.Next(0, 4);
            int x = spacex;
            int y = spacey;
            switch (a)
            {
                case 0: x--; break;
                case 1: x++; break;
                case 2: y--; break;
                case 3: y++; break;
            }
            shift(crdintopos(x, y));
        }

        public bool check_game()
        {
            if (!(spacex == size - 1 && spacey == size - 1)) return false;
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    if (!(x == size - 1 && y == size - 1))
                        if (map[x, y] != crdintopos(x, y) + 1) return false;
            return true;
        }

        public int get_number(int position)
        {
            int x, y;
            posintocrd(position, out x, out y);
            if (x < 0 || x >= size) return 0;
            if (y < 0 || y >= size) return 0;
            return map[x, y];
        }

        private int crdintopos(int x, int y)
        {
                if (x < 0) x = 0;
                if (x > size - 1) x = size - 1;
                if (y < 0) y = 0;
                if (y > size - 1) y = size - 1;
                return y * size + x;
        }

        private void posintocrd(int position, out int x, out int y)
        {
            if (position < 0) position = 0;
            if (position > size * size - 1) position = size * size - 1;
            x = position % size;
            y = position / size;
        }
    }
}
