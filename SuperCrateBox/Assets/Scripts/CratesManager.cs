using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CratesManager : MonoBehaviour
{
    [System.Serializable]
    public struct Line
    {
        public GameObject point1;
        public GameObject point2;
    }

    [HideInInspector]
    public int points;

    public List<Line> spawnLines;
    public Crate cratePrefab;
    public UIManager uiManager;

    private void Start()
    {
        points = 0;
        uiManager.SetPointsText(points);
        CreateCrate();
    }

    public void CreateCrate()
    {
        Line randomLine = spawnLines[Random.Range(0, spawnLines.Count)];

        Vector2 randomPosition = Vector2.Lerp(randomLine.point1.transform.position, randomLine.point2.transform.position, Random.Range(0f, 1f));

        Crate crateCreated = Instantiate(cratePrefab, randomPosition, Quaternion.identity);
        crateCreated.OnPickUp.AddListener(CratePickedUp);
    }

    private void CratePickedUp()
    {
        points++;
        uiManager.SetPointsText(points);
        CreateCrate();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        foreach (Line line in spawnLines)
        {
            Gizmos.DrawLine(line.point1.transform.position, line.point2.transform.position);
        }
    }
}
