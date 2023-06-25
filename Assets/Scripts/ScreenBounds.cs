using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    public static float screenLeftBound;
    public static float screenRightBound;
    public static float screenTopBound;
    public static float screenBottomBound;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;


        screenLeftBound = mainCamera.ViewportToWorldPoint(Vector3.zero).x;
        screenRightBound = mainCamera.ViewportToWorldPoint(Vector3.right).x;
        screenTopBound = mainCamera.ViewportToWorldPoint(Vector3.up).y;
        screenBottomBound = mainCamera.ViewportToWorldPoint(Vector3.zero).y;
    }

    private void Update()
    {
    }
}
