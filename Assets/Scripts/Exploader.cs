using System;
using System.Collections.Generic;
using UnityEngine;

public class Exploader : MonoBehaviour
{
    private float _explosionPower = 500f;
    private float _explosionRadius = 5f;

    public void MakeExploadeOfCubes(Cube cube, List<Rigidbody> rigidbodies)
    {
        foreach (Rigidbody explodableObject in rigidbodies)
        {
            if (explodableObject != cube.Rigidbody) 
            {
                Vector3 cubePostion = cube.transform.position;
                Vector3 objectPostion = explodableObject.transform.position;
                float powerModificator = _explosionRadius / Vector3.Distance(cubePostion, objectPostion);
                Debug.Log(powerModificator);
                if (powerModificator >= 1)
                {
                    explodableObject.AddExplosionForce(_explosionPower * (1 / cube.transform.localScale.x), cube.transform.position, cube.transform.localScale.x / 2);
                }
            }
        }
    }

    public List<Rigidbody> GetExplodableObjects(Cube cube)
    {
        Collider[] hits = Physics.OverlapSphere(cube.transform.position, _explosionRadius * (1 / cube.transform.localScale.x));

        List<Rigidbody> objects = new();

        foreach(Collider hit in hits)
        {
            if(hit.attachedRigidbody != null)
            {
                objects.Add(hit.attachedRigidbody);
            }
        }

        return objects;
    }
}
