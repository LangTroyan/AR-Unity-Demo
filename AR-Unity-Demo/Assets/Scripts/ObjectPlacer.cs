using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{

    public GameObject gameObjectPrefab;
    private List<GameObject> gameObjects = new List<GameObject>();

    void Update()
    {
        if(Input.touchCount == 0)
        {
            return;
        }
        else if (Input.GetTouch(0).phase == TouchPhase.Began)
        {

            // Construct a ray from the current touch coordinates
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            // Create a particle if hit
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.gameObject.CompareTag("Plane"))
                {
                    gameObjects.Add(Instantiate(gameObjectPrefab, hit.point, hit.transform.rotation));
                }
            }
        }
    }
}
