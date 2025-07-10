using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Cube> Spawn(Cube cube)
    {
        List<Cube> cubes = new List<Cube>();
        int cutScale = 2;
        int minimumCubes = 2;
        int maximumCubes = 6;
        int cubesCount = Random.Range(minimumCubes, maximumCubes);

        for (int i = -1; i <= 1; i += 2)
        { 
            for (int j = -1; j <= 1; j += 2)
            {
                for (int k = -1; k <= 1; k += 2)
                {
                    if (cubesCount != 0)
                    {
                        cubes.Add(CreateCube(i, j, k, cutScale, cube));
                        cubesCount--;
                    }
                }
            }
        }

        return cubes;
    }

    private Cube CreateCube(int xOffset, int yOffset, int zOffset, int cutScale, Cube cube)
    {
        Cube newCube = Instantiate(cube, cube.transform.position + new Vector3(xOffset * cube.transform.localScale.x / cutScale,
            yOffset * cube.transform.localScale.x / cutScale, zOffset * cube.transform.localScale.x / cutScale), cube.transform.rotation);
        newCube.Initialize(cube.transform.localScale / 2, new Color(Random.value, Random.value, Random.value), newCube.ExploadeChance / 2, newCube.GetComponent<Rigidbody>());
        newCube.transform.localScale = newCube.Scale;
        newCube.GetComponent<Renderer>().material.color = newCube.Color;

        return newCube;
    }
}
