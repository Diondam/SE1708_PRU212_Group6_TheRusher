// ChangePivot.cs

using UnityEngine;

public class ChangePivot : MonoBehaviour
{
    public Sprite[] sprites; // Mảng chứa tất cả các sprite cần thay đổi pivot
    public Vector2 newPivot = new Vector2(0.75f, 0.35f); // Pivot mới (ví dụ: 0.5, 0.5 là pivot ở trung tâm của sprite)

    public void ChangePivotForAllSprites()
    {
        if (sprites != null && sprites.Length > 0)
        {
            foreach (Sprite sprite in sprites)
            {
                if (sprite != null)
                {
                    string assetPath = UnityEditor.AssetDatabase.GetAssetPath(sprite);
                    // Tạo một sprite mới với pivot mới
                    Texture2D texture = UnityEditor.AssetDatabase.LoadAssetAtPath<Texture2D>(assetPath);
                    Sprite newSprite = Sprite.Create(texture, sprite.rect, newPivot, sprite.pixelsPerUnit);

                    // Ghi đè dữ liệu mới vào asset
                    UnityEditor.AssetDatabase.DeleteAsset(assetPath); // Xóa asset cũ
                    UnityEditor.AssetDatabase.AddObjectToAsset(newSprite, assetPath); // Thêm asset mới
                    UnityEditor.AssetDatabase.SaveAssets(); // Lưu lại
                }
            }

            // Lưu và làm mới tài nguyên

            UnityEditor.AssetDatabase.Refresh();
        }
    }
}