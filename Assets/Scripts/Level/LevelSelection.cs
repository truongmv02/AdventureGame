using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private GameObject levelPrefab;
    [SerializeField] private GameObject levelLockPrefab;

    private void Start()
    {
        int levelCount = 3;
        int levelOpen = DataManager.Instance().GetLevelOpen();
        for (var i = 1; i <= levelCount; i++)
        {
            GameObject levelBtn;
            if (i <= levelOpen)
            {
                levelBtn = Instantiate(levelPrefab);
                var text = levelBtn.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                text.text = i.ToString();
                if (i == levelOpen && DataManager.Instance().GetLevel(levelOpen).Star < 1)
                {
                    levelBtn.GetComponent<Image>().color = Color.cyan;
                    levelBtn.transform.GetChild(1).gameObject.SetActive(false);
                    levelBtn.transform.GetChild(2).gameObject.SetActive(false);
                }
                var levelSelector = levelBtn.transform.GetComponent<LevelSelector>();
                levelSelector.Level = i;
            }
            else
            {
                levelBtn = Instantiate(levelLockPrefab);
                var btn = levelBtn.GetComponent<Button>();
                btn.interactable = false;
            }

            levelBtn.transform.SetParent(transform);
            levelBtn.name = i.ToString();
            levelBtn.transform.localScale = levelPrefab.transform.localScale;
            levelBtn.transform.rotation = levelPrefab.transform.rotation;

        }
    }
}