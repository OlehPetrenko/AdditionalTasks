using System;
using System.Collections.Generic;

namespace Task3
{
    internal class Graph
    {
        private int _objCount;
        private int _linkCount;

        public int Count
        {
            get { return _objCount; }
        }

        public int[,] Array { get; private set; }


        public Graph(int objCount, int linkCount)
        {
            if (linkCount > (objCount*(objCount - 1))/2)
            {
                throw new ArgumentException("objCount exceeds the allowable size!");
            }

            _objCount = objCount;
            _linkCount = linkCount;

            Array = new int[_objCount, _objCount];

            FillArray();
        }

        private void FillArray()
        {
            var rnd = new Random((int) DateTime.Now.Ticks);

            for (var i = 0; i < _objCount; i++)
            {
                for (var j = i + 1; j < _objCount; j++)
                {
                    if (_linkCount-- > 0)
                    {
                        Array[i, j] = rnd.Next(0, 2);
                    }

                    Array[j, i] = Array[i, j];
                }
            }
        }

        public bool IsConnected()
        {
            var neighbors = new Queue<int>();
            var connectedComponent = 0;

            neighbors.Enqueue(0);

            while (neighbors.Count != 0)
            {
                var index = neighbors.Dequeue();

                connectedComponent++;

                for (var i = index + 1; i < _objCount; i++)
                {
                    if (Array[index, i] == 1 && !neighbors.Contains(i))
                    {
                        neighbors.Enqueue(i);
                    }
                }
            }

            return connectedComponent == _objCount;
        }

        public bool HasCycles()
        {
            for (var startObj = 0; startObj < _objCount; startObj++)
            {
                var neighborsStartObj = new Queue<int>();

                for (var i = startObj + 1; i < _objCount; i++)
                {
                    if (Array[startObj, i] == 1)
                    {
                        neighborsStartObj.Enqueue(i);
                    }
                }

                if (neighborsStartObj.Count < 2)
                {
                    return false;
                }

                while (neighborsStartObj.Count != 0)
                {
                    var neighbors = new Queue<int>();

                    neighbors.Enqueue(neighborsStartObj.Dequeue());

                    while (neighbors.Count != 0)
                    {
                        var index = neighbors.Dequeue();

                        for (var i = index + 1; i < _objCount; i++)
                        {
                            if (Array[index, i] == 1 && !neighbors.Contains(i))
                            {
                                neighbors.Enqueue(i);

                                if (neighborsStartObj.Contains(i))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        #region Eulerian

        public bool HasEulerianPath()
        {
            var neighbors = new Queue<int>();
            var connectedComponent = 0;
            var objOddCount = 0;

            neighbors.Enqueue(0);

            while (neighbors.Count != 0)
            {
                var index = neighbors.Dequeue();

                connectedComponent++;

                var neighborsCount = 0;

                for (var i = index + 1; i < _objCount; i++)
                {
                    if (Array[index, i] == 1 && !neighbors.Contains(i))
                    {
                        neighbors.Enqueue(i);

                        neighborsCount++;
                    }
                }

                if (neighborsCount % 2 != 0 && objOddCount++ >= 2)
                {
                    return false;
                }
            }
             
            return connectedComponent == _objCount;
        }

        public bool HasEulerianCycles()
        {
            var neighbors = new Queue<int>();
            var connectedComponent = 0;

            neighbors.Enqueue(0);

            while (neighbors.Count != 0)
            {
                var index = neighbors.Dequeue();

                connectedComponent++;

                var neighborsCount = 0;

                for (var i = index + 1; i < _objCount; i++)
                {
                    if (Array[index, i] == 1 && !neighbors.Contains(i))
                    {
                        neighbors.Enqueue(i);

                        neighborsCount++;
                    }
                }

                if (neighborsCount % 2 != 0)
                {
                    return false;
                }
            }

            return connectedComponent == _objCount;
        }

        #endregion
    }
}
