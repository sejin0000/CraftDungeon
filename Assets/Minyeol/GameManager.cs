using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumManager;
using UnityEngine.Pool;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    public ObjectPool objectPool;

    public PlayerController player;
    public CameraFollow cameraFollow;

    public Transform gameUICanvasTrans;

    public Stage currentStage = Stage.Stage1;

    [HideInInspector]
    public Room currentRoom;
    [HideInInspector]
    public ShopSO currentShopData;

    private void Start()
    {
        ChangeStageShopData();
    }

    private void Update()
    {
        // Test
        if(Input.GetKeyDown(KeyCode.Q))
        {
            // 중복 방지
            if(UIManager.Instance.GetPopup() != null)
            {
                if (UIManager.Instance.GetPopup().GetType() == typeof(UIShop))
                    return;
            }

            UIShop shopPopup = UIManager.Instance.ShowPopup<UIShop>();
            shopPopup.transform.SetParent(GameManager.Instance.gameUICanvasTrans, false);
        }
    }

    private void ChangeStageShopData()
    {
        string dataName = string.Concat(currentStage.ToString(), "_Shop");
        currentShopData = Resources.Load("ShopData/" + dataName, typeof(ShopSO)) as ShopSO;
    }

    public void OnPlayerMoveRoom(Room moveRoom)
    {
        cameraFollow.SetTarget(moveRoom.transform);
        currentRoom = moveRoom;
        currentRoom.SpawnEnemy();
    }
}
