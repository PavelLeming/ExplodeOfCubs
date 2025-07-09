using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _exploadeChance = 1f;
    public float ExploadeChance => _exploadeChance;

    public void DecreaseChance()
    {
        _exploadeChance /= 2;
    }
}
