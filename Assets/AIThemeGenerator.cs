using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class AIThemeGenerator : MonoBehaviour
{
    public TMP_InputField themeInput;
    public TextMeshProUGUI resultText;

    public CarColorChanger colorChanger;
    public WheelCustomizer wheelCustomizer;

    string apiUrl = "https://api.openai.com/v1/chat/completions";
    string apiKey = "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";


    [System.Serializable]
    public class Message
    {
        public string role;
        public string content;
    }

    [System.Serializable]
    public class RequestData
    {
        public string model;
        public Message[] messages;
    }

    [System.Serializable]
    public class ChoiceMessage
    {
        public string content;
    }

    [System.Serializable]
    public class Choice
    {
        public ChoiceMessage message;
    }

    [System.Serializable]
    public class AIResponse
    {
        public Choice[] choices;
    }

    [System.Serializable]
    public class CarConfig
    {
        public string color;
        public string wheel;
    }


    public void GenerateTheme()
    {
        StartCoroutine(CallAI());
    }


    IEnumerator CallAI()
    {
        string theme = themeInput.text;

        string prompt =
        "For theme '" + theme + "' suggest a car configuration. " +
        "Return ONLY JSON like this: " +
        "{\"color\":\"red|blue|black|white\",\"wheel\":\"sport|luxury|minimal\"}";

        RequestData requestData = new RequestData();
        requestData.model = "gpt-4o-mini";
        requestData.messages = new Message[]
        {
            new Message { role = "user", content = prompt }
        };

        string json = JsonUtility.ToJson(requestData);

        UnityWebRequest request = new UnityWebRequest(apiUrl, "POST");

        byte[] body = System.Text.Encoding.UTF8.GetBytes(json);

        request.uploadHandler = new UploadHandlerRaw(body);
        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + apiKey);

        yield return request.SendWebRequest();


        if (request.result != UnityWebRequest.Result.Success)
        {
            resultText.text = "AI Error: " + request.error;
            yield break;
        }


        string response = request.downloadHandler.text;


        try
        {
            AIResponse aiResponse = JsonUtility.FromJson<AIResponse>(response);

            string content = aiResponse.choices[0].message.content;

            CarConfig config = JsonUtility.FromJson<CarConfig>(content);

            ApplyConfig(config);

            resultText.text =
                "AI chose: " + config.color + " car with " + config.wheel + " wheels";
        }
        catch
        {
            resultText.text = "AI response parsing failed";
        }
    }



    void ApplyConfig(CarConfig config)
    {
        if (config.color == "red") colorChanger.SetRed();
        if (config.color == "blue") colorChanger.SetBlue();
        if (config.color == "black") colorChanger.SetBlack();
        if (config.color == "white") colorChanger.SetWhite();


        if (config.wheel == "sport") wheelCustomizer.SportyWheels();
        if (config.wheel == "luxury") wheelCustomizer.LuxuryWheels();
        if (config.wheel == "minimal") wheelCustomizer.MinimalWheels();
    }
}