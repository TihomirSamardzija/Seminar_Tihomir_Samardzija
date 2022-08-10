using Seminar_Tihomir_Samardzija.Services.Interface;

namespace Seminar_Tihomir_Samardzija.Services.Implementation
{
    public class SharedService : ISharedService
    {
        public List<int>? GetRandomNumberList(int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            if (end == 0)
            {
                return null;
            }
            Random random = new Random();
            List<int> list = new List<int>();
            while (list.Count() < end)
            {
                var randomNumber = random.Next(start, end);
                var find = list.FirstOrDefault(x => x == randomNumber);
                if (find != null)
                {
                    list.Add(randomNumber);
                }
            }
            return list;
        }
    }
}
