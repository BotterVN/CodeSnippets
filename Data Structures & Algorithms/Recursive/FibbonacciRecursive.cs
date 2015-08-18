private int F(int n)
{
	if (n < 2) return n;
	return F(n - 2) + F(n-1);
}

public void Run()
{
	var f = F(10);

	Console.Write(f);

	Console.Read();
}