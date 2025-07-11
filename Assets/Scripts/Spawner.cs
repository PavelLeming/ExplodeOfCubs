using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Cube> Spawn(Cube cube)
    {
        List<Cube> cubes = new List<Cube>();
        int cutScale = 4;
        int minimumCubes = 2;
        int maximumCubes = 6;
        int cubesCount = Random.Range(minimumCubes, maximumCubes);

        for (int xOffset = -1; xOffset <= 1; xOffset += 2)
        { 
            for (int yOffset = -1; yOffset <= 1; yOffset += 2)
            {
                for (int zOffset = -1; zOffset <= 1; zOffset += 2)
                {
                    if (cubesCount != 0)
                    {
                        cubes.Add(CreateCube(xOffset, yOffset, zOffset, cutScale, cube));
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
