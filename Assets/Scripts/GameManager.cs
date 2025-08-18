using UnityEngine;

public class GameManager : MonoBehaviour
{
    

    public void ClickedOnGridPosition(int x, int y)
    {
        Debug.Log("Click On " + x + ", " + y);
    }
}
