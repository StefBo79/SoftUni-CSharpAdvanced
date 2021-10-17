(Console.ReadLine().Split(",").Select(int.Parse));
==================== print matrix:
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < matrix[i].Length; j++)
    {
        Console.Write(matrix[i][j]);
    }
    Console.WriteLine();
}
===================== fill matrix:
for (int i = 0; i < n; i++)
{
   var chars = Console.ReadLine().ToCharArray();
   matrix[i] = chars;
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
if (command == "up" && row - 1 >= 0)
                {
                    row--;
                }
                else if (command == "down" && row + 1 < n)
                {
                    row++;
                }
                else if (command == "left" && col - 1 >= 0)
                {
                    col--;
                }
                else if (command == "right" && col + 1 < territory[row].Length)
                {
                    col++;
                }
============================== bool Validation:
public static bool IsValidPosition (int row, int col, int rows, int cols) 
{
    if (row < 0 || row >= rows || col < 0 || col >= cols)
    {
        return false;
    }
    return true;
}