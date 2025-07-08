using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private float _exploadeChance = 1f;
    private float _explosionPower = 500f;
    private int _chanceOfAdditionalCube = 25;

    private void OnMouseUpAsButton()
    {
        int hundredPercent = 100;
        int cutScale = 2;

        if (Random.value < _exploadeChance)
        {
            _cubePrefab.transform.localScale *= 0.5f;

            CreateCube(-1, 1, -1, cutScale);
            CreateCube(-1, 1, 1, cutScale);

            for (int j = -1; j <= 1; j += 2)
            {
                for (int k = -1; k <= 1; k += 2)
                {
                    if (Random.Range(0, hundredPercent) < _chanceOfAdditionalCube)
                    {
                        CreateCube(1, j, k, cutScale);
                    }
                }
            }

            Explode();
        }
        Destroy(gameObject);
    }

    private void CreateCube(int i, int j, int k, int cutScale)
    {
        Cube insantiate = Instantiate(_cubePrefab, transform.position + new Vector3(i * transform.localScale.x / cutScale,
            j * transform.localScale.x / cutScale, k * transform.localScale.x / cutScale), transform.rotation);
        insantiate.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
        insantiate._exploadeChance /= 2; 
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExpodableObjects())
        {
            explodableObject.AddExplosionForce(_explosionPower, transform.position, transform.localScale.x / 2);
        }
    }

    private List<Rigidbody> GetExpodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, transform.localScale.x / 2);

        List<Rigidbody> cubes = new List<Rigidbody>();

        foreach(Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }
}
