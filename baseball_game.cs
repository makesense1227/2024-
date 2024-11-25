using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class baseball_game_manager : MonoBehaviour {
    public TMP_Text result_text;
    public Button submit_button;
    public TMP_InputField input_field;
    public string target_number;
    public int attempt;

    void Start() {
        make_target_number();
        attempt = 0;
        submit_button.onClick.AddListener(check_attempt);
        result_text.text = "";
        if (inputField != null) {
            inputField.gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(inputField.gameObject);
        }
    }

    void make_target_number() {
        target_number = "";
        while (target_number.Length < 3) {
            char digit = (char)('0' + Random.Range(0, 10));
            if (!target_number.Contains(digit.ToString())) {
                target_number += digit;
            }
        }
        Debug.Log("Target Number: " + target_number);
    }

    void check_attempt() {
        string guess = input_field.text;
        
        if (guess.Length != 3) {
            result_text.text = "세 자리 숫자를 입력하세요.";
            return;
        }

        attempt++;
        int strike = 0, ball = 0;

        for (int i = 0; i < 3; i++) {
            if (guess[i] == target_number[i]) {
                strike++;
            }
            else if (target_number.Contains(guess[i].ToString())) {
                ball++;
            }
        }

        if (strike == 3) {
            PlayerPrefs.SetInt("guess_count", attempt);
            SceneManager.LoadScene("Victory_Scene");
        }
        else if (attempt >= 9) {
            PlayerPrefs.SetString("answer", target_number);
            SceneManager.LoadScene("Defeat_Scene");
        }
        else {
            result_text.text = $"<color=#000000>{attempt}회 \n</color>" + $"<color=#FF0000>{strike} Strike </color>" + $"<color=#00FF00>{ball} Ball</color>";
        }

        input_field.text = "";
    }
}

