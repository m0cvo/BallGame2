using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ToggleActivation : MonoBehaviour
{
	public bool hit = false;
	Transform targetsTransform;
	
    // Start is called before the first frame update
    void Start()
    {
        targetsTransform = gameObject.transform;
    }
	
    // Update is called once per frame
    void Update()
    {
		if(hit && targetsTransform.position.y < 10)
		{
			Vector3 v3 = targetsTransform.position;
			v3.y += Time.deltaTime;
			targetsTransform.position = v3;
		}
		else
		{
			if(targetsTransform.position.y  >= 10)
			{
				this.gameObject.SetActive(false);				
			}
		}
    }
	public void OnTriggerEnter(Collider other)
	{
		//Debug.Log(other.gameObject.name);
		//his.gameObject.SetActive(false);
		hit = true; 
	}
}
