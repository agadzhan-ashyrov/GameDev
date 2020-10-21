using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UI;

public class FieldController : MonoBehaviour
{
    private Task3x3Controller _task3X3Controller;
    public Canvas mainCanvas;
    public Sprite selectedSprite;
    public Sprite defaultSprite;
    public Sprite constSprite;
    public Sprite errorSprite;
    public int col = 0;
    public int row = 0;
    void Start()
    {
        _task3X3Controller = mainCanvas.gameObject.GetComponent<Task3x3Controller>();
        transform.Find("Text").GetComponent<Text>().text = _task3X3Controller.GetFieldValue(row, col);
        if (_task3X3Controller.IsConstBlock(row, col))
        {
            transform.Find("Image").GetComponent<Image>().sprite = constSprite;
        }
    }

    void Update()
    {
        transform.Find("Text").GetComponent<Text>().text = _task3X3Controller.GetFieldValue(row, col);
        Image image = transform.Find("Image").GetComponent<Image>();
        if (!_task3X3Controller.IsConstBlock(row, col))
        {
            if (_task3X3Controller.IsSelegtedBlock(row, col))
            {
                image.sprite = selectedSprite;
            }
            else
            {
                if (_task3X3Controller.IsError(row, col))
                {
                    image.sprite = errorSprite;
                }
                else
                {
                    image.sprite = defaultSprite;
                }
            }
        }
    }

    public void SelectBlock()
    {
        _task3X3Controller.SetSelegtedBlock(row, col);
    }
}
