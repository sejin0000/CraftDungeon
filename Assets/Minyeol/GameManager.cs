using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumManager;

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

    public PlayerController player;
    public CameraFollow cameraFollow;

    public Transform gameUICanvasTrans;
    public Stage currentStage = Stage.Stage1;

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
            if (UIManager.Instance.GetPopup().name == "UIShop")
                return;
            UIShop shopPopup = UIManager.Instance.ShowPopup<UIShop>();
            shopPopup.transform.SetParent(GameManager.Instance.gameUICanvasTrans, false);
        }
    }

    private void ChangeStageShopData()
    {
        string dataName = string.Concat(currentStage.ToString(), "_Shop");
        currentShopData = Resources.Load("ShopData/" + dataName, typeof(ShopSO)) as ShopSO;
    }
}
