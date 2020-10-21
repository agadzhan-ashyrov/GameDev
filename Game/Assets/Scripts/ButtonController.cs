using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Canvas mainCanvas;
    private Task3x3Controller _task3X3Controller;
    void Start()
    {
        _task3X3Controller = mainCanvas.gameObject.GetComponent<Task3x3Controller>();
    }
    public void SetNumber(int num)
    {
        _task3X3Controller.SetNum(num);
    }
}
