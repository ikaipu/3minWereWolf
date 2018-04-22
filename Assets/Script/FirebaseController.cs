using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;

namespace Assets.Script
{
    public class FirebaseController : MonoBehaviour
    {
        private DatabaseReference _reference;
        private string _gameId;

        private void Start()
        {
            Debug.Log("called Start");
            // Set this before calling into the realtime database.
            FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://werewolf-7fae8.firebaseio.com/");
            _reference = FirebaseDatabase.DefaultInstance.RootReference;
        }

        public void SetPlayers(PlayerModel[] playerArray)
        {
            _gameId = _reference.Child("games").Push().Key;
            var json = "{";
            for (var i = 0;i < playerArray.Length; i++)
            {
                var jsonPlayer = JsonUtility.ToJson(playerArray[i]);
                json += "\"" + playerArray[i].id + "\":" + jsonPlayer + (i == playerArray.Length - 1 ? "" : ",");
            }

            json += "}";
            Debug.Log(json);
            _reference.Child("games").Child(_gameId).Child("players").SetRawJsonValueAsync(json).ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.Log(task.Exception.Message);
                }
                if (task.IsCompleted)
                {
                    Debug.Log("complete");
                }
            });
        }
    }
}