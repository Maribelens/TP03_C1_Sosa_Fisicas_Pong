using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private int playerIndex;
    [SerializeField] private GameManager gmManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            gmManager.OnPlayerScored(playerIndex);
        }

    }

}
