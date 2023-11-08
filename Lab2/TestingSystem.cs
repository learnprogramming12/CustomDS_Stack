using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//The testing system is divided into several modules to test Push, Pop, Peek, Clear and formatted print.
//Cui 20230427
namespace Lab2
{
    enum EnumResult
    {
        FAILED = -1,
        EXIT = 0,
        SUCCEED,
        PREVIOUS,
        CONTINUE,
        MAINMENU,
    }
    internal class TestingSystem
    {
        private DynamicStack<int> m_stack = new DynamicStack<int>();
        private static string m_strMark = "----------------------------------------------------------------";
        public TestingSystem() { }
        public void Launch()
        {
            Console.WriteLine(m_strMark);
            Console.WriteLine("          Welcome to the testing system of Dynamic Stack.");
            Console.WriteLine(m_strMark);

            while (true)
            {
                Console.WriteLine(m_strMark);
                string strOption;
                Console.WriteLine("1)Push Test  2)Pop Test  3)Peek Test  4)Print Formatted Stack  5)Clear Stack  e)Exit");
                strOption = Console.ReadLine().ToLower();
                EnumResult enumResult = EnumResult.CONTINUE;
                switch (strOption)
                {
                    case "1":
                        enumResult = PushTestModule.Start(m_stack);
                        break;
                    case "2":
                        enumResult = PopTestModule.Start(m_stack);
                        break;
                    case "3":
                        enumResult = PeekTestModule.Start(m_stack);
                        break;
                    case "4":
                        enumResult = PrintModule.Print(m_stack);
                        break;
                    case "5":
                        m_stack.Clear();
                        Console.WriteLine("The stack has cleared.");
                        break;
                    case "e":
                        enumResult = EnumResult.EXIT;
                        break;
                    default:
                        {
                            Console.WriteLine("The input is invalid. Please enter a valid instruction.");
                            continue;
                        }
                }
                //Other status value shouldn't make the system exit except EnumResult.EXIT.
                if (enumResult == EnumResult.EXIT)
                    break;
                /*                else if (enumResult == EnumResult.PREVIOUS || enumResult == EnumResult.SUCCEED || enumResult == EnumResult.MAINMENU)
                                    continue;*/
            }
        }
    }
}
