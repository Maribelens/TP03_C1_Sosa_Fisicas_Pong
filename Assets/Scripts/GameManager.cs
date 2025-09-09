using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
public class GameManager : MonoBehaviour
{
    [SerializeField] BallMovement ballMovement;
    [SerializeField] TextMeshProUGUI textScoreP1;
    [SerializeField] TextMeshProUGUI textScoreP2;
    public int scoreP1 = 0;
    public int scoreP2 = 0;
    public int rondasAGanar = 3;

    [SerializeField] Canvas gameOver;
    [SerializeField] TextMeshProUGUI P1wins;
    [SerializeField] TextMeshProUGUI P2wins;

    //[SerializeField] private Canvas PrePanel;
    //[SerializeField] private TextMeshProUGUI textCuenta;
    //[SerializeField] private float timeBetweenNumbers = 1f;
    //public bool partidaIniciada = false;

    private void Start()
    {
        //StartCoroutine(CountDown());
    }

    //public IEnumerator CountDown()
    //{
    //    PrePanel.gameObject.SetActive(true);
    //    textCuenta.gameObject.SetActive(true);

    //    for (int i = 3; i > 0; i--)
    //    {
    //        textCuenta.text = i.ToString();
    //        yield return new WaitForSeconds(timeBetweenNumbers);
    //    }

    //    textCuenta.text = "YA!!!";
    //    yield return new WaitForSeconds(0.5f);

    //    PrePanel.gameObject.SetActive(false);
    //    textCuenta.gameObject.SetActive(false);
    //    partidaIniciada = true;
    //    Debug.Log("¡Partida iniciada!");
    //}

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            ballMovement.ResetAndLaunch();
            Time.timeScale = 1f;
        }
    }

    public void OnPlayerScored(int playerIndex)
    {
        ballMovement.ResetAndLaunch();
        if (playerIndex == 1)
        {
            AddPointsP1();

        }
        else if (playerIndex == 2)
        {
            AddPointsP2();
        }

        if (scoreP1 == rondasAGanar)
        {
            Time.timeScale = 0;
            Debug.Log("Player Nr1 es el ganador!!!");
            gameOver.gameObject.SetActive(true);
            P1wins.gameObject.SetActive(true);


        }
        else if (scoreP2 == rondasAGanar)
        {
            Time.timeScale = 0;
            Debug.Log("Player Nr2 es el ganador!!!");
            gameOver.gameObject.SetActive(true);
            P2wins.gameObject.SetActive(true);
        }
    }

    public void AddPointsP1()
    {
        scoreP1++;
        textScoreP1.text = scoreP1.ToString();
    }

    public void AddPointsP2()
    {
        scoreP2++;
        textScoreP2.text = scoreP2.ToString();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
