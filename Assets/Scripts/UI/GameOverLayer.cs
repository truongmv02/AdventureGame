using UnityEngine;
using UnityEngine.UI;

public class GameOverLayer : MonoBehaviour
{

    [SerializeField] private Button replayeBtn;
    [SerializeField] private Button eixtBtn;
    private void Awake()
    {
        var buttons = transform.Find("Container").Find("Buttons");
        replayeBtn = buttons.Find("ReplayBtn").GetComponent<Button>();
        eixtBtn = buttons.Find("ExitBtn").GetComponent<Button>();
    }

    private void Start()
    {
        replayeBtn.onClick.AddListener(GameManager.Instance.Replay);
        eixtBtn.onClick.AddListener(Utility.GoToLevelScene);
    }
}