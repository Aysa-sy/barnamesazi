using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barname_sazi.sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
                int[,] sudokuGrid = new int[,]
                {
                { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
                { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
                { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
                { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
                { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
                { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
                { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
                { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
                { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
                };

                if (Sudoku(sudokuGrid))
                {
                    Console.WriteLine("Sudoku solved:");
                    PrintGrid(sudokuGrid);
                }
                else
                {
                    Console.WriteLine("No solution found!");
                }

                Console.ReadLine();
            }

            static bool Sudoku(int[,] grid)
            {
                int row, col;
                if (!FindEmptyCell(grid, out row, out col))
                {
                    return true; // Puzzle solved
                }

                for (int num = 1; num <= 9; num++)
                {
                    if (IsValidMove(grid, row, col, num))
                    {
                        grid[row, col] = num;

                        if (Sudoku(grid))
                        {
                            return true;
                        }

                        grid[row, col] = 0; // Backtrack
                    }
                }

                return false; // No valid number can be placed
            }

            static bool FindEmptyCell(int[,] grid, out int row, out int col)
            {
                for (row = 0; row < 9; row++)
                {
                    for (col = 0; col < 9; col++)
                    {
                        if (grid[row, col] == 0)
                        {
                            return true;
                        }
                    }
                }

                row = -1;
                col = -1;
                return false;
            }

            static bool IsValidMove(int[,] grid, int row, int col, int num)
            {
                return !IsInRow(grid, row, num) && !IsInColumn(grid, col, num) && !IsInBox(grid, row - row % 3, col - col % 3, num);
            }

            static bool IsInRow(int[,] grid, int row, int num)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (grid[row, col] == num)
                    {
                        return true;
                    }
                }

                return false;
            }

            static bool IsInColumn(int[,] grid, int col, int num)
            {
                for (int row = 0; row < 9; row++)
                {
                    if (grid[row, col] == num)
                    {
                        return true;
                    }
                }

                return false;
            }

            static bool IsInBox(int[,] grid, int startRow, int startCol, int num)
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (grid[startRow + row, startCol + col] == num)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }

            static void PrintGrid(int[,] grid)
            {
                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        Console.Write(grid[row, col] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
