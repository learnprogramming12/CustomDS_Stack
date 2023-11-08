using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class PopTestModule
    {
        private static string m_strMark = "----------------------------------------------------------------";
        public PopTestModule() { }
        public static EnumResult Start(DynamicStack<int> stack)
        {
            while (true)
            {
                Console.WriteLine(m_strMark);
                Console.WriteLine("1)Pop  m)Main Menu  e)Exit");
                Console.WriteLine("Please input an instuction:");
                string strInput = Console.ReadLine().ToLower();

                switch (strInput)
                {
                    case "1":
                        TryToPopValue(stack);
                        break;
                    case "m":
                        return EnumResult.MAINMENU;
                    case "e":
                        return EnumResult.EXIT;
                    default:
                        {
                            Console.WriteLine("The input is invalid. Please enter a valid instruction.");
                            continue;
                        }
                }
            }
        }
        public static void TryToPopValue(DynamicStack<int> stack)
        {
            try
            {
                int iPop = stack.Pop();
                Console.WriteLine("{0} is popped.", iPop);
            }
            catch(DynamicStackException e)
            {
                Console.WriteLine("Warning: " + e.Message);
            }
        }

    }
}
