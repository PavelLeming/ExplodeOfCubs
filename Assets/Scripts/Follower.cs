using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Spavner _spavner;
    [SerializeField] private Exploader _exploader;

    private void OnEnable()
    {
        _raycaster.CubeTaped += ExploadeCube;
    }

    private void OnDisable()
    {
        _raycaster.CubeTaped -= ExploadeCube;
    }

    private void ExploadeCube(GameObject cube)
    {
        _spavner.Spavn(cube);
        _exploader.MakeExploade(cube);
    }
}
