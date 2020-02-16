using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3
{
    class Program
    {
        static void Main(string[] args)
        {
            var john = new Humanoid(new Dancing());
            Console.WriteLine(john.ShowSkill()); //print dancing

            var alex = new Humanoid(new Cooking());
            Console.WriteLine(alex.ShowSkill());//print cooking

            var bob = new Humanoid();
            Console.WriteLine(bob.ShowSkill());//print no skill is defined

        }


    }

    class Humanoid
    {
        Skill mySkl;
        public Humanoid()
        {
        }

        public Humanoid(Skill skl)
        {
            mySkl = skl;
        }

        public string ShowSkill()
        {
            if (mySkl == null)
            {
                return "no Skill is defined";
            }

            return mySkl.GetSkillName();
        }
    }
    abstract class Skill
    {
        public abstract string GetSkillName();

    }

    class Dancing : Skill
    {
        public override string GetSkillName()
        {
            return "Dancing";
        }
    }

    class Cooking : Skill
    {
        public override string GetSkillName()
        {
            return "Cooking";
        }
    }
}
