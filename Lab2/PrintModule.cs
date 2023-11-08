using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class PrintModule
    {
        private static string m_strMark = "----------------------------------------------------------------";
        public static EnumResult Print(DynamicStack<int> stack/*EnumDataStructrue enumCurrentDataStructure, DataType dataStructure*/)
        {
            if (stack.Count == 0)
            {
                Console.WriteLine("Warning: The stack is empty.");
                return EnumResult.PREVIOUS;
            }
            while (true)
            {
                Console.WriteLine(m_strMark);
                Console.WriteLine("1)Seperated with new line  2)Seperated with comma  3)Seperated with index  m)Main Menu  e)Exit");
                Console.WriteLine("Please input the print format:");
                string strInput = Console.ReadLine().ToLower();
                EnumPrintFormat enumFormat;
                switch (strInput)
                {
                    case "1":
                        enumFormat = EnumPrintFormat.WithNewLine;
                        break;
                    case "2":
                        enumFormat = EnumPrintFormat.WithComma;
                        break;
                    case "3":
                        enumFormat = EnumPrintFormat.WithIndex;
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
                PrintFormat.Print(stack, enumFormat);
            }
        }
    }
}
