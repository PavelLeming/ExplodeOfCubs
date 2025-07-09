using UnityEngine;

public class Spavner : MonoBehaviour
{
    private float _exploadeChance = 1f;
    private int _chanceOfAdditionalCube = 25;

    public void Spavn(GameObject cube)
    {
        int hundredPercent = 100;
        int cutScale = 2;

        if (Random.value < _exploadeChance)
        {
            cube.transform.localScale /= 2;

            CreateCube(-1, 1, -1, cutScale, cube);
            CreateCube(-1, 1, 1, cutScale, cube);

            for (int j = -1; j <= 1; j += 2)
            {
                for (int k = -1; k <= 1; k += 2)
                {
                    if (Random.Range(0, hundredPercent) < _chanceOfAdditionalCube)
                    {
                        CreateCube(1, j, k, cutScale, cube);
                    }
                }
            }

            _exploadeChance /= 2;
        }
    }

    private void CreateCube(int i, int j, int k, int cutScale, GameObject cube)
    {
        GameObject insantiate = Instantiate(cube, cube.transform.position + new Vector3(i * cube.transform.localScale.x / cutScale,
            j * cube.transform.localScale.x / cutScale, k * cube.transform.localScale.x / cutScale), cube.transform.rotation);
        insantiate.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }
}
