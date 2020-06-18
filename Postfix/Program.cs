using System;
using System.Collections.Generic;

namespace Postfix
{
    class Program
    {
        //DECLARE AND INTIALIZE CONSTANTS
        const int MAX_EQUATION_SLOT = 15;
        static void Main(string[] args)
        {
            //CREATE STRING
            string arthimeticExpression = "";  // 15 7 1 1 + - / 3 * 2 1 1 + + - (preset expression = to 5)
            double operand_1 = 0.0;
            double operand_2 = 0.0;
 
            //INSTANTIATE AN INSTANCE OF A STACK
            Stack<string> stk_equation = new Stack<string>();

            do
            {
                Console.WriteLine("Enter the postfix expression with a space after each operand/operator.");
                arthimeticExpression = Console.ReadLine();
            } while (arthimeticExpression == "");

            //SPLIT STRING ON WHITESPACE
            string[] tokens = arthimeticExpression.Split();

            //LOOP THROUGH SPLIT STRING
            for (int index = 0; index < MAX_EQUATION_SLOT; index++)
            {
                //CALL ISOPERATOR FUNCTION AND SET EQUAL TO BOOL
                string current_token = tokens[index];
 
                if (IsOperator(current_token) == true)  {
                    // CONVERT FROM STRING TO DOUBLE
                    operand_1 = double.Parse(stk_equation.Pop());
                    operand_2 = double.Parse(stk_equation.Pop());
                    //CALL DO MATH FUNCTION AND PUSH ANSWER ONTO STACK
                    stk_equation.Push(DoMath(current_token, operand_1, operand_2).ToString());                                       
                }
                else
                {
                    //PUSH OPERANDS ONTO STACK
                    stk_equation.Push(tokens[index]);
                }//end iF               
            }//end for

            Console.WriteLine("The infix expression ((15 / (7 - (1 + 1))) * 3) - (2 + (1 + 1)) can be expressed in Postfix notation as: 15 7 1 1 + - / 3 * 2 1 1 + + -");
            Console.Write("The result of the postfix equation is:  ");
            Console.Write(stk_equation.Peek());
        }//end main
        public static bool IsOperator(string token)
        {

            return token == "+" || token == "/" || token == "-" || token == "*";
   
        }
        public static double DoMath(string mathOperator, double num1, double num2)
        {
            double result = 0.0;

            if (mathOperator == "+")    
            {
                result = num1 + num2;
                return result;
            }
            else if (mathOperator == "-")
            {
                result = num2 - num1;
                return result;
            }
           else if (mathOperator == "/")
            {
                result = num2 / num1;
                return result;
            }
            if (mathOperator == "*")
            {
                result = num1 * num2;
                return result;
            }
            return result;
        }

    }//end program
}//end namespace
