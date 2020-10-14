using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace GeneratorGameTasks.Types
{
    public struct ArithmeticExpression3
    {
        public int val1;
        public int val2;
        public TOperation op;
        public float GetResult()
        {
            float result = 0;
            switch (op)
            {
                case TOperation.Add:
                    result = val1 + val2;
                    break;
                case TOperation.Sub:
                    result = val1 - val2;
                    break;
                case TOperation.Mult:
                    result = val1 * val2;
                    break;
                case TOperation.Div:
                    try
                    {
                        result = (float) val1 / val2;
                    }
                    catch
                    {
                        throw new Exception("Error: division by zero");
                    }
                    break;
            }
            return result;
        }
        public override string ToString()
        {
            string str;
            try
            {
                str = val1.ToString()
                + " " + ToString(op)
                + " " + val2.ToString()
                + " = " + GetResult().ToString();
            }
            catch (Exception e)
            {
                str = e.Message;
            }
            
            return str;
        }

        private string ToString(TOperation operation)
        {
            switch (operation)
            {
                case TOperation.Add:
                    return "+";
                case TOperation.Sub:
                    return "-";
                case TOperation.Mult:
                    return "*";
                default:
                    return "/";
            }
        }
    }

    public struct ArithmeticExpression4
    {
        public int val1;
        public int val2;
        public int val3;
        public TOperation op1;
        public TOperation op2;
        public float GetResult()
        {
            float result = 0;
            switch (op1)
            {
                case TOperation.Add:
                    switch (op2)
                    {
                        case TOperation.Add:
                            result = val1 + val2 + val3;
                            break;
                        case TOperation.Sub:
                            result = val1 + val2 - val3;
                            break;
                        case TOperation.Mult:
                            result = val1 + val2 * val3;
                            break;
                        case TOperation.Div:
                            try
                            {
                                result = (float)val1 + (float)val2 / (float)val3;
                            }
                            catch
                            {
                                throw new Exception("Error: division by zero");
                            }
                            break;
                    }
                    break;
                case TOperation.Sub:
                    switch (op2)
                    {
                        case TOperation.Add:
                            result = val1 - val2 + val3;
                            break;
                        case TOperation.Sub:
                            result = val1 - val2 - val3;
                            break;
                        case TOperation.Mult:
                            result = val1 - val2 * val3;
                            break;
                        case TOperation.Div:
                            try
                            {
                                result = (float)val1 - (float)val2 / (float)val3;
                            }
                            catch
                            {
                                throw new Exception("Error: division by zero");
                            }
                            break;
                    }
                    break;
                case TOperation.Mult:
                    switch (op2)
                    {
                        case TOperation.Add:
                            result = val1 * val2 + val3;
                            break;
                        case TOperation.Sub:
                            result = val1 * val2 - val3;
                            break;
                        case TOperation.Mult:
                            result = val1 * val2 * val3;
                            break;
                        case TOperation.Div:
                            try
                            {
                                result = (float)val1 * (float)val2 / (float)val3;
                            }
                            catch
                            {
                                throw new Exception("Error: division by zero");
                            }
                            break;
                    }
                    break;
                case TOperation.Div:
                    switch (op2)
                    {
                        case TOperation.Add:
                            result = (float)val1 / (float)val2 + val3;
                            break;
                        case TOperation.Sub:
                            result = (float)val1 / (float)val2 - val3;
                            break;
                        case TOperation.Mult:
                            result = (float)val1 / (float)val2 * val3;
                            break;
                        case TOperation.Div:
                            try
                            {
                                result = (float)val1 / (float)val2 / (float)val3;
                            }
                            catch
                            {
                                throw new Exception("Error: division by zero");
                            }
                            break;
                    }
                    break;
            }
            return result;
        }

        public override string ToString()
        {
            string str;
            try
            {
                float result = GetResult();
                str = val1.ToString()
                + " " + ToString(op1)
                + " " + val2.ToString()
                + " " + ToString(op2)
                + " " + val3.ToString()
                + " = " + result.ToString();
            }
            catch (Exception e)
            {
                str = e.Message;
            }
            return str;
        }

        private string ToString(TOperation operation)
        {
            switch (operation)
            {
                case TOperation.Add:
                    return "+";
                case TOperation.Sub:
                    return "-";
                case TOperation.Mult:
                    return "*";
                default:
                    return "/";
            }
        }
    }

    public struct Arithmetic3x3
    {
        public ArithmeticExpression3[] rows;
        public ArithmeticExpression3[] cols;

        public override string ToString()
        {
            string str = "";
            for ( int i = 0; i < rows.Length; i++ )
            {
                str += rows[i].ToString();
                if (i < rows.Length - 2)
                {
                    str += "\n";
                    for ( int j = 0; j < cols.Length; j++ )
                    {
                        switch ( cols[j].op )
                        {
                            case TOperation.Add:
                                str += "+";
                                break;
                            case TOperation.Sub:
                                str += "-";
                                break;
                            case TOperation.Mult:
                                str += "*";
                                break;
                            default:
                                str += "/";
                                break;
                        }
                        if (j < cols.Length - 1)
                        {
                            str += "   ";
                        }
                    }
                    str += "\n";
                }
                if (i == rows.Length - 2)
                {
                    str += "\n";
                    for (int j = 0; j < cols.Length; j++)
                    {
                        str += "=";
                        if (j < cols.Length - 1)
                        {
                            str += "   ";
                        }
                    }
                    str += "\n";
                }
            }
            return str;
        }
    }

    public struct Arithmetic4x4
    {
        public ArithmeticExpression4[] rows;
        public ArithmeticExpression4[] cols;

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < rows.Length; i++)
            {
                str += rows[i].ToString();
                if (i < rows.Length - 2)
                {
                    str += "\n";
                    for (int j = 0; j < cols.Length; j++)
                    {
                        if (i == 0)
                        {
                            switch (cols[j].op1)
                            {
                                case TOperation.Add:
                                    str += "+";
                                    break;
                                case TOperation.Sub:
                                    str += "-";
                                    break;
                                case TOperation.Mult:
                                    str += "*";
                                    break;
                                default:
                                    str += "/";
                                    break;
                            }
                        }
                        else
                        {
                            switch (cols[j].op2)
                            {
                                case TOperation.Add:
                                    str += "+";
                                    break;
                                case TOperation.Sub:
                                    str += "-";
                                    break;
                                case TOperation.Mult:
                                    str += "*";
                                    break;
                                default:
                                    str += "/";
                                    break;
                            }
                        }
                        
                        if (j < cols.Length - 1)
                        {
                            str += "   ";
                        }
                    }
                    str += "\n";
                }
                if (i == rows.Length - 2)
                {
                    str += "\n";
                    for (int j = 0; j < cols.Length; j++)
                    {
                        str += "=";
                        if (j < cols.Length - 1)
                        {
                            str += "   ";
                        }
                    }
                    str += "\n";
                }
            }
            return str;
        }
    }
}
