using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] Camera _camera;
    public event Action<Cube> CubeTaped;
    private Ray _ray;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(_ray, out hit, 20))
            {
                if (hit.rigidbody != null)
                {
                    GameObject hited = hit.collider.gameObject;
                    if (hited.TryGetComponent<Cube>(out Cube cube))
                    {
                        CubeTaped?.Invoke(cube);
                    }
                }
            }
        }
    }
}
