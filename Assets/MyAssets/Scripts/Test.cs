using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private TextMeshProUGUI text;

    public void Start()
    {
        CreateCanvas();
        DumpHierarchy();
    }

    private void CreateCanvas() {
        Debug.Log("UI Test desde BepInEx IL2CPP");

        // Buscar canvas existente o crear uno
        //Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        Canvas canvas = null;
        if (canvas == null)
        {
            var canvasGO = new GameObject("BepInExCanvas");
            canvas = canvasGO.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            canvasGO.AddComponent<CanvasScaler>();
            canvasGO.AddComponent<GraphicRaycaster>();
        }

        // Crear GO para el texto
        var textGO = new GameObject("MyText");
        textGO.transform.SetParent(canvas.transform, false);

        // Guardar referencia en el campo privado
        text = textGO.AddComponent<TextMeshProUGUI>();

        // Setear propiedades
        text.text = "hello world!!!!";
        text.fontSize = 81.62f;
        text.color = new Color32(0xE7, 0x1D, 0xCE, 0xFF); // pink color
        text.alignment = TextAlignmentOptions.Center;

        // Ajustar rect
        var rect = text.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(600, 200);
        rect.anchoredPosition = new Vector2(0, 0);
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, 140f);
    }

    private void DumpHierarchy()
    {
        var scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;
        Debug.Log("[MyGamePlugin] Scene name: " + sceneName);

        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        Canvas canvas2 = UnityEngine.Object.FindObjectOfType<Canvas>();
        Canvas canvas3 = Object.FindObjectOfType<Canvas>();
        GameObject.FindObjectOfType<Canvas>();

        var roots = scene.GetRootGameObjects();


        foreach (var root in roots)
        {
            DumpTransformRecursive(root.transform, 0);
        }

    }

    private void DumpTransformRecursive(Transform t, int depth)
    {
        string indent = new string(' ', depth * 2);
        // aca podrias usar Debug.Log tambien si queres que salga como [Message: Unity]
        Debug.Log(indent);

        foreach (Transform child in t)
        {
            DumpTransformRecursive(child, depth + 1);
        }
    }
}
