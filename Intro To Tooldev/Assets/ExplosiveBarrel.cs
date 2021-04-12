using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class ExplosiveBarrel : MonoBehaviour
{
	public BarrelType type;

	public float Radius => type == null ? 1 : type.radius;
	public float Damage => type == null ? 0 : type.damage;
	public Color Color => type == null ? Color.white : type.color;


	MaterialPropertyBlock mpb;
	static readonly int shPropColor = Shader.PropertyToID("_Color");
	public MaterialPropertyBlock Mpb
	{
		get
		{
			if (mpb == null)
				mpb = new MaterialPropertyBlock();
			return mpb;
		}


	}

	public void ApplyColor()
	{
		MeshRenderer rnd = GetComponent<MeshRenderer>();
		Mpb.SetColor(shPropColor, Color);
		rnd.SetPropertyBlock(Mpb);
	}

	private void OnValidate()
	{
		ApplyColor();
	}
	private void OnEnable()
	{
		if(mpb == null)
		{
			mpb = new MaterialPropertyBlock();
		}
		ExplosiveBarrelManager.allTheBarrels.Add(this);
	}
	private void OnDisable()
	{
		ExplosiveBarrelManager.allTheBarrels.Remove(this);
	}

	private void OnDrawGizmosSelected()
	{
		Handles.color = Color;
		Handles.DrawWireDisc(transform.position, transform.up, Radius);
		Handles.color = Color.white;
		//Gizmos.DrawWireSphere(, radius);
	}
}
