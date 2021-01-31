using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public abstract class Animal
    {
        public abstract void Walk();
    }

    public class Alligator : Animal 
    {
        public override void Walk()
        {
            Console.WriteLine("Alligator crawls on the swamp area. ");
        }
    }

    public class Mouse : Animal
    {
        public override void Walk()
        {
            Console.WriteLine("Mice scurry on the ground to go after the cheese");
        }
    }
}
