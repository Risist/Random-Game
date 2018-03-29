using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHeightManager : MonoBehaviour {

	float spriteAlphaScale;
	public float spriteHeightTreshold;
	
	public struct HeightData
	{
		public Transform transform;
		public SpriteRenderer[] sprites;
		public float spriteMaxAlpha;
		public float heightOffset;
		public float turnoffDiff;
	}

	public void AddHeightObject( GameObject obj, float heightOffset, float turnoffDiff)
	{
		HeightData heightData = new HeightData();
		heightData.transform = obj.transform;
		heightData.sprites = obj.GetComponentsInChildren<SpriteRenderer>();
		heightData.spriteMaxAlpha = heightData.sprites[0].color.a;
		heightData.heightOffset = heightOffset;
		heightData.turnoffDiff = turnoffDiff;
		data.Add(heightData);
	}

	List<HeightData> data = new List<HeightData>();
	Transform player;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update () {

		for(int i = 0; i < data.Count; ++i)
			if(data[i].transform)
		{
			var dataIt = data[i];
			float difference = Mathf.Abs(player.position.z - dataIt.transform.position.z - dataIt.heightOffset);
			
			float treshold = spriteHeightTreshold + dataIt.turnoffDiff;
			if (difference < treshold)
			{
				float alphaScale = 1.0f / treshold;
				dataIt.transform.gameObject.SetActive(true);
				foreach (var it in dataIt.sprites)
					it.color = new Color(it.color.r, it.color.g, it.color.b, (1.0f - difference * alphaScale) * dataIt.spriteMaxAlpha);
			}else
				dataIt.transform.gameObject.SetActive(false);
		}else
		{
			data.Remove(data[i]);
			--i;
		}
	}
}
