using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p096_sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllText(@"..\..\..\..\..\p096_sudoku.txt");
            var strings = text.Split('\n');
            var len = strings.Length / 10;
            var curString = new List<String>();
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    curString.Add(strings[i * 10 + 1 + j]);
                }
                var sudoku = parseSudoku(curString.ToArray());
                var nsudoku = new sudoku(sudoku);
                var rsudoku = nsudoku.resolve();
                curString.Clear();
            }
        }

        static int[,] parseSudoku(string[] text, int N = 9, int M = 9)
        {
            var sudoku = new int[N, M];
            for (int s = 0; s < N; s++)
            {
                for (int c = 0; c < M; c++)
                {
                    sudoku[s, c] = Int32.Parse(text[s][c].ToString());
                }
            }
            return sudoku;
        }
    }

    //class sudokuSolution
    //{
    //    private int[,] sudoku;
    //    public sudokuSolution(int[,] sudoku, int N = 9, int M = 9, int blocks = 3)
    //    {
    //        this.sudoku = sudoku;
    //    }
    //}

    class sudoku
    {
        private List<int>[] lines;
        private List<int>[] columnes;
        private List<int>[,] blocks;
        private int[,] _sudoku;
        private int _N, _M, _blocksSize;

        public sudoku(int[,] sukoku, int N = 9, int M = 9, int blockSize = 3)
        {
            _sudoku = sukoku;
            _N = N;
            _M = M;
            _blocksSize = blockSize;
            //Инициализируем всем массивы
            lines = new List<int>[N];
            for(int i = 0; i < N; i++)
                lines[i] = new List<int>();
            columnes = new List<int>[M];
            for (int i = 0; i < M; i++)
                columnes[i] = new List<int>();
            blocks = new List<int>[blockSize, blockSize];
            for (int i = 0; i < blockSize; i++)
                for(int j = 0; j < blockSize; j++)
                    blocks[i, j] = new List<int>();
        }

        public int[,] resolve()
        {
            int[,] rsudoku = new int[_N, _M];
            List<int>[,] values = new List<int>[_N, _M];
            for (int i = 0; i < _N; i++)
            {
                for (int j = 0; j < _M; j++)
                {
                    var value = _sudoku[i, j];
                    rsudoku[i, j] = value;
                    if(value == 0)
                        values[i,j] = new List<int>();
                    else
                    {
                        lines[i].Add(value);
                        columnes[j].Add(value);
                        blocks[i/ _blocksSize, j / _blocksSize].Add(value);
                    }
                }
            }

            for (int i = 0; i < _N; i++)
            {
                for (int j = 0; j < _M; j++)
                {
                    //Если этого элемента ещё нет в матрице
                    if (values[i, j] != null)
                    {
                        values[i, j].AddRange(new List<int>(){1, 2, 3, 4, 5, 6, 7, 8, 9});
                        foreach (var num in lines[i])
                            values[i, j].Remove(num);
                        foreach (var column in columnes[j])
                            values[i, j].Remove(column);
                        foreach (var block in blocks[i / _blocksSize, j / _blocksSize])
                            values[i, j].Remove(block);



                    }
                }
            }

            return rsudoku;
        }
    }
}
