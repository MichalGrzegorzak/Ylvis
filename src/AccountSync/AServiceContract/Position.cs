using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ServiceModel;

namespace AServiceContract
{
    [DataContract]
    public class Position
    {
        public Position()
        {}

        public Position(int size) : this(0, size, DateTime.Now)
        {
        }

        public Position(int price, int size, DateTime dt) 
        {
            Direct = "";
                //(size > 0) ? "K" : "S";
            if (size < 0)
            {
                size = size*-1;
                Direct = "S";
            }
            else if(size > 0)
            {
                Direct = "K";
            }

            Size = size;
            Date = dt;
            Price = price;
        }

        public Position(int size, string direction, int price, DateTime dt)
        {
            Direct = direction;
            if (size < 0)
                size = size * -1;
            
            Size = size;
            Date = dt;
            Price = price;
        }

        [DataMember] public int Size { get; set; }
        [DataMember] public int Price { get; set; }
        [DataMember] public DateTime Date { get; set; }
        [DataMember] public string Direct { get; set; }
        
        //public Direction Direct { get; set; }

        //[DataMember(Name="Direct")]
        //private string DirectionProperty
        //{
        //    get { return (Direct == Direction.L) ? "K" : "S"; }
        //    set
        //    {
        //        if (value == "K") Direct = Direction.L;
        //        else Direct = Direction.S;
        //    }
        //}
    }


}
