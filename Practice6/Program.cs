using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6
{
    class Program
    {
        static void Main(string[] args)
        {
            var myHouse = new Building()
        .AddKitchen()
        .AddBedroom("master")
        .AddBedroom("guest")
        .AddBalcony();

            var normalHouse = myHouse.Build();

            //kitchen, master room, guest room, balcony
            Console.WriteLine(normalHouse.Describe());

            myHouse.AddKitchen().AddBedroom("another");

            var luxuryHouse = myHouse.Build();

            //it only shows the kitchen after build
            //kitchen, master room, guest room, balcony, kitchen, another room
            Console.WriteLine(luxuryHouse.Describe());
        }

    }
    class Building
    {
        protected string tmpBuildingDescription { get; set; }
        protected string FinalBuildingDescription { get; set; }

        public Building()
        {

        }

        protected Building(string buildingDescription)
        {
            this.FinalBuildingDescription = buildingDescription;
        }
        public Building Build()
        {
            return new Building(this.FinalBuildingDescription + this.tmpBuildingDescription); ;
        }

        public string Describe()
        {
            var str = this.FinalBuildingDescription.EndsWith(", ") ? this.FinalBuildingDescription.Remove(this.FinalBuildingDescription.Length - 2, 2) : this.FinalBuildingDescription;
            if (!string.IsNullOrEmpty(str))
            {
                str = char.ToUpper(str[0]) + str.Substring(1);
            }
            return str;
        }
        public Building AddKitchen()
        {
            this.tmpBuildingDescription = this.tmpBuildingDescription + "kitchen, ";
            return this;
        }

        public Building AddBedroom(string name)
        {
            this.tmpBuildingDescription = this.tmpBuildingDescription + name + " room, ";
            return this;
        }

        public Building AddBalcony()
        {
            this.tmpBuildingDescription = this.tmpBuildingDescription + "balcony, ";
            return this;
        }
    }
}
