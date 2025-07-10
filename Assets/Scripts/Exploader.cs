using System.Collections.Generic;
using UnityEngine;

public class Exploader : MonoBehaviour
{
    private float _explosionPower = 500f;

    public void MakeExploade(Cube cube, List<Rigidbody> rigidbodies)
    {
        foreach (Rigidbody explodableObject in rigidbodies)
        {
            explodableObject.AddExplosionForce(_explosionPower, cube.transform.position, cube.transform.localScale.x / 2);
        }
    }
}
