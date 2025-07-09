using System.Collections.Generic;
using UnityEngine;

public class Exploader : MonoBehaviour
{
    [SerializeField] private Spavner _spavner;
    private float _explosionPower = 500f;

    private void OnEnable()
    {
        _spavner.CubeSplited += MakeExploade;
    }

    private void OnDisable()
    {
        _spavner.CubeSplited -= MakeExploade;
    }

    public void MakeExploade(Cube cube)
    {
        List<Rigidbody> _cubes = _spavner.GetCubes();

        foreach (Rigidbody explodableObject in _cubes)
        {
            explodableObject.AddExplosionForce(_explosionPower, cube.transform.position, cube.transform.localScale.x / 2);
        }
    }
}
