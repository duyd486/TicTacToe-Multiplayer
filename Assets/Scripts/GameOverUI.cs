using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Color winColor;
    [SerializeField] private Color loseColor;
    [SerializeField] private Color tieColor;
    [SerializeField] private Button rematchBtn;


    private void Awake()
    {
        rematchBtn.onClick.AddListener(() =>
        {
            GameManager.Instance.RematchRpc();
        });

    }
    private void Start()
    {
        Hide();
        GameManager.Instance.OnGameWin += GameManager_OnGameWin;
        GameManager.Instance.OnRematch += GameManager_OnRematch;
        GameManager.Instance.OnTied += GameManager_OnTied;
    }

    private void GameManager_OnTied(object sender, System.EventArgs e)
    {
        resultText.text = "TIED!!";
        resultText.color = tieColor;
        Show();
    }

    private void GameManager_OnRematch(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void GameManager_OnGameWin(object sender, GameManager.OnGameWinEventArgs e)
    {
        if (e.winPlayerType == GameManager.Instance.GetLocalPlayerType())
        {
            resultText.text = "YOU WIN!!";
            resultText.color = winColor;
        } else
        {
            resultText.text = "YOU LOSE!!";
            resultText.color = loseColor;
        }
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
