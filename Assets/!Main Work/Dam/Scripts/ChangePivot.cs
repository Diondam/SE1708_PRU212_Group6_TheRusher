using UnityEngine;
using UnityEditor;

public class ChangePivot: EditorWindow
{
    private Sprite sprite; // Tham chiếu đến sprite cần thay đổi pivot
    private Vector2 newPivot = new Vector2(0.5f, 0.5f); // Pivot mới (ví dụ: 0.5, 0.5 là pivot ở trung tâm của sprite)

    [MenuItem("Tools/Change Pivot For All SubSprites")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ChangePivot));
    }

    void OnGUI()
    {
        GUILayout.Label("Change Pivot For All SubSprites", EditorStyles.boldLabel);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), false) as Sprite;

        if (GUILayout.Button("Change Pivot"))
        {
            if (sprite != null)
            {
                ChangePivotForAllSubSprites(sprite);
            }
            else
            {
                Debug.LogError("Please assign a sprite.");
            }
        }
    }

    void ChangePivotForAllSubSprites(Sprite sprite)
    {
        // Lấy tất cả các sprite con của sprite chính
        Sprite[] subSprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(AssetDatabase.GetAssetPath(sprite)) as Sprite[];

        // Lặp qua tất cả các sprite con và thay đổi pivot
        foreach (Sprite subSprite in subSprites)
        {
            ChangePivotForSprite(subSprite);
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    void ChangePivotForSprite(Sprite sprite)
    {
        
        
        // Đặt pivot mới cho sprite
       // sprite.OverrideGeometry(new Vector2(sprite.rect.width * newPivot.x, sprite.rect.height * newPivot.y), sprite.bounds.size);
       
    }
}