using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Vector3 Scale { get; private set; }
    public Color Color { get; private set; } = Color.white;
    public float ExploadeChance { get; private set; } = 1f;
    public Rigidbody Rigidbody { get; private set; }

    public void Initialize(Vector3 scale, Color color, float exploadeChance, Rigidbody rigidbody)
    {
        Scale = scale;
        Color = color;
        ExploadeChance = exploadeChance;
        Rigidbody = rigidbody;
    }
}