using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public int score; //Puntaje actual
    public TextMeshProUGUI scoreText; //Referencia al texto UI para mostrar el puntaje

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Actualizar el texto del puntaje en cada frame
        scoreText.text = "Score: " + score.ToString();

    }
}
