using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//by Frieder
public class AchievementScreenController : MonoBehaviour
{
    public GameObject mainmenu;
    [SerializeField]
    private TextMeshProUGUI textfield;

    public void ShowAchievements(string achievements)
    {
        mainmenu.SetActive(false);
        gameObject.SetActive(true);
        textfield.text = achievements;
    }
    public void CloseAchievements()
    {
        gameObject.SetActive(false);
        mainmenu.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        textfield = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        gameObject.SetActive(false);
    }
}
