using GeneratorGameTasks.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneratorGameTasks
{
    public class TaskGenerator
    {
        public Arithmetic3x3 GenerateArithmetic3x3()
        {
            Random rand = new Random();
            int num = rand.Next(1, 9);
            List<ArithmeticExpression3> arithmeticsRow1 = GetArithmetics3(num);
            ArithmeticExpression3 row1 = arithmeticsRow1[rand.Next(0, arithmeticsRow1.Count - 1)];
            List<ArithmeticExpression3> arithmeticsCol1 = GetArithmetics3(row1.val1);
            ArithmeticExpression3 col1 = arithmeticsCol1[rand.Next(0, arithmeticsCol1.Count - 1)];
            List<ArithmeticExpression3> arithmeticsRow2 = GetArithmetics3(col1.val2);
            List<ArithmeticExpression3> arithmeticsRow3 = GetArithmetics3((int)col1.GetResult());
            List<ArithmeticExpression3> arithmeticsCol2 = GetArithmetics3(row1.val2);
            List<ArithmeticExpression3> arithmeticsCol3 = GetArithmetics3((int)row1.GetResult());
            List<Arithmetic3x3> temp3x3 = new List<Arithmetic3x3>();
            foreach (ArithmeticExpression3 row2 in arithmeticsRow2)
            {
                foreach (ArithmeticExpression3 row3 in arithmeticsRow3)
                {
                    foreach (ArithmeticExpression3 col2 in arithmeticsCol2)
                    {
                        foreach (ArithmeticExpression3 col3 in arithmeticsCol3)
                        {
                            
                            if (row2.val2 == col2.val2 && row2.GetResult() == col3.val2
                                && row3.val2 == col2.GetResult() && row3.GetResult() == col3.GetResult() )
                            {
                                Arithmetic3x3 newArithmetic3x3 = new Arithmetic3x3();
                                newArithmetic3x3.rows = new ArithmeticExpression3[3];
                                newArithmetic3x3.cols = new ArithmeticExpression3[3];
                                newArithmetic3x3.rows[0] = row1;
                                newArithmetic3x3.rows[1] = row2;
                                newArithmetic3x3.rows[2] = row3;
                                newArithmetic3x3.cols[0] = col1;
                                newArithmetic3x3.cols[1] = col2;
                                newArithmetic3x3.cols[2] = col3;
                                temp3x3.Add(newArithmetic3x3);
                            }
                        }
                    }
                }
            }
            return temp3x3[rand.Next(0, temp3x3.Count - 1)];
        }

        private List<ArithmeticExpression3> GetArithmetics3(int val1)
        {
            List<ArithmeticExpression3> arithmetics = new List<ArithmeticExpression3>();
            foreach (TOperation operation in Enum.GetValues(typeof(TOperation)))
            {
                ArithmeticExpression3 arithmetic = new ArithmeticExpression3();
                arithmetic.val1 = val1;
                for (int i = 1; i < 10; i++)
                {
                    arithmetic.val2 = i;
                    arithmetic.op = operation;
                    float result = arithmetic.GetResult();
                    if (result <= 9 && result >= 0 && (result - Math.Round(result)) == 0)
                    {
                        arithmetics.Add(arithmetic);
                    }
                }
            }
            return arithmetics;
        }

        public Arithmetic4x4 GenerateArithmetic4x4()
        {
            Random rand = new Random();
            int num = rand.Next(1, 9);
            List<ArithmeticExpression4> tempList;
            tempList = GetArithmetics4(num);
            ArithmeticExpression4 row1 = tempList[rand.Next(0, tempList.Count - 1)];
            tempList = GetArithmetics4(row1.val1);
            ArithmeticExpression4 col1 = tempList[rand.Next(0, tempList.Count - 1)];
            tempList = GetArithmetics4(row1.val2);
            ArithmeticExpression4 col2 = tempList[rand.Next(0, tempList.Count - 1)];
            tempList = GetArithmetics4(col1.val2, col2.val2);
            ArithmeticExpression4 row2 = tempList[rand.Next(0, tempList.Count - 1)];
            List<ArithmeticExpression4> rows3 = GetArithmetics4(col1.val3, col2.val3);
            List<ArithmeticExpression4> rows4 = GetArithmetics4((int)col1.GetResult(), (int)col2.GetResult());
            List<ArithmeticExpression4> cols3 = GetArithmetics4(row1.val3, row2.val3);
            List<ArithmeticExpression4> cols4 = GetArithmetics4((int)row1.GetResult(), (int)row2.GetResult());
            List<Arithmetic4x4> results = new List<Arithmetic4x4>();
            foreach (ArithmeticExpression4 row3 in rows3)
            {
                foreach (ArithmeticExpression4 row4 in rows4)
                {
                    foreach (ArithmeticExpression4 col3 in cols3)
                    {
                        foreach (ArithmeticExpression4 col4 in cols4)
                        {

                            if (row3.val3 == col3.val3 && row3.GetResult() == col4.val3
                                && row4.val3 == col3.GetResult() && row4.GetResult() == col4.GetResult())
                            {
                                Arithmetic4x4 newArithmetic4x4 = new Arithmetic4x4();
                                newArithmetic4x4.rows = new ArithmeticExpression4[4];
                                newArithmetic4x4.cols = new ArithmeticExpression4[4];
                                newArithmetic4x4.rows[0] = row1;
                                newArithmetic4x4.rows[1] = row2;
                                newArithmetic4x4.rows[2] = row3;
                                newArithmetic4x4.rows[3] = row4;
                                newArithmetic4x4.cols[0] = col1;
                                newArithmetic4x4.cols[1] = col2;
                                newArithmetic4x4.cols[2] = col3;
                                newArithmetic4x4.cols[3] = col4;
                                results.Add(newArithmetic4x4);
                            }
                        }
                    }
                }
            }
            return results[rand.Next(0, results.Count - 1)];
        }

        private List<ArithmeticExpression4> GetArithmetics4(int val1)
        {
            List<ArithmeticExpression4> arithmetics = new List<ArithmeticExpression4>();
            foreach (TOperation operation1 in Enum.GetValues(typeof(TOperation)))
            {
                foreach (TOperation operation2 in Enum.GetValues(typeof(TOperation)))
                {
                    ArithmeticExpression4 arithmetic = new ArithmeticExpression4();
                    arithmetic.val1 = val1;
                    arithmetic.op1 = operation1;
                    arithmetic.op2 = operation2;
                    for (int val2 = 1; val2 < 10; val2++)
                    {
                        for (int val3 = 1; val3 < 10; val3++)
                        {
                            arithmetic.val2 = val2;
                            arithmetic.val3 = val3;
                            float result = arithmetic.GetResult();
                            if (result <= 9 && result >= 0 && (result - Math.Round(result)) == 0)
                            {
                                arithmetics.Add(arithmetic);
                            }
                        }
                    }
                }
            }
            return arithmetics;
        }

        private List<ArithmeticExpression4> GetArithmetics4(int val1, int val2)
        {
            List<ArithmeticExpression4> arithmetics = new List<ArithmeticExpression4>();
            foreach (TOperation operation1 in Enum.GetValues(typeof(TOperation)))
            {
                foreach (TOperation operation2 in Enum.GetValues(typeof(TOperation)))
                {
                    ArithmeticExpression4 arithmetic = new ArithmeticExpression4();
                    arithmetic.val1 = val1;
                    arithmetic.val2 = val2;
                    arithmetic.op1 = operation1;
                    arithmetic.op2 = operation2;
                    for (int val3 = 1; val3 < 10; val3++)
                    {
                        arithmetic.val2 = val2;
                        arithmetic.val3 = val3;
                        float result = arithmetic.GetResult();
                        if (result <= 9 && result >= 0 && (result - Math.Round(result)) == 0)
                        {
                            arithmetics.Add(arithmetic);
                        }
                    }
                }
            }
            return arithmetics;
        }
    }
}
