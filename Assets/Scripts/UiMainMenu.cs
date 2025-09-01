using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UiMainMenu : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelCredits;
    [SerializeField] private GameObject panelSettings;

    [Header("Buttons")]
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnOptions;
    [SerializeField] private Button btnCredits;
    [SerializeField] private Button btnExit;
    [SerializeField] private Button btnCreditsBack;
    [SerializeField] private Button btnSettingsBack;

    [Header("Settings Player 1")]
    [SerializeField] private InputMovement paddle1;
    [SerializeField] private Slider speedSliderP1;
    [SerializeField] private Slider heightSliderP1;
    //[SerializeField] private Slider p1R, p1G, p1B;
    [SerializeField] private TextMeshProUGUI speedText1 = null;

    [Header("Settings Player 2")]
    [SerializeField] private InputMovement paddle2;
    [SerializeField] private Slider heightSliderP2;
    [SerializeField] private Slider speedSliderP2;
    //[SerializeField] private Slider p2R, p2G, p2B;
    [SerializeField] private TextMeshProUGUI speedText2 = null;

    //private float initialValue = 7f;
    private bool showDecimalSpeed = true;
    private bool isPause;

    private void Awake()
    {
        btnPlay.onClick.AddListener(OnPlayClicked);
        btnOptions.onClick.AddListener(OnOptionsClicked);
        btnCredits.onClick.AddListener(OnCreditsClicked);
        btnExit.onClick.AddListener(OnExitClicked);
        btnCreditsBack.onClick.AddListener(OnCreditsBackClicked);
        btnSettingsBack.onClick.AddListener(OnSettingsBackClicked);

        speedSliderP1.onValueChanged.AddListener(OnSpeedP1Changed);
        heightSliderP1.onValueChanged.AddListener(OnHeightP1Changed);
        speedSliderP2.onValueChanged.AddListener(OnSpeedP2Changed);
        heightSliderP2.onValueChanged.AddListener(OnHeightP2Changed);
    }

    private void OnHeightP2Changed(float arg0)
    {
        throw new NotImplementedException();
    }

    private void OnHeightP1Changed(float arg0)
    {
        throw new NotImplementedException();
    }

    private void Start()
    {

        if (paddle1 != null)
        {
            speedSliderP1.value = paddle1.speed;
            heightSliderP1.value = paddle1.transform.localScale.y;
            //Color c1 = paddle1.GetComponent<SpriteRenderer>().color;
            //p1R.value = c1.r; p1G.value = c1.g; p1B.value = c1.b;
        }
        if (paddle2 != null)
        {
            speedSliderP2.value = paddle2.speed;
            heightSliderP2.value = paddle2.transform.localScale.y;
            //Color c2 = paddle2.GetComponent<SpriteRenderer>().color;
            //p2R.value = c2.r; p2G.value = c2.g; p2B.value = c2.b;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void OnDestroy()
    {
        btnPlay.onClick.RemoveAllListeners();
        btnOptions.onClick.RemoveAllListeners();
        btnCredits.onClick.RemoveAllListeners();
        btnExit.onClick.RemoveAllListeners();
        btnCreditsBack.onClick.RemoveAllListeners();
        btnSettingsBack.onClick.RemoveAllListeners();
        speedSliderP1.onValueChanged.RemoveAllListeners();
        speedSliderP2.onValueChanged.RemoveAllListeners();
        heightSliderP1.onValueChanged.RemoveAllListeners();
        heightSliderP2.onValueChanged.RemoveAllListeners();

    }

    private void TogglePause()
      {
          isPause = !isPause;
          panelPause.SetActive(isPause);
        if (isPause)
        {
            Time.timeScale = 0f;
            //player1.enabled = false;
            //player2.enabled = false;
        }
        else
        {
            Time.timeScale = 1f;
            //player1.enabled = true;
            //player2.enabled = true;
        }
    }


    public void OnPlayClicked()
    {
        TogglePause();
    }

    private void OnOptionsClicked()
    {
        panelSettings.SetActive(true);
    }

    private void OnCreditsClicked()
    {
        panelCredits.SetActive(false);
        panelCredits.SetActive(true);
    }
    private void OnExitClicked()
    {
        ExitGame();
    }

    private void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif 
    }

    private void OnCreditsBackClicked()
    {
        panelCredits.SetActive(false);
    }

    private void OnSettingsBackClicked()
    {
        panelSettings.SetActive(false);
    }
    private void OnSpeedP1Changed(float speed)
    {
        paddle1.speed = speed;
        if (showDecimalSpeed)
            speedText1.SetText(speed.ToString("1"));
        else
            speedText1.SetText(speed.ToString("15"));
    }

    private void OnSpeedP2Changed(float newSpeed)
    {
        paddle2.speed = newSpeed;
        if (showDecimalSpeed)
            speedText2.SetText(newSpeed.ToString("1"));
        else
            speedText2.SetText(newSpeed.ToString("15"));
    }

}
