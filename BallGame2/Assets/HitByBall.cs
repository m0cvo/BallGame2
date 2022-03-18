using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitByBall : MonoBehaviour
{
    List<GameObject> targets;
	public GameObject prototypeObject;
	public int numberOfTargets;
    // Start is called before the first frame update
    void Start()
    {
        targets = new List<GameObject>();
		for(int i = 0; i<numberOfTargets; i++)
		{
			GameObject target = GameObject.Instantiate(prototypeObject);
			Transform targetTransform = target.GetComponent<Transform>();
			Vector3 v3 = targetTransform.position;
			float x = Random.Range(-4f, +4f);
			float z = Random.Range(-6f, +6f);
			v3.x = x;
			v3.z = z;
			targetTransform.position = v3;
			targets.Add(target);
		}
    }

    // Update is called once per frame
    void Update()
    {
		int count = 0;
        foreach(GameObject g in targets)
		{
			if(g.transform.position.y >= 10f)
			{
				count++;
				
			}
		}
		if(count > 0)
			Debug.Log("Targets hit " + count);
    }
}
