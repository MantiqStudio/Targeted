using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Targeted
{
    public class Engine : List<Target>
    {
        public int WaysNumber = 10;
        public float BasicPower = 5;
        public Random random = new Random();
        public Target GetBest(Target fort)
        {
            float LastDistance = 1000;
            Target Better = null;
            foreach(Target target in this)
            {
                if(DistanceTarget(target, fort) < LastDistance)
                {
                    Better = target;
                    LastDistance = DistanceTarget(target, fort);
                } 
            }
            return Better;
        }
        public static void Approximation(Target t1, Target t2, float Power = -1)
        {
            if(Power == -1) Power = 1;
            foreach (float i in t1)
            {
                t1[t1.IndexOf(i)] = Lerp(i, t2[t1.IndexOf(i)], Power / t1.Usings);
            }
            foreach (float i in t2)
            {
                t2[t2.IndexOf(i)] = Lerp(i, t1[t2.IndexOf(i)], Power / t2.Usings);
            }
            t1.Usings++;
            t2.Usings++;
        }

        public static void Away(Target t1, Target t2, float Power = -1)
        {
            if (Power == -1) Power = 1;
            foreach (float i in t1)
            {
                t1[t1.IndexOf(i)] = Lerp(i, t2[t1.IndexOf(i)], -(Power / t1.Usings));
            }
            foreach (float i in t2)
            {
                t2[t2.IndexOf(i)] = Lerp(i, t1[t2.IndexOf(i)], -(Power / t2.Usings));
            }
            t1.Usings++;
            t2.Usings++;
        }

        //Tasks
        private static float Lerp(float firstValue, float secondValue, float by)
        {
            return firstValue * (1 - by) + secondValue * by;
        }
        private static float DistanceTarget(Target t1, Target t2)
        {
            float distance = 0;
            int number = 0;
            if(number != t1.Count)
            {
                distance += Distance(t1[number], t2[number]);
                number++;
            }
            return distance / number;
        }
        private static float Distance(float one, float two)
        {
            if(one > two) return one - two;
            else return two - one;
        }
    }
    public class Target : List<float>
    {
        public float Usings = 1;
        public Target(Engine engine)
        {
            int i = engine.WaysNumber;
            while(i > 0)
            {
                Add(engine.random.Next());
                i--;
            }
        }
    }
}
