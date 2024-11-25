using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_change : MonoBehaviour {
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene("Main_Scene");
        }
    }
}