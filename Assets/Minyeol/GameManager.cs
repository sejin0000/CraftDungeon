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
    public int currentRoomClearPoint = 0;
    [HideInInspector]
    public ShopSO currentShopData;

    private void Start()
    {
        ChangeStageShopData();
    }

    private void Update()
    {
        if (!currentRoom.isClear)
        {
            if (currentRoomClearPoint == 0) 
            {
                currentRoom.isClear = true;
            }
        }
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

        if (Input.GetKeyDown(KeyCode.T))
        {
            currentRoom.OnClearRoom();
        }
    }

    private void ChangeStageShopData()
    {
        string dataName = string.Concat(currentStage.ToString(), "_Shop");
        currentShopData = Resources.Load("ShopData/" + dataName, typeof(ShopSO)) as ShopSO;
    }

    public void OnPlayerMoveRoom(Room moveRoom)
    {
        if (moveRoom.CompareTag("BossRoom"))
        {
            AudioClip bgmClip = SoundManager.Instance.GetOrAddAudioClip("AudioSource/bgm/bossRoombgm", SoundManager.Sound.bgm);
            AudioSource bgm = SoundManager.Instance.transform.GetChild(0).GetComponent<AudioSource>();
            bgm.clip = bgmClip;
            bgm.loop = true;
            bgm.volume = 0.3f;
            SoundManager.Instance.Play(bgm.clip, SoundManager.Sound.bgm);
        }
        cameraFollow.SetTarget(moveRoom.transform);
        currentRoom = moveRoom;
        currentRoomClearPoint = currentRoom.SpawnEnemy();
    }
}
