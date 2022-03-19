using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class HitByBall : MonoBehaviour
{
    List<GameObject> targets;
	public GameObject prototypeObject;
	public GameObject playButton;
	public int numberOfTargets;
	public Text collectedText, timeText, bestTimeText;
	public GameObject congratsPanel;
	public Text wellDoneText;
	float timeNow;
	float bestTime;
	bool done;
	TextReader textReader;
	TextWriter textWriter;
    // Start is called before the first frame update
    void Start()
    {
		textReader = new StreamReader("GameData.txt");
		string input = textReader.ReadLine();
		string[] parts = input.Split(',');
		bestTime = (float)double.Parse(parts[1]);
		textReader.Close();
		bestTimeText.text = "Best time " + bestTime;
		playButton.SetActive(false);
        targets = new List<GameObject>();
		timeNow = 0;
		done = false;
		//dummy best time
		
		for(int i = 0; i<numberOfTargets; i++)
		{
			GameObject target = GameObject.Instantiate(prototypeObject);
			SetPosition(target);			
			targets.Add(target);
		}
    }
	
	void SetPosition(GameObject g)
	{
		Transform targetTransform = g.GetComponent<Transform>();
		Vector3 v3 = targetTransform.position;
		float x = Random.Range(-4f, +4f);
		float z = Random.Range(-6f, +6f);
		v3.x = x;
		v3.z = z;
		v3.y = 0.3f;
		targetTransform.position = v3;
	}
	
	public void OnClickPlayButton()
	{	
		if(congratsPanel.activeSelf)
			congratsPanel.SetActive(false);
		for(int i=0; i < targets.Count; i++)
		{			
			Destroy(targets[i]);
		}
		targets.Clear();
		for(int i = 0; i<numberOfTargets; i++)
		{
			GameObject target = GameObject.Instantiate(prototypeObject);
			SetPosition(target);			
			targets.Add(target);
		}
		done = false;
		timeNow = 0;
		playButton.SetActive(false);
		collectedText.text = "Collected ";
	}

    // Update is called once per frame
    void Update()
    {
		if(!done )
		{	
			timeNow += Time.deltaTime;
				
			int t = (int)timeNow;
			int tTenths = (int)((timeNow - t) * 10);
			timeText.text = "Time " + t + "." + tTenths;
			int count = 0;
			foreach(GameObject g in targets)
			{
				if(g.transform.position.y >= 10f)
				{
					count++;				
				}
			}
			if(count > 0)
			{
				collectedText.text = "Collected " + count;
				if(count == numberOfTargets)
				{
					if(timeNow < bestTime)
					{
						bestTime = timeNow;
						string bestTimeAsText = t + "." + tTenths;
						bestTimeText.text = "Best Time: " + bestTimeAsText;				
						congratsPanel.SetActive(true);
						//collectedText.text += "\nYou have a new best time!!";
						wellDoneText.text = "Congratulations you have a new best time of " + bestTimeAsText;
					textWriter = new StreamWriter("GameData.txt");
					textWriter.WriteLine("Best time, " + bestTimeAsText);
					textWriter.Close();
					}
					playButton.SetActive(true);
					done = true;
					
				}
			}
		}
    }
	
}
