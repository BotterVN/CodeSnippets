private int[] _dx = { 1, 0, -1, 0 };
private int[] _dy = { 0, 1, 0, -1 };

int[,] SpiralSort(int[,] m)
{
    var h = m.GetUpperBound(0) + 1;
    var w = m.GetUpperBound(1) + 1;
    var nElements = w * h;

    m = Sort(m); // please refer to the Sort 2d array
    var checkTable = new bool[h, w];
    var result = new int[h, w];

    var currentIndex = 1;
    var currentDirection = 0;
    var r = 0;
    var c = 0;

    result[r, c] = m[0, 0];
    checkTable[0, 0] = true;

    do
    {
        c += _dx[currentDirection];
        r += _dy[currentDirection];

        if ((r >= 0 && r < h) && (c >= 0 && c < w) && !checkTable[r, c])
        {   
            var oldRow = currentIndex / w;
            var oldCol = currentIndex % w;

            result[r, c] = m[oldRow, oldCol];
            checkTable[r, c] = true;

            currentIndex++;
        }
        else 
        {
            c -= _dx[currentDirection];
            r -= _dy[currentDirection];
            currentDirection = (currentDirection + 1) % 4;
        }
        
    } while (currentIndex < nElements);

    return result;
}