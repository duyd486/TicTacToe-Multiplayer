using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Transform placeSfxPrefab;
    [SerializeField] private Transform winSfxPrefab;
    [SerializeField] private Transform loseSfxPrefab;



    private void Start()
    {
        GameManager.Instance.OnPlaceObject += GameManager_OnPlaceObject;
        GameManager.Instance.OnGameWin += GameManager_OnGameWin;
    }

    private void GameManager_OnGameWin(object sender, GameManager.OnGameWinEventArgs e)
    {
        if(GameManager.Instance.GetLocalPlayerType() == e.winPlayerType)
        {
            PlaySfx(winSfxPrefab);
        } else
        {
            PlaySfx(loseSfxPrefab);
        }
    }

    private void GameManager_OnPlaceObject(object sender, System.EventArgs e)
    {
        PlaySfx(placeSfxPrefab);
    }

    private void PlaySfx(Transform sfxPrefab)
    {
        Transform sfxTransform = Instantiate(sfxPrefab);
        Destroy(sfxTransform.gameObject, 5f);
    }
}
