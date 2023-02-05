class Show
{
    private int counter;
    static async Task Main(string[] args)
    {

        Show s = new Show();
        Console.WriteLine("Перший метод, який демонструє роботу класа Thread" + "\n");
        s.showThreat1();

        Console.WriteLine("Другий метод, який демонструє роботу класа Thread" + "\n");
        Console.WriteLine("Write something");
        String str = Console.ReadLine();
        s.showThreat2(str);

        Console.WriteLine("Метод, який демонструє роботу класа Async – Await" + "\n");
        int result1 = await AddNumbersAsync(5, 7);
        Console.WriteLine($"Результат методу 1: {result1}");

        int result2 = await AddNumbersAsync(10, 12);
        Console.WriteLine($"Результат методу 2: {result2}");

    }

    public void showThreat1() // Перший метод, який демонструє роботу класа Thread 
    {
        Thread thread1 = new Thread(() =>
        {
            for (int i = 0; i < 100; i++)
            {
                counter++;
            }
        });

        Thread thread2 = new Thread(() =>
        {
            for (int i = 0; i < 100; i++)
            {
                counter++;
            }
        });


        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine(counter);
    }

    public void showThreat2(String str) // Другий метод, який демонструє роботу класа Thread
    {
        char[] a = str.ToCharArray();
        Thread t = new Thread(() =>
        {
            Console.WriteLine("Your string is ");
            for (int i = 0; i < a.Length; i++)
            {
                Thread.Sleep(2000);
                Console.WriteLine(a[i]);
            }
        });
        t.Start();
        t.Join();
    }

    static async Task<int> AddNumbersAsync(int a, int b) // Метод, який демонструє роботу класа Async – Await
    {
        Console.WriteLine("Метод додавання запущено...");
        await Task.Delay(3000);
        Console.WriteLine("Метод додавання завершено");

        return a + b;
    }
}
