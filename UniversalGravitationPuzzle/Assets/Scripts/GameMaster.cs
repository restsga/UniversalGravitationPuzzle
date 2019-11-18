using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public GameObject planet_parent;
    public GameObject satellite_prefab;

	// Use this for initialization
	void Start () {
        List<GameObject> list = new List<GameObject>();
		foreach(Transform childTransform in planet_parent.transform)
        {
            list.Add(childTransform.gameObject);
        }
        Satellite.planets= list.ToArray();
	}

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0f;
            Vector3 worldPos= Camera.main.ScreenToWorldPoint(mousePos);
            CreateSatellite(new Vector2(worldPos.x, worldPos.y));
        }
    }

    private void FixedUpdate()
    {
    }

    private void CreateSatellite(Vector2 firstForce)
    {
        GameObject satellite = Instantiate(satellite_prefab);

        satellite.GetComponent<Rigidbody2D>().AddForce(firstForce/1000, ForceMode2D.Impulse);
    }
}
