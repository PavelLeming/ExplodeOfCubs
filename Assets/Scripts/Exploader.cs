using System.Collections.Generic;
using UnityEngine;

public class Exploader : MonoBehaviour
{
    private float _explosionPower = 500f;

    public void MakeExploade(GameObject cube)
    {
        foreach (Rigidbody explodableObject in GetExpodableObjects(cube))
        {
            explodableObject.AddExplosionForce(_explosionPower, cube.transform.position, cube.transform.localScale.x / 2);
        }
    }

    private List<Rigidbody> GetExpodableObjects(GameObject cube)
    {
        Collider[] hits = Physics.OverlapSphere(cube.transform.position, cube.transform.localScale.x / 2);
        List<Rigidbody> cubes = new List<Rigidbody>();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }
}
