using GeneratorGameTasks;
using GeneratorGameTasks.Types;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task3x3Controller : MonoBehaviour
{
    private Arithmetic3x3 arithmetic3x3;
    private Dictionary<(int, int), int> fieldValues = new Dictionary<(int, int), int>();
    private HashSet<(int, int)> constFields = new HashSet<(int, int)>();
    private int constValuesCount = 6;
    private System.Random random = new System.Random();
    private (int, int) seletedBlock;
    private bool _decided = false;
    private int level = 1;
    void Awake()
    {
        TaskGenerator generator = new TaskGenerator();
        arithmetic3x3 = generator.GenerateArithmetic3x3();
        while (constFields.Count != constValuesCount)
        {
            int row = random.Next(1, 4);
            int col = random.Next(1, 4);
            if (!constFields.Contains((row, col)))
            {
                constFields.Add((row, col));
            }
            
        }
        foreach ((int, int) rowCol in constFields)
        {
            int val = 0;
            switch (rowCol.Item2) {
                case 1:
                    val = arithmetic3x3.rows[rowCol.Item1 - 1].val1;
                    break;
                case 2:
                    val = arithmetic3x3.rows[rowCol.Item1 - 1].val2;
                    break;
                case 3:
                    val = (int)arithmetic3x3.rows[rowCol.Item1 - 1].GetResult();
                    break;
                default:
                    break;
            }
            fieldValues.Add(rowCol, val);
        }
    }
    void Update()
    {
        if (!_decided)
        {
            _decided = true;
            for (int row = 1; row <= 3; row++)
            {
                for (int col = 1; col <= 3; col++)
                {
                    if (fieldValues.ContainsKey((row, col)))
                    {
                        if (IsError(row, col))
                        {
                            _decided = false;
                        }
                    }
                    else
                    {
                        _decided = false;
                    }

                }
            }
            if (_decided)
            {
                MassageBox.ShowMassage(this);
            }
        }
        transform.Find("Level").GetComponent<Text>().text = "Level " + level.ToString();
    }
    public string GetFieldValue(int row, int col)
    {
        if (fieldValues.ContainsKey((row, col)))
        {
            return fieldValues[(row, col)].ToString();
        }
        return "";
    }

    public string GetSignRow(int row)
    {
        return ArithmeticExpression3.ToString(arithmetic3x3.rows[row - 1].op);
    }

    public string GetSignCol(int col)
    {
        return ArithmeticExpression3.ToString(arithmetic3x3.cols[col - 1].op);
    }

    public void SetSelegtedBlock(int row, int col)
    {
        if (!constFields.Contains((row, col)))
        {
            seletedBlock = (row, col);
        }
    }

    public bool IsSelegtedBlock(int row, int col)
    {
        if (seletedBlock.Item1 == row && seletedBlock.Item2 == col)
        {
            return true;
        }
        return false;
    }

    public bool IsConstBlock(int row, int col)
    {
        if (constFields.Contains((row, col)))
        {
            return true;
        }
        return false;
    }

    public bool IsError(int row, int col)
    {
        bool allValueRowContains = true;
        bool allValueColContains = true;
        for (int i = 1; i <= 3; i++)
        {
            if (!fieldValues.ContainsKey((i, col)))
            {
                allValueColContains = false;
            }
            if (!fieldValues.ContainsKey((row, i)))
            {
                allValueRowContains = false;
            }
        }
        if ( allValueRowContains )
        {
            ArithmeticExpression3 arithmetic = arithmetic3x3.rows[row - 1];
            arithmetic.val1 = fieldValues[(row, 1)];
            arithmetic.val2 = fieldValues[(row, 2)];
            if (arithmetic.GetResult() != fieldValues[(row, 3)])
            {
                return true;
            }
        }
        if (allValueColContains)
        {
            ArithmeticExpression3 arithmetic = arithmetic3x3.cols[col - 1];
            arithmetic.val1 = fieldValues[(1, col)];
            arithmetic.val2 = fieldValues[(2, col)];
            if (arithmetic.GetResult() != fieldValues[(3, col)])
            {
                return true;
            }
        }
        return false;
    }
    public void SetNum(int num)
    {
        if (!seletedBlock.Equals((0, 0)))
        {
            if (!constFields.Contains(seletedBlock))
            {
                fieldValues[seletedBlock] = num;
                seletedBlock = (0, 0);
            }
        }
    }

    public void Restart()
    {
        seletedBlock = (0, 0);
        Dictionary<(int, int), int> newFieldValues = new Dictionary<(int, int), int>();
        foreach ((int, int) field in constFields)
        {
            newFieldValues.Add(field, fieldValues[field]);
        }
        fieldValues = newFieldValues;
        _decided = false;
    }

    public void NextTask()
    {
        TaskGenerator generator = new TaskGenerator();
        arithmetic3x3 = generator.GenerateArithmetic3x3();
        level++;
        if (level < 3)
        {
            constValuesCount = 5;
        }
        else if (level < 7)
        {
            constValuesCount = 4;
        }
        else
        {
            constValuesCount = 3;
        }
        Debug.Log(arithmetic3x3.ToString());
        constFields = new HashSet<(int, int)>();
        fieldValues = new Dictionary<(int, int), int>();
        seletedBlock = (0, 0);
        _decided = false;
        while (constFields.Count != constValuesCount)
        {
            int row = random.Next(1, 4);
            int col = random.Next(1, 4);
            if (!constFields.Contains((row, col)))
            {
                constFields.Add((row, col));
            }

        }
        foreach ((int, int) rowCol in constFields)
        {
            int val = 0;
            switch (rowCol.Item2)
            {
                case 1:
                    val = arithmetic3x3.rows[rowCol.Item1 - 1].val1;
                    break;
                case 2:
                    val = arithmetic3x3.rows[rowCol.Item1 - 1].val2;
                    break;
                case 3:
                    val = (int)arithmetic3x3.rows[rowCol.Item1 - 1].GetResult();
                    break;
                default:
                    break;
            }
            fieldValues.Add(rowCol, val);
        }
    }
}
