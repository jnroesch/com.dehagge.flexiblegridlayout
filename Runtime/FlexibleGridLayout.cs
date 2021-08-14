using UnityEngine;
using UnityEngine.UI;

namespace Packages.com.dehagge.flexiblegridlayout.Runtime
{
    public class FlexibleGridLayout : LayoutGroup
    {
        public enum FitType
        {
            Uniform,
            Width,
            Height,
            FixedRows,
            FixedColumns,
            FixedGrid
        }

        public FitType fitType;
        public Vector2 spacing;

        public int rows;
        public int columns;
        
        private Vector2 cellSize;
        private bool fitX;
        private bool fitY;

        public override void CalculateLayoutInputVertical()
        {
            base.CalculateLayoutInputHorizontal();
            
            if(fitType == FitType.Width || fitType == FitType.Height || fitType == FitType.Uniform)
            {
                fitX = true;
                fitY = true;
                var sqrRt = Mathf.Sqrt(transform.childCount);
                rows = Mathf.CeilToInt(sqrRt);
                columns = Mathf.CeilToInt(sqrRt);
            }

            if(fitType == FitType.Width || fitType == FitType.FixedColumns || fitType == FitType.Uniform)
            {
                rows = Mathf.CeilToInt(transform.childCount / (float)columns);
            }
            if (fitType == FitType.Height || fitType == FitType.FixedRows || fitType == FitType.Uniform)
            {
                columns = Mathf.CeilToInt(transform.childCount / (float)rows);
            }

            var parentWidth = rectTransform.rect.width;
            var parentHeight = rectTransform.rect.height;

            var cellWidth = parentWidth / columns - spacing.x / columns * (columns - 1) - padding.left / (float)columns - padding.right / (float)columns;
            var cellHeight = parentHeight / rows - spacing.y / rows * (rows - 1) - padding.top / (float)rows - padding.bottom / (float)rows;

            cellSize.x = cellWidth;// fitX ? cellWidth : cellSize.x;
            cellSize.y = cellHeight;//fitY ? cellHeight : cellSize.y;

            for(var i = 0; i < rectChildren.Count; i ++)
            {
                //prevent divide by zero exceptions
                if (columns == 0) return;
                
                var rowCount = i / columns;
                var columnCount = i % columns;

                var item = rectChildren[i];

                var xPos = cellSize.x * columnCount + spacing.x * columnCount + padding.left;
                var yPos = cellSize.y * rowCount + spacing.y * rowCount + padding.top;

                SetChildAlongAxis(item, 0, xPos, cellSize.x);
                SetChildAlongAxis(item, 1, yPos, cellSize.y);
            }
        }

        public override void SetLayoutHorizontal()
        {
            //NOP
        }

        public override void SetLayoutVertical()
        {
            //NOP
        }
    }
}
