
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace OpenAI
{
    public class ChatGPT : MonoBehaviour
    {
        [SerializeField] private InputField inputField;
        [SerializeField] private Button button;
        [SerializeField] private ScrollRect scroll;

        [SerializeField] private RectTransform sent;
        [SerializeField] private RectTransform received;

        private float height;
        private OpenAIApi openai = new OpenAIApi();

        // 직업, 역할, 성별, 나이, 성격, 특징, 상황 등 캐릭터를 학습 시키기 위한 정보를 작성
        // 작성된 정보를 바탕으로 npc가 대답함

        private string job = "매점주인";
        private string role = "매점주인";
        private string gender = "남성";
        private string age = "30대";
        private string personality = "친화력 좋음";
        private string traits = "캠핑장에 대해 잘 알고 있다. 캠핑장을 자주 방문한 손님. 캠핑장 내부 위치를 다 알고 있다. 안녕하세요라고 하면 안녕하세요라고 답한다.";
        private string situation = "매점에 물건을 사러온 손님이 말을거는 상황, 대화중";

        private List<ChatMessage> messages = new List<ChatMessage>();

        private void Start()
        {
            button.onClick.AddListener(SendReply);
        }

        private string CreateDynamicPrompt(string userMessage)
        {
            // 사용자의 입력에 따라 동적으로 prompt 생성
            if (userMessage.StartsWith("안녕하세요"))
            {
                // 안녕하세요로 시작하는 경우 프롬프트 생성하지 않음
                return null;
            }

            string dynamicPrompt = $"Act as this character, {{ 직업 : {job}, 캠핑장에서의 역할 : {role}, " +
                $"성별 : {gender}, 나이 : {age}, 성격 : {personality}, 특징 : {traits}, 상황 : {situation} }} " +
                $"10단어 이내로 말해. 제시된 정보를 나열해서 말하지는마. 주어지지지 않은 정보를 지어내지는마. " +
                "안녕하세요 라고 말하면 안녕하세요라고 말해. 매점의 물건들이 어디에있냐고 물어보면 해당 위치를말해. " +
                "Don't break character. Don't ever mention that you are an AI model.";

            return dynamicPrompt;
        }

        private async void SendReply()
        {
            var userMessage = inputField.text;

            var newMessage = new ChatMessage()
            {
                Role = "user",
                Content = userMessage
            };

            AppendMessage(newMessage);

            messages.Add(newMessage);

            button.interactable = false;
            inputField.text = "";
            inputField.interactable = false;

            // 동적으로 생성된 prompt 추가
            var dynamicPrompt = CreateDynamicPrompt(userMessage);
            if (dynamicPrompt != null)
            {
                var promptMessage = new ChatMessage()
                {
                    Role = "system",
                    Content = dynamicPrompt
                };
                messages.Add(promptMessage);
                AppendMessage(promptMessage);
            }

            var completionResponse = await openai.CreateChatCompletion(new CreateChatCompletionRequest()
            {
                Model = "gpt-3.5-turbo-0613",
                Messages = messages
            });

            if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
            {
                var message = completionResponse.Choices[0].Message;
                message.Content = message.Content.Trim();

                messages.Add(message);
                AppendMessage(message);
            }
            else
            {
                Debug.LogWarning("No text was generated from this prompt.");
            }

            button.interactable = true;
            inputField.interactable = true;
        }

        private void AppendMessage(ChatMessage message)
        {
            scroll.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);

            var item = Instantiate(message.Role == "user" ? sent : received, scroll.content);
            item.GetChild(0).GetChild(0).GetComponent<Text>().text = message.Content;
            item.anchoredPosition = new Vector2(0, -height);
            LayoutRebuilder.ForceRebuildLayoutImmediate(item);
            height += item.sizeDelta.y;
            scroll.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
            scroll.verticalNormalizedPosition = 0;
        }

        public struct ChatChoice
        {
            public string Logprobs { get; set; }
        }
    }
}