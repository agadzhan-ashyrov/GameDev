using System;
using System.Collections.Generic;
using System.IO;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Arithmetic3> arithmetics3 = GenerateArithmetics3();
            List<Arithmetic3> temp1 = new List<Arithmetic3>();
            Random rand = new Random();
            while (temp1.Count != 100)
            {
                int num = rand.Next(1, arithmetics3.Count);
                Arithmetic3 elem = arithmetics3[num - 1];
                if (!temp1.Contains(elem))
                {
                    if ((elem.result != 0 && elem.val1 != 0 && elem.val2 != 0)
                    || (elem.result != 0 && elem.val1 != 0 && elem.val2 == 0)
                    || (elem.result == 0 && elem.val1 != 0 && elem.val2 != 0)
                    || (elem.result != 0 && elem.val1 == 0 && elem.val2 != 0))
                    {
                        temp1.Add(elem);
                    }
                }
            }
            List<Arithmetic4> arithmetics4 = GenerateArithmetics4();
            List<Arithmetic4> temp2 = new List<Arithmetic4>();
            while ( temp2.Count != 100 )
            {
                int num = rand.Next(1, arithmetics4.Count);
                Arithmetic4 elem = arithmetics4[num - 1];
                if (!temp2.Contains(elem))
                {
                    if ((elem.val1 != 0 && elem.val2 != 0 && elem.val3 != 0 && elem.result != 0)
                        || (elem.val1 == 0 && elem.val2 != 0 && elem.val3 != 0 && elem.result != 0)
                        || (elem.val1 != 0 && elem.val2 == 0 && elem.val3 != 0 && elem.result != 0)
                        || (elem.val1 != 0 && elem.val2 != 0 && elem.val3 == 0 && elem.result != 0)
                        || (elem.val1 != 0 && elem.val2 != 0 && elem.val3 != 0 && elem.result == 0))
                    temp2.Add(elem);
                }
            }
            List<Table3x3> tables3x3 = GenerateTables3x3(temp1);
            List<Table4x4> tables4x4 = GenerateTables4x4(temp2);
            using (StreamWriter sw = new StreamWriter("ar3x3.txt", false, System.Text.Encoding.Default))
            {
                sw.Write("");
            }
            using (StreamWriter sw = new StreamWriter("ar4x4.txt", false, System.Text.Encoding.Default))
            {
                sw.Write("");
            }
            foreach (Table3x3 table in tables3x3)
            {
                table.WriteFile("ar3x3.txt");
            }
            foreach (Table4x4 table in tables4x4)
            {
                table.WriteFile("ar4x4.txt");
            }
        }

        private static readonly char[] _operators = { '+', '-', '/', '*' };

        private struct Table3x3
        {
            public Arithmetic3[] rows;
            public Arithmetic3[] cols;

            public void WriteFile(string path)
            {
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    if (cols.Length == 3 && rows.Length == 3)
                    {
                        sw.WriteLine(rows[0].val1 + " " + rows[0].op + " " + rows[0].val2 + " = " + rows[0].result);
                        sw.WriteLine(cols[0].op + "   " + cols[1].op + "   " + cols[2].op);
                        sw.WriteLine(rows[1].val1 + " " + rows[1].op + " " + rows[1].val2 + " = " + rows[1].result);
                        sw.WriteLine("=   =   =");
                        sw.WriteLine(rows[2].val1 + " " + rows[2].op + " " + rows[2].val2 + " = " + rows[2].result);
                        sw.WriteLine("");
                    }
                    else
                    {
                        sw.WriteLine("Error");
                    }
                }
            }
        }

        private struct Table4x4
        {
            public Arithmetic4[] rows;
            public Arithmetic4[] cols;

            public void WriteFile(string path)
            {
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    if (cols.Length == 4 && rows.Length == 4)
                    {
                        sw.WriteLine(rows[0].val1 + " " + rows[0].op1 + " " + rows[0].val2 + " " + rows[0].op2 + " " + rows[0].val3 + " = " + rows[0].result);
                        sw.WriteLine(cols[0].op1 + "   " + cols[1].op1 + "   " + cols[2].op1 + "   " + cols[3].op1);
                        sw.WriteLine(rows[1].val1 + " " + rows[1].op1 + " " + rows[1].val2 + " " + rows[1].op2 + " " + rows[1].val3 + " = " + rows[1].result);
                        sw.WriteLine(cols[0].op2 + "   " + cols[1].op2 + "   " + cols[2].op2 + "   " + cols[3].op2);
                        sw.WriteLine(rows[2].val1 + " " + rows[2].op1 + " " + rows[2].val2 + " " + rows[2].op2 + " " + rows[2].val3 + " = " + rows[2].result);
                        sw.WriteLine("=   =   =   =");
                        sw.WriteLine(rows[3].val1 + " " + rows[3].op1 + " " + rows[3].val2 + " " + rows[3].op2 + " " + rows[3].val3 + " = " + rows[3].result);
                        sw.WriteLine("");
                    }
                    else
                    {
                        sw.WriteLine("Error");
                    }
                }
            }
        }
        public struct Arithmetic3
        {
            public byte val1;
            public char op;
            public byte val2;
            public int result;

            public Arithmetic3(byte val1, char op, byte val2, int result)
            {
                this.val1 = val1;
                this.op = op;
                this.val2 = val2;
                this.result = result;
            }
        }
        public struct Arithmetic4
        {
            public byte val1;
            public char op1;
            public byte val2;
            public char op2;
            public byte val3;
            public int result;

            public Arithmetic4(byte val1, char op1, byte val2, char op2, byte val3, int result)
            {
                this.val1 = val1;
                this.op1 = op1;
                this.val2 = val2;
                this.op2 = op2;
                this.val3 = val3;
                this.result = result;
            }
        }

        private static List<Table3x3> GenerateTables3x3(List<Arithmetic3> arithmetics3)
        {
            List<Table3x3> tables = new List<Table3x3>();
            foreach (Arithmetic3 row1 in arithmetics3)
            {
                foreach (Arithmetic3 row2 in arithmetics3)
                {
                    foreach (Arithmetic3 row3 in arithmetics3)
                    {
                        List<Arithmetic3> cols1 = new List<Arithmetic3>();
                        List<Arithmetic3> cols2 = new List<Arithmetic3>();
                        List<Arithmetic3> cols3 = new List<Arithmetic3>();
                        foreach (Arithmetic3 col in arithmetics3)
                        {
                            if (row1.val1 == col.val1 && row2.val1 == col.val2 && row3.val1 == col.result)
                            {
                                cols1.Add(col);
                            }
                            if (row1.val2 == col.val1 && row2.val2 == col.val2 && row3.val2 == col.result)
                            {
                                cols2.Add(col);
                            }
                            if (row1.result == col.val1 && row2.result == col.val2 && row3.result == col.result)
                            {
                                cols3.Add(col);
                            }
                        }
                        foreach (Arithmetic3 col1 in cols1)
                        {
                            foreach (Arithmetic3 col2 in cols2)
                            {
                                foreach (Arithmetic3 col3 in cols3)
                                {
                                    Table3x3 table = new Table3x3();
                                    table.rows = new Arithmetic3[3] { row1, row2, row3 };
                                    table.cols = new Arithmetic3[3] { col1, col2, col3 };
                                    tables.Add(table);
                                }
                            }
                        }
                    }
                }
            }
            return tables;
        }

        private static List<Table4x4> GenerateTables4x4(List<Arithmetic4> arithmetics4)
        {
            List<Table4x4> tables = new List<Table4x4>();
            foreach (Arithmetic4 row1 in arithmetics4 ) {
                List<Arithmetic4> cols1 = new List<Arithmetic4>();
                List<Arithmetic4> cols2 = new List<Arithmetic4>();
                List<Arithmetic4> cols3 = new List<Arithmetic4>();
                List<Arithmetic4> cols4 = new List<Arithmetic4>();
                foreach (Arithmetic4 col in arithmetics4)
                {
                    if (row1.val1 == col.val1)
                    {
                        cols1.Add(col);
                    }
                    if (row1.val2 == col.val1)
                    {
                        cols2.Add(col);
                    }
                    if (row1.val3 == col.val1)
                    {
                        cols3.Add(col);
                    }
                    if (row1.result == col.val1)
                    {
                        cols4.Add(col);
                    }
                }

                if (cols1.Count != 0 && cols2.Count != 0 && cols3.Count != 0 && cols4.Count != 0)
                {
                    foreach (Arithmetic4 col1 in cols1)
                    {
                        foreach (Arithmetic4 col2 in cols2)
                        {
                            foreach (Arithmetic4 col3 in cols3)
                            {
                                foreach (Arithmetic4 col4 in cols4)
                                {
                                    List<Arithmetic4> rows2 = new List<Arithmetic4>();
                                    List<Arithmetic4> rows3 = new List<Arithmetic4>();
                                    List<Arithmetic4> rows4 = new List<Arithmetic4>();
                                    foreach (Arithmetic4 row in arithmetics4)
                                    {
                                        if (row.val1 == col1.val2 && row.val2 == col2.val2 && row.val3 == col3.val2 && row.result == col4.val2)
                                        {
                                            rows2.Add(row);
                                        }
                                        if (row.val1 == col1.val3 && row.val2 == col2.val3 && row.val3 == col3.val3 && row.result == col4.val3)
                                        {
                                            rows3.Add(row);
                                        }
                                        if (row.val1 == col1.result && row.val2 == col2.result && row.val3 == col3.result && row.result == col4.result)
                                        {
                                            rows4.Add(row);
                                        }
                                    }

                                    if (rows2.Count != 0 && rows3.Count != 0 && rows4.Count != 0)
                                    {
                                        foreach (Arithmetic4 row2 in rows2)
                                        {
                                            foreach (Arithmetic4 row3 in rows3)
                                            {
                                                foreach (Arithmetic4 row4 in rows4)
                                                {
                                                    Table4x4 table = new Table4x4();
                                                    table.cols = new Arithmetic4[4] { col1, col2, col3, col4 };
                                                    table.rows = new Arithmetic4[4] { row1, row2, row3, row4 };
                                                    tables.Add(table);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return tables;
        }

        public static List<Arithmetic3> GenerateArithmetics3()
        {
            List<Arithmetic3> arithmetics3 = new List<Arithmetic3>();
            for (byte i = 0; i < 10; i++)
            {
                for (byte j = 0; j < 10; j++)
                {
                    if (i + j <= 9)
                    {
                        arithmetics3.Add(new Arithmetic3(i, '+', j, i + j));
                    }
                    if (i - j <= 9 && i - j >= 0)
                    {
                        arithmetics3.Add(new Arithmetic3(i, '-', j, i - j));
                    }
                    if (i * j <= 9)
                    {
                        arithmetics3.Add(new Arithmetic3(i, '*', j, i * j));
                    }
                    if (j != 0)
                    {
                        if (i % j == 0 && i / j >= 0 && i / j <= 9)
                        {
                            arithmetics3.Add(new Arithmetic3(i, '/', j, i / j));
                        }
                    }
                }
            }
            return arithmetics3;
        }

        public static List<Arithmetic4> GenerateArithmetics4()
        {
            List<Arithmetic4> arithmetics4 = new List<Arithmetic4>();
            for (byte i = 0; i < 10; i++)
            {
                for (byte j = 0; j < 10; j++)
                {
                    for (byte n = 0; n < 10; n++)
                    {
                        for (byte k = 0; k < _operators.Length; k++)
                        {
                            char op1 = _operators[k];
                            for (byte m = 0; m < _operators.Length; m++)
                            {
                                char op2 = _operators[m];
                                if ((op1.Equals('+') || op1.Equals('-')) && (op2.Equals('*') || op2.Equals('/')))
                                {
                                    if (op2.Equals('*'))
                                    {
                                        int result = j * n;
                                        if (op1.Equals('+'))
                                        {
                                            result = i + result;
                                        }
                                        if (op1.Equals('-'))
                                        {
                                            result = i - result;
                                        }
                                        if (result >= 0 && result <= 9)
                                        {
                                            arithmetics4.Add(new Arithmetic4(i, op1, j, op2, n, result));
                                        }
                                    }
                                    if (op2.Equals('/'))
                                    {
                                        if (n != 0)
                                        {
                                            if (j % n == 0)
                                            {
                                                int result = j / n;
                                                if (op1.Equals('+'))
                                                {
                                                    result = i + result;
                                                }
                                                if (op1.Equals('-'))
                                                {
                                                    result = i - result;
                                                }
                                                if (result >= 0 && result <= 9)
                                                {
                                                    arithmetics4.Add(new Arithmetic4(i, op1, j, op2, n, result));
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (op1.Equals('+'))
                                    {
                                        int result = i + j;
                                        if (op2.Equals('+'))
                                        {
                                            result = result + n;
                                        }
                                        if (op2.Equals('-'))
                                        {
                                            result = result - n;
                                        }
                                        if (result >= 0 && result <= 9)
                                        {
                                            arithmetics4.Add(new Arithmetic4(i, op1, j, op2, n, result));
                                        }
                                    }
                                    if (op1.Equals('-'))
                                    {
                                        int result = i - j;
                                        if (op2.Equals('+'))
                                        {
                                            result = result + n;
                                        }
                                        if (op2.Equals('-'))
                                        {
                                            result = result - n;
                                        }
                                        if (result >= 0 && result <= 9)
                                        {
                                            arithmetics4.Add(new Arithmetic4(i, op1, j, op2, n, result));
                                        }
                                    }
                                    if (op1.Equals('*'))
                                    {
                                        int result = i * j;
                                        if (op2.Equals('+'))
                                        {
                                            result = result + n;
                                        }
                                        if (op2.Equals('-'))
                                        {
                                            result = result - n;
                                        }
                                        if (op2.Equals('/'))
                                        {
                                            if (n != 0)
                                            {
                                                if (result % n == 0)
                                                {
                                                    result = result / n;
                                                }
                                                else
                                                {
                                                    result = -999;
                                                }
                                            }
                                            else
                                            {
                                                result = -999;
                                            }

                                        }
                                        if (op2.Equals('*'))
                                        {
                                            result = result * n;
                                        }
                                        if (result >= 0 && result <= 9)
                                        {
                                            arithmetics4.Add(new Arithmetic4(i, op1, j, op2, n, result));
                                        }
                                    }
                                    if (op1.Equals('/'))
                                    {
                                        if (j != 0)
                                        {
                                            if (i % j == 0)
                                            {
                                                int result = i * j;
                                                if (op2.Equals('+'))
                                                {
                                                    result = result + n;
                                                }
                                                if (op2.Equals('-'))
                                                {
                                                    result = result - n;
                                                }
                                                if (op2.Equals('/'))
                                                {
                                                    if (n != 0)
                                                    {
                                                        if (result % n == 0)
                                                        {
                                                            result = result / n;
                                                        }
                                                        else
                                                        {
                                                            result = -999;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        result = -999;
                                                    }

                                                }
                                                if (op2.Equals('*'))
                                                {
                                                    result = result * n;
                                                }
                                                if (result >= 0 && result <= 9)
                                                {
                                                    arithmetics4.Add(new Arithmetic4(i, op1, j, op2, n, result));
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return arithmetics4;
        }
    }
}
