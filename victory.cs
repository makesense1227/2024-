using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class victory_scene : MonoBehaviour {
    public TMP_Text result_text;
    
    void Start() {
        int guess_count = PlayerPrefs.GetInt("guess_count", 0);
        result_text.text = "축하합니다!\n" + guess_count + "번 만에 맞추셨습니다!\n화면을 클릭해 다시 플레이!";
        Sender(guess_count);
    }
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene("Main_Scene");
        }
    }

    private string serverUrl = "https://hyunverse.kro.kr:3001/sendResult";

    public void Sender(int guess_count) 
    {
        Debug.Log("Sender()");

        DataSender dataSender = gameObject.AddComponent<DataSender>();
        DataSender.UserInfo userInfo = new DataSender.UserInfo {
            gameCode = 6, score = 20000 / guess_count
        };

        dataSender.SendDataToServer(serverUrl, userInfo);
    }
}

