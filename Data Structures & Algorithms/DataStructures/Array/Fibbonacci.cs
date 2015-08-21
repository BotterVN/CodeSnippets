private int maxNumber = 10;
public void Run()
{
	var arr = new int[maxNumber];
	for (int i = 0; i < maxNumber; i++)
	{
		if (i < 2) arr[i] = i;
		else
			arr[i] = arr[i - 1] + arr[i - 2];
	}

	Console.Write(arr[maxNumber - 1]);
}