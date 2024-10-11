using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public float camTranslateSpeed;
    public float targetXPosition, targetYPosition, targetZPosition;
    private string[] tagsToDestroy = { "SpawnPoint", "Enemy" };

    void Start()
    {
        camTranslateSpeed = 20f;
        targetXPosition = 28.8f;
        targetYPosition = 16.8f;
        targetZPosition = 34.6f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroyObjectsWithTags();
        StartCoroutine(MoveCameraToPosition(new Vector3(targetXPosition, targetYPosition, targetZPosition)));
        gameObject.transform.position = new Vector3(0, -50, 0);
    }

    public void OnButtonClick()
    {
        DestroyObjectsWithTags();
        StartCoroutine(StartOverScreen());
    }

    private void DestroyObjectsWithTags()
    {
        foreach (string tag in tagsToDestroy)
        {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject obj in objectsWithTag)
            {
                Destroy(obj);
            }
        }
    }

    private IEnumerator StartOverScreen()
    {
        yield return StartCoroutine(MoveCameraToPosition(new Vector3(targetXPosition, targetYPosition, targetZPosition)));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator MoveCameraToPosition(Vector3 targetPosition)
    {
        while (Vector3.Distance(Camera.main.transform.position, targetPosition) > 0.01f)
        {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, targetPosition, camTranslateSpeed * Time.deltaTime);
            yield return null;
        }

        Camera.main.transform.position = targetPosition;
    }
}
