using System;
namespace Assignment2.Model
{
    //Singleton class for all calculator math
    public sealed class DCMath
    {
        private static DCMath instance = null;
        private static readonly object padlock = new object();

        public DCMath()
        {
        }

        public static DCMath Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DCMath();
                    }
                    return instance;
                }
            }
        }

        //Converts stacks of 14 trays into tray count and adds all extra trays
        public static int convertToTrays(int stacks, int odds)
        {
            int trays = (stacks * 14) + odds;
            return trays;
        }

        //Converts stacks of 13 trays into tray count and adds extra trays
        public static int convert13ToTrays(int stacks, int odds)
        {
            int trays = (stacks * 13) + odds;
            return trays;
        }

        //Calculate stacks from trays (doesn't round or calculate odds)
        public static int traysToStacks(int trays)
        {
            return trays/14;
        }

        //Calculates the odds from total trays (doesn't count full stacks)
        public static int traysToOdds(int trays)
        {
            int stacks = traysToStacks(trays);
            return trays - (stacks*14);
        }

        //Calculate Estimated weight of trailer by stacks
        public static int calculateWeight(int stacks)
        {
            return stacks * 200;
        }

        //Loading Maths
        public static double loadingPoition(int stacksOnTrailer)
        {
            double pos = (double)stacksOnTrailer / 4;
            return pos;
        }
    }
}
