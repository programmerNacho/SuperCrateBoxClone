using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField]
    protected Transform shootPoint;

    public abstract void ButtonPressed(int directionX);
    public abstract void ButtonHold(int directionX);
    public abstract void ButtonUp(int directionX);
}
