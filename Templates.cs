(Console.ReadLine().Split(",").Select(int.Parse));
==================== print matrix:
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < teritorry[i].Length; j++)
    {
        Console.Write(teritorry[i][j]);
    }
    Console.WriteLine();
}
===================== fill matrix:
for (int i = 0; i < n; i++)
{
   var chars = Console.ReadLine().ToCharArray();
   teritorry[i] = chars;
}
==================== or:
for (int row = 0; row < n; row++)
{
    string currentRow = Console.ReadLine();
    for (int col = 0; col < currentRow.Length; col++)
    {
        matrix[row, col] = currentRow[col];
    }
}
========================= movement:
public static int MoveRow (int row, string movement) 
{
    if (movement == "up")
    {
        return row - 1;
    }
    if (movement == "down")
    {
        return row + 1;
    }
    return row;
}

public static int MoveCol(int col, string movement)
{
    if (movement == "left")
    {
        return col - 1;
    }
    if (movement == "right")
    {
        return col + 1;
    }
    return col;
}
============================== or:
if (command == "up" && beeRow - 1 >= 0)
                {
                    beeRow--;
                }
                else if (command == "down" && beeRow + 1 < n)
                {
                    beeRow++;
                }
                else if (command == "left" && beeCol - 1 >= 0)
                {
                    beeCol--;
                }
                else if (command == "right" && beeCol + 1 < territory[beeRow].Length)
                {
                    beeCol++;
                }
============================== bool Validation:
public static bool IsInside (int row, int col, int rows, int cols) 
{
    if (row < 0 || row >= rows || col < 0 || col >= cols)
    {
        return false;
    }
    return true;
}