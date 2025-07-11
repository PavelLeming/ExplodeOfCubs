using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Exploader _exploader;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _raycaster.CubeTaped += ExploadeOfCube;
    }

    private void OnDisable()
    {
        _raycaster.CubeTaped -= ExploadeOfCube;
    }

    private void ExploadeOfCube(Cube cube)
    {
        if (UnityEngine.Random.value < cube.ExploadeChance)
        {
            List<Cube> cubes = _spawner.Spawn(cube);
            List<Rigidbody> rigidbodies = new List<Rigidbody>();

            foreach (var item in cubes)
            {
                rigidbodies.Add(item.Rigidbody);
            }

            _exploader.MakeExploadeOfCubes(cube, rigidbodies);
        }
        else
        {
            _exploader.MakeExploadeOfCubes(cube, _exploader.GetExplodableObjects(cube));
        }

        Destroy(cube.gameObject);
    }
}
