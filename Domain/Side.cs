using System;

namespace Domain
{
    public class Side
    {
        public int Length { get; }

        public Side(int length)
        {
            if (length <= 0) throw new ArgumentOutOfRangeException("Side length must be greater than 0.");

            Length = length;
        }
    }
}