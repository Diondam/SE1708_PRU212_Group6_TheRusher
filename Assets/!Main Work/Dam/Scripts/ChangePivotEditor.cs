using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ChangePivot))]
public class ChangePivotEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ChangePivot changePivot = (ChangePivot)target;
        // Hiển thị một nút "Submit" để gọi hàm thay đổi pivot khi được nhấn

        if (GUILayout.Button("Submit"))
        {
            changePivot.ChangePivotForAllSprites();
        }
    }
}