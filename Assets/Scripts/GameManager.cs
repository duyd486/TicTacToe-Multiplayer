using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    public void ClickedOnGridPosition(int x, int y)
    {
        Debug.Log("Click On " + x + ", " + y);
    }
}
