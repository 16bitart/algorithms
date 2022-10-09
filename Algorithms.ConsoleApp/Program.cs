// See https://aka.ms/new-console-template for more information

using Algorithms;

Console.WriteLine("Hello, World!");
try
{
    var heapKey = new HeapKey<int>(0, 10);
    var heapKey2 = new HeapKey<int>(0, 20);
    var comp1 = heapKey.Compare(heapKey2);
    var comp2 = heapKey2.Compare(heapKey);

    Console.WriteLine($"{heapKey.Item}::{heapKey2.Item} = {comp1}");
    Console.WriteLine($"{heapKey2.Item}::{heapKey.Item} = {comp2}");
    Console.WriteLine($"Key1 < Key2: {heapKey < heapKey2}::Key1 > Key2: {heapKey > heapKey2}");

    var rng = new Random();
    var heap = new Heap<int>(1000);
    var cache = new List<int>();

    for (int i = 0; i < heap.Max - 1; i++)
    {
        var num = rng.Next(0, 10000);
        while (cache.Contains(num))
        {
            num = rng.Next(0, 10000);
        }
        heap.Add(num);
    }


    Console.WriteLine(heap.GetHeapItemRecords());

    var comparison = false;
    var lastValue = 0;
    for (int i = 0; i < heap.Count - 1; i++)
    {
        var next = heap.RemoveMin();
        if (i == 0)
        {
            lastValue = next;
            continue;
        }
        comparison = lastValue > next;
        Console.WriteLine($"{lastValue} > {next} = {comparison}");

        lastValue = next;
    }

    Console.ReadLine();
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}