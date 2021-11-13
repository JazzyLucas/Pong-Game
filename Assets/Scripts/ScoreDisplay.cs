using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    // Externals
    [SerializeField] private Image playerScoreImage;
    [SerializeField] private Image enemyScoreImage;

    private void Update()
    {
        Refresh();
    }

    public void Refresh()
    {
        playerScoreImage.fillAmount = 0f + GameManager.instance.playerScore / GameManager.instance.maxScore;
        enemyScoreImage.fillAmount = 0f + GameManager.instance.enemyScore / GameManager.instance.maxScore;
    }
}
