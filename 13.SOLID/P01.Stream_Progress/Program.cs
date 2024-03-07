using System;
using System.Linq.Expressions;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {

            File music = new Music("Deep Purple", "Burn", 125, 586);
            File picture = new Pictures("Nature", 23, 444);

            StreamProgressInfo streamProgressInfo = new StreamProgressInfo(picture);

        }
    }
}
