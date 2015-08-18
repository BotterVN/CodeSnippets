int[,] Sort(int[,] m)
{   
    var h = m.GetUpperBound(0) + 1;
    var w = m.GetUpperBound(1) + 1;
    var nElements = w  * h;

    // sort it
    for (int i = 0; i < nElements - 1; i++)
    {
        var r1 = i / w;
        var c1 = i % w;
        for (int j = i + 1; j < nElements; j++)
        {
            var r2 = j / w;
            var c2 = j % w;

            if (m[r1, c1] > m[r2, c2])
            {
                var tmp = m[r1, c1];
                m[r1, c1] = m[r2, c2];
                m[r2, c2] = tmp;
            }
        }
    }

    return m;
}