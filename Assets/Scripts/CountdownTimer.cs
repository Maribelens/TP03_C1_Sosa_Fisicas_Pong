using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public float tiempoInicial = 20f;
    private float tiempoRestante;

    public TextMeshProUGUI textoUI;

    private void Start()
    {
        tiempoRestante = tiempoInicial;
    }
    private void Update()
    {
        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            if (tiempoRestante < 0)
            {
                tiempoRestante = 0;
            }
        }
        if (tiempoRestante <= 0)
        {
            Debug.Log("Tiempo Terminado");
        }
    }
}
