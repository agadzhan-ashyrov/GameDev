using UnityEngine;
using UnityEngine.UI;

public class SignController : MonoBehaviour
{
    private Task3x3Controller _task3X3Controller;
    public Canvas mainCanvas;
    public int col;
    public int row;
    void Start()
    {
        _task3X3Controller = mainCanvas.gameObject.GetComponent<Task3x3Controller>();
        string sign;
        if ( row == 0 )
        {
            sign = _task3X3Controller.GetSignCol(col);
        }
        else
        {
            sign = _task3X3Controller.GetSignRow(row);
        }
        gameObject.GetComponent<Text>().text = sign;
    }

    void Update()
    {
        _task3X3Controller = mainCanvas.gameObject.GetComponent<Task3x3Controller>();
        string sign;
        if (row == 0)
        {
            sign = _task3X3Controller.GetSignCol(col);
        }
        else
        {
            sign = _task3X3Controller.GetSignRow(row);
        }
        gameObject.GetComponent<Text>().text = sign;
    }
}
