using UnityEngine;
using UnityEngine.UI;

public class PauseLayer : MonoBehaviour
{

    [SerializeField] private Button replayeBtn;
    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button eixtBtn;

    [SerializeField] private Toggle soundToggle;
    [SerializeField] private Toggle musicToggle;
    private void Awake()
    {
        var buttons = transform.Find("Container").Find("Buttons");

        replayeBtn = buttons.Find("ReplayBtn").GetComponent<Button>();

        resumeBtn = buttons.Find("ResumeBtn").GetComponent<Button>();

        eixtBtn = buttons.Find("ExitBtn").GetComponent<Button>();

        var soundSetting = transform.Find("Container").Find("SoundSetting");

        soundToggle = soundSetting.Find("Sound").Find("Toggle").GetComponent<Toggle>();
        musicToggle = soundSetting.Find("Music").Find("Toggle").GetComponent<Toggle>();
    }

    private void Start()
    {
        replayeBtn.onClick.AddListener(GameManager.Instance.Replay);
        resumeBtn.onClick.AddListener(ResumeGame);
        eixtBtn.onClick.AddListener(Utility.GoToLevelScene);
    }

    public void ResumeGame()
    {
        GameManager.Instance.ResumeGame();
        gameObject.SetActive(false);
    }

}