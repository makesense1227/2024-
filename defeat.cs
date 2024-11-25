using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class defeat_scene : MonoBehaviour {
    public TMP_Text resultText;

    void Start() {
        string answer = PlayerPrefs.GetString("answer", "None");
        resultText.text = "실패..\n정답은 " + answer + "이었습니다!\n화면을 클릭해 다시 플레이!";
        Sender();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene("Main_Scene");
        }
    }

    private string serverUrl = "https://hyunverse.kro.kr:3001/sendResult";
    
    public void Sender() {
        Debug.Log("Sender()");
        DataSender dataSender = gameObject.AddComponent<DataSender>();
        
        DataSender.UserInfo userInfo = new DataSender.UserInfo {
            gameCode = 6,
            score = 0
        };
        
        dataSender.SendDataToServer(serverUrl, userInfo);
    }
}
