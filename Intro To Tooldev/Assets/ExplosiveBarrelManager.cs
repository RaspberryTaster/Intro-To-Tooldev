using System.Collections;
using System.Collections.Generic;
using UnityEngine;
											
#if UNITY_EDITOR
using UnityEditor;
#endif
public class ExplosiveBarrelManager : MonoBehaviour
{
	public static List<ExplosiveBarrel> allTheBarrels = new List<ExplosiveBarrel>();
	public Color handlesColor = Color.white;

	public static void UpdateAllBarrelColors()
	{
		foreach(ExplosiveBarrel barrel in allTheBarrels)
		{
			barrel.ApplyColor();
		}
	}

	#if UNITY_EDITOR
	private void OnDrawGizmos()
	{

		foreach(ExplosiveBarrel barrel in allTheBarrels)
		{
			Handles.color = barrel.Color;
			Handles.DrawAAPolyLine(transform.position, barrel.transform.position);
		}
		Handles.color = Color.white; 
	}
	#endif
}
