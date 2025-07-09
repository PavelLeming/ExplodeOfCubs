using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spavner : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    public event Action<Cube> CubeSplited;
    private int _chanceOfAdditionalCube = 25;
    private List<Rigidbody> _cubes = new List<Rigidbody>();

    private void OnEnable()
    {
        _raycaster.CubeTaped += Spavn;
    }

    private void OnDisable()
    {
        _raycaster.CubeTaped -= Spavn;
    }

    public void Spavn(Cube cube)
    {
        int hundredPercent = 100;
        int cutScale = 2;

        if (UnityEngine.Random.value < cube.ExploadeChance)
        {
            cube.transform.localScale /= 2;
            cube.DecreaseChance();

            CreateCube(-1, 1, -1, cutScale, cube);
            CreateCube(-1, 1, 1, cutScale, cube);

            for (int j = -1; j <= 1; j += 2)
            {
                for (int k = -1; k <= 1; k += 2)
                {
                    if (UnityEngine.Random.Range(0, hundredPercent) < _chanceOfAdditionalCube)
                    {
                        CreateCube(1, j, k, cutScale, cube);
                    }
                }
            }

            CubeSplited?.Invoke(cube);
        }
    }

    private void CreateCube(int i, int j, int k, int cutScale, Cube cube)
    {
        GameObject insantiate = Instantiate(cube.gameObject, cube.transform.position + new Vector3(i * cube.transform.localScale.x / cutScale,
            j * cube.transform.localScale.x / cutScale, k * cube.transform.localScale.x / cutScale), cube.transform.rotation);
        _cubes.Add(insantiate.GetComponent<Rigidbody>());
        insantiate.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }

    public List<Rigidbody> GetCubes()
    {
        return _cubes.ToList();
    }
}
