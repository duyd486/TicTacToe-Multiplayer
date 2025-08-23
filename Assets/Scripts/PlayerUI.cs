using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject crossArrowGameObject;
    [SerializeField] private GameObject circleArrowGameObject;
    [SerializeField] private GameObject crossYouGameObject;
    [SerializeField] private GameObject circleYouGameObject;
    [SerializeField] private TextMeshProUGUI crossScoreText;
    [SerializeField] private TextMeshProUGUI circleScoreText;

    private void Awake()
    {
        crossArrowGameObject.SetActive(false);
        circleArrowGameObject.SetActive(false);
        crossYouGameObject.SetActive(false);
        circleYouGameObject.SetActive(false);

        crossScoreText.text = "0";
        circleScoreText.text = "0";
    }

    private void Start()
    {
        GameManager.Instance.OnGameStarted += GameManager_OnGameStarted;
        GameManager.Instance.OnCurrentPlayablePlayerTypeChanged += GameManager_OnCurrentPlayablePlayerTypeChanged;
        GameManager.Instance.OnScoreChanged += GameManager_OnScoreChanged;
    }

    private void GameManager_OnScoreChanged(object sender, System.EventArgs e)
    {
        GameManager.Instance.GetScores(out int playerCrossScore, out int playerCircleScore);
        circleScoreText.text = playerCircleScore.ToString();
        crossScoreText.text = playerCrossScore.ToString();
    }

    private void GameManager_OnCurrentPlayablePlayerTypeChanged(object sender, System.EventArgs e)
    {
        UpdateCurrentArrow();
    }

    private void GameManager_OnGameStarted(object sender, System.EventArgs e)
    {
        if(GameManager.Instance.GetLocalPlayerType() == GameManager.PlayerType.Cross)
        {
            crossYouGameObject.SetActive(true);
        } else
        {
            circleYouGameObject.SetActive(true);
        }
        UpdateCurrentArrow();
    }
    private void UpdateCurrentArrow()
    {
        if(GameManager.Instance.GetCurrentPlayablePlayerType() == GameManager.PlayerType.Cross)
        {
            crossArrowGameObject.SetActive(true);
            circleArrowGameObject.SetActive(false);
        }
        else
        {
            circleArrowGameObject.SetActive(true);
            crossArrowGameObject.SetActive(false);
        }
    }
}
