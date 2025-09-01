using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] BallMovement ballMovement;

    // Update is called once per frame
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
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
