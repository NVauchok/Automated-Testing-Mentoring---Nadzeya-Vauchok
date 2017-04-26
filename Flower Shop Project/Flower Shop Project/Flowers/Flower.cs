using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Flower_Shop_Project.Flowers
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public abstract class Flower
    {
        public string sort { get; private set; }
        public Color color { get; private set; }
        public int price { get; private set; }
        
        public Flower() { }

        public Flower(string sort, Color color, int price)
        {
            this.sort = sort;
            this.color = color;
            this.price = price;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Color: {1}, Price: {2}",
                                 sort, color, price);
        }

    }

    public enum Color {Red, Yellow, Orange, White, Pink}

}
