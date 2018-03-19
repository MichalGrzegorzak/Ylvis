using System;
using Commons.UI;

namespace Core
{
    public class Position : IQuestion
    {
        public int Size { get; set; }
        public decimal EntryPoint { get; set; }
        public DateTime EntryDate { get; set; }
        public string Direction { get; set; }

        public Position(decimal price, int size, DateTime dt)
        {
            Direction = (size > 0) ? "K" : "S";
            if (size < 0)
                size = size*-1;
            
            Size = size;
            EntryDate = dt;
            EntryPoint = price;
        }

        public Position(Position pos) : this(pos.EntryPoint, pos.Size, pos.EntryDate)
        {
        }

        public bool IsEqual(Position pos)
        {
            bool result = false;
            if (Direction == pos.Direction)
            {
                result = (Size == pos.Size);
            }
            return result;
        }

        public override string ToString()
        {
            return Size + " " + Direction;
        }

        public string Question
        {
            get
            {
                return "Would you like to Cancel synchronization? on accountId";
            }
            set
            {
            }
        }

        public string QuestionDetails
        {
            get
            {
                string s = "New position: " + this.ToString() + "\n";
                s += "Signal time: " + EntryDate;

                return s;
            }
            set
            {
            }
        }

    }
}