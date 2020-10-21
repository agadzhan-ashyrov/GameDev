using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MassageBox : MonoBehaviour
{
    private static MassageBox instance;
    public GameObject template;
    void Awake()
    {
        instance = this;
    }

    public static void ShowMassage(Task3x3Controller controller)
    {
        GameObject massageBox = Instantiate(instance.template);

        Transform panel = massageBox.transform.Find("Panel");
        Button next = panel.Find("Next").GetComponent<Button>();
        Button mainMenu = panel.Find("MainMenu").GetComponent<Button>();
        Button repeat = panel.Find("Repeat").GetComponent<Button>();

        next.onClick.AddListener(() =>
        {
            controller.NextTask();
            Destroy(massageBox);
        });
        mainMenu.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainMenu");
            Destroy(massageBox);
        });
        repeat.onClick.AddListener(() =>
        {
            
            controller.Restart();
            Destroy(massageBox);
        });
    }
}
