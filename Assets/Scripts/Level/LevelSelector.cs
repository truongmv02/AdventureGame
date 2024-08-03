using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int Level { set; get; }

    private void Start()
    {
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(() => SceneManager.LoadScene("Level_" + Level.ToString()));
        PlayerPrefs.SetInt("LevelSelected", Level);
        SetStar();
    }

    private void SetStar()
    {
        var level = DataManager.Instance().GetLevel(Level);
        if (level == null) return;
        int star = level.Star;
        var starObject = transform.Find("Star");

        switch (star)
        {

            case 0:
            starObject.gameObject.SetActive(false);
            break;
            case 1:
            starObject.GetChild(1).gameObject.SetActive(false);
            starObject.GetChild(2).gameObject.SetActive(false);
            break;
            case 2:
            starObject.GetChild(2).gameObject.SetActive(false);
            break;
        }

    }
}