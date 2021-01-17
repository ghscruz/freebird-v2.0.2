using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPrincipal : MonoBehaviour {

	private GameObject destino;

	float mouseX = 0;
	float mouseY = 0;

	private Transform transPivo;
	private Transform transCamera;

	private Vector3 posicaoOriginalCameraInterna;
	private float distancia;
	private Camera cam;

	void Start ()
	{
		destino = GameObject.FindGameObjectWithTag ("Player");
		transPivo = transform.Find ("pivo");
		transCamera = transform.GetChild (0).GetChild (0);
		posicaoOriginalCameraInterna = transCamera.localPosition;

		distancia = (transCamera.position - transPivo.position).magnitude;
		cam = transCamera.GetComponent<Camera> ();
	}

	void Update ()
	{
		transform.position = destino.transform.position;

		mouseX += Input.GetAxis ("Horizontal") * 0.3f;
		mouseY -= Input.GetAxis ("Vertical") * -0.3f;

		mouseY = Mathf.Clamp (mouseY, -50, 50);

		transPivo.rotation = Quaternion.Euler (mouseY, mouseX, 0);
	}
}

