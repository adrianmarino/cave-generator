using System;

namespace Util
{
    public class RandomFactory
    {
        public static Random Create()
        {
            return new Random(CurrentMillis().GetHashCode());
        }
        
        static  double CurrentMillis()
        {
            return (DateTime.Now - DateTime.MinValue).TotalMilliseconds;
        }
    }
}