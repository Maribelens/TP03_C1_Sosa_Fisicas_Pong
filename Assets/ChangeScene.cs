using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private Button playButton;
    public void Awake()
    {
        playButton.onClick.AddListener(OnPlayClicked);
    }

    private void OnPlayClicked()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();        
    }
}
