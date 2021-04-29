using System;

namespace AnswerOnline.Toolkit.Helper
{
    public class CheckHelper
    {
        public static void CheckNull<T>(T obj)
        {
            if (obj == null || obj.Equals(null)) 
            {
                throw new ArgumentNullException(nameof(obj));
            }
        } 
    }
}