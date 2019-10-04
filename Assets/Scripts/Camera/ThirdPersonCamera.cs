using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

	public Transform target;
	public Transform mainCamera;

	public float distance = 9.0f;
	public float currentX = 0.0f;
	public float currentY = 29.0f;
	public float sensitivityX = 4.0f;
	public float sensitivityY = 1.0f;

	public bool shaking;
	public bool startShake;
	public bool startLittleShake;

	void Start () {

		mainCamera = transform;
	}

	void Update () {
		if (startShake == true) {
			StartCoroutine(Shake(0.4f, 0.1f));
		} else if (startLittleShake == true) {
			StartCoroutine(Shake(0.2f, 0.05f));
		}
	}

	void LateUpdate () {

		Vector3 direction = new Vector3(0, 0, -distance);
		Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

		if (shaking == false) {
			mainCamera.position = target.position + rotation * direction;
		}
	}

	public IEnumerator Shake (float duration, float magnitude)
	{
		shaking = true;
		Vector3 originalPos = mainCamera.localPosition;

		float elapsed = 0.0f;

		while (elapsed < duration)
		{
			float x = Random.Range (-3, 3) * magnitude;
			float y = Random.Range (-3, 3) * magnitude;

			mainCamera.localPosition = new Vector3 (originalPos.x + x, originalPos.y + y, originalPos.z);

			elapsed += Time.deltaTime;

			yield return null;
		}

		mainCamera.localPosition = originalPos;
		shaking = false;
		startShake = false;
	}
}
