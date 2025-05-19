using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager Instance;
    public static bool IsHoldingItem = false;
    public static PickUpId pickUpId = PickUpId.None;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
