using UnityEngine.UI;

public class NonDrawingGraphic : Graphic
{
    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();
        return;
    }
}