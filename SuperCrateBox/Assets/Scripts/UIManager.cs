using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI pointsText;

    public void SetPointsText(int points)
    {
        pointsText.text = points.ToString();
    }
}
