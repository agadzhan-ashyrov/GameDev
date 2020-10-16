using GeneratorGameTasks;
using GeneratorGameTasks.Types;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private GameObject _seletedBox;
    public Sprite selectedImage;
    public Sprite unselectedImage;
    void Start()
    {
        TaskGenerator generator = new TaskGenerator();
        Arithmetic3x3 arithmetic = generator.GenerateArithmetic3x3();
        Debug.Log(arithmetic.ToString());
        GameObject row1_1 = transform.Find("Row1-1").gameObject;
        row1_1.transform.Find("Text").GetComponent<Text>().text = arithmetic.rows[0].val1.ToString();
        GameObject row1_2 = transform.Find("Row1-2").gameObject;
        row1_2.transform.Find("Text").GetComponent<Text>().text = arithmetic.rows[0].val2.ToString();
        GameObject row1_3 = transform.Find("ResultRow-1").gameObject;
        row1_3.transform.Find("Text").GetComponent<Text>().text = arithmetic.rows[0].GetResult().ToString();
        GameObject row2_1 = transform.Find("Row2-1").gameObject;
        row2_1.transform.Find("Text").GetComponent<Text>().text = arithmetic.rows[1].val1.ToString();
        GameObject row2_2 = transform.Find("Row2-2").gameObject;
        row2_2.transform.Find("Text").GetComponent<Text>().text = arithmetic.rows[1].val2.ToString();
        GameObject row2_3 = transform.Find("ResultRow-2").gameObject;
        row2_3.transform.Find("Text").GetComponent<Text>().text = arithmetic.rows[1].GetResult().ToString();
        GameObject row3_1 = transform.Find("Row3-1").gameObject;
        row3_1.transform.Find("Text").GetComponent<Text>().text = arithmetic.rows[2].val1.ToString();
        GameObject row3_2 = transform.Find("Row3-2").gameObject;
        row3_2.transform.Find("Text").GetComponent<Text>().text = arithmetic.rows[2].val2.ToString();
        GameObject row3_3 = transform.Find("ResultRow-3").gameObject;
        row3_3.transform.Find("Text").GetComponent<Text>().text = arithmetic.rows[2].GetResult().ToString();
        transform.Find("OpRow-1").GetComponent<Text>().text = ArithmeticExpression3.ToString(arithmetic.rows[0].op);
        transform.Find("OpRow-2").GetComponent<Text>().text = ArithmeticExpression3.ToString(arithmetic.rows[1].op);
        transform.Find("OpRow-3").GetComponent<Text>().text = ArithmeticExpression3.ToString(arithmetic.rows[2].op);
        transform.Find("OpCol-1").GetComponent<Text>().text = ArithmeticExpression3.ToString(arithmetic.cols[0].op);
        transform.Find("OpCol-2").GetComponent<Text>().text = ArithmeticExpression3.ToString(arithmetic.cols[1].op);
        transform.Find("OpCol-3").GetComponent<Text>().text = ArithmeticExpression3.ToString(arithmetic.cols[2].op);
    }

    public void SelectBox(GameObject box)
    {
        Image image;
        if (_seletedBox)
        {
            image = _seletedBox.transform.Find("Image").GetComponent<Image>();
            image.sprite = unselectedImage;
            
        }
        _seletedBox = box;
        image = _seletedBox.transform.Find("Image").GetComponent<Image>();
        image.sprite = selectedImage;
    }

    public void GetSelectBox(GameObject box)
    {
        Image image;
        if (_seletedBox)
        {
            image = _seletedBox.transform.Find("Image").GetComponent<Image>();
            image.sprite = unselectedImage;
            
        }
        _seletedBox = box;
        image = _seletedBox.transform.Find("Image").GetComponent<Image>();
        image.sprite = selectedImage;
    }
}
