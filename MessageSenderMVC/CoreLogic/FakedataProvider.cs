namespace MessageSenderMVC;

public class FakedataProvider
{
    public static IEnumerable<int> GetData()
    {//генерация случайной последовательности чисел для дальнейшего формирования отчёта для отсылки пользователю
        var rnd = new Random();
        var data = new List<int>();
        var count = rnd.Next(2, 10);

        for (int i = 0; i < count; i++)
        {
            data.Add(rnd.Next(100, 1000));
        }

        return data;
    }
}
