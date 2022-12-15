#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.Events;
using UdonSharpEditor;
using VRC.Udon;

public class EditorButtonEditor : EditorWindow
{
    [MenuItem("My Window/Add Button Function")]
    public static void AddButtonFunction()
    {
        // ゲームオブジェクトCanvasを検索
        var scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        GameObject Canvas = null;
        foreach (var obj in scene.GetRootGameObjects())
        {
            if (obj.name == "Canvas") Canvas = obj;
        }
        // スクリプトEditorButtonScriptを取得
        var EditorButtonScript = Canvas.GetComponent<EditorButtonScript>();
        // ゲームオブジェクトButtonを検索
        var Button = Canvas.transform.Find("Button").gameObject;
        // ボタンイベントを登録
        SetButtonClickEvent(Canvas, Button, EditorButtonScript, "OnClick");
    }

    static void SetButtonClickEvent(GameObject obj, GameObject buttonObj, MonoBehaviour script, string eventName)
    {
        var button = buttonObj.GetComponent<UnityEngine.UI.Button>();
        UdonBehaviour backingBehaviour = UdonSharpEditorUtility.GetBackingUdonBehaviour((UdonSharp.UdonSharpBehaviour)script);
        UnityEventTools.RemovePersistentListener<string>(button.onClick, backingBehaviour.SendCustomEvent);
        UnityEventTools.AddStringPersistentListener(button.onClick, backingBehaviour.SendCustomEvent, eventName);
    }
}
#endif
