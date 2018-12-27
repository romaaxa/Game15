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
        int[ , ] map;
        int coordx;
        int coordy;
        static Random rand = new Random();

        public Game (int size)
        {
            this.size = size;
            map = new int[size, size];
        }

        public void Start()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    map[x, y] = coordsin(x, y) + 1;
            coordx = size - 1;
            coordy = size - 1;
            map[coordx, coordy] = 0;
        }

        public void moving(int position)
        {
            int x, y;
            coordsout(position, out x, out y);
            if (Math.Abs(coordx - x) + Math.Abs(coordy - y) != 1) return;
            map[coordx, coordy] = map[x, y];
            map[x, y] = 0;
            coordx = x;
            coordy = y;
        }

        public void randmoving()
        {
            int a = rand.Next(0, 4);
            int x = coordx;
            int y = coordy;
            switch (a)
            {
                case 0: x--; break;
                case 1: x++; break;
                case 2: y--; break;
                case 3: y++; break;
            }
            moving(coordsin(x, y));
        }

        public bool gameres()
        {
            if (!(coordx == size - 1 && coordy == size - 1)) return false;
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    if (!(x == size - 1 && y == size - 1))
                        if (map[x, y] != coordsin(x, y) + 1) return false;
            return true;
        }

        public int numrecieve(int position)
        {
            int x, y;
            coordsout(position, out x, out y);
            if (x < 0 || x >= size) return 0;
            if (y < 0 || y >= size) return 0;
            return map[x, y];
        }

        private int coordsin(int x, int y)
        {
                if (x < 0) x = 0;
                if (x > size - 1) x = size - 1;
                if (y < 0) y = 0;
                if (y > size - 1) y = size - 1;
                return y * size + x;
        }

        private void coordsout(int position, out int x, out int y)
        {
            if (position < 0) position = 0;
            if (position > size * size - 1) position = size * size - 1;
            x = position % size;
            y = position / size;
        }
    }
}
