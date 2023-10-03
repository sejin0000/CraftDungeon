using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneUI : MonoBehaviour
{
    public Button startBtn;



    public void StartBtnClicked()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }
}
