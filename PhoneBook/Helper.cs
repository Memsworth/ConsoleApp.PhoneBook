namespace PhoneBook;

public static class Helper
{
    public static int GetValidNumberInRange(int min, int max, string message)
    {
        int item;
        bool success;
        do
        {
            Console.Write($"{message}: ");
            success = int.TryParse(Console.ReadLine(), out item);
        } while (!success || item < min || item > max);

        return item;
    }
}