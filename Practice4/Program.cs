using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4
{
    class Program
    {
        static void Main(string[] args)
        {
            var alexa = new Alexa();
            Console.WriteLine(alexa.Talk()); //print hello, i am Alexa

            alexa.Configure(x =>
            {
                x.GreetingMessage = "Hello {OwnerName}, I'm at your service";
                x.OwnerName = "Bob Marley";

            });

            Console.WriteLine(alexa.Talk()); //print Hello Bob Marley, I'm at your service

            Console.WriteLine("press any key to exit ...");
            Console.ReadKey();

        }

    }

    class Alexa
    {

        public Alexa()
        {
            this.OwnerName = "";
            this.GreetingMessage = "Hello, I'm Alexa";
        }
        public string Talk()
        {
            return this.GreetingMessage.Replace("{OwnerName}", this.OwnerName);
        }

        public string GreetingMessage { get; set; }
        public string OwnerName { get; set; }
        public void Configure(Action<Alexa> configure)
        {

            configure(this);
        }

    }
}
