using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasScore : MonoBehaviour
{
    public static CanvasScore instance;

    public TextMeshProUGUI scoreText;
    int score = 0;

    private void Awake()
    {
        instance = this;
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
