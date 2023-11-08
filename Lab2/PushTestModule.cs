using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class PushTestModule
    {
        private static string m_strMark = "----------------------------------------------------------------";
        public PushTestModule() { }

        public static EnumResult Start(DynamicStack<int> stack)
        {
            while (true)
            {
                Console.WriteLine(m_strMark);
                Console.WriteLine("m)Main Menu  e)Exit");
                Console.WriteLine("Please input the value to push:");
                string strInput = Console.ReadLine().ToLower();

                switch (strInput)
                {
                    case "m":
                        return EnumResult.MAINMENU;
                    case "e":
                        return EnumResult.EXIT;
                    default:
                        {
                            TryToPush(stack, strInput);
                            continue;
                        }
                }
            }
        }
        private static void TryToPush(DynamicStack<int> stack, string strValue)
        {
            bool bValid = int.TryParse(strValue, out int iResult);
            if (!bValid)
            {
                Console.WriteLine("The input is not valid.");
                return;
            }
            try
            {
                stack.Push(iResult);
                Console.WriteLine("{0} is pushed.", iResult);
            }
            catch (DynamicStackException e)
            {
                Console.WriteLine("Warning: " + e.Message);
            }
        }
    }
}
