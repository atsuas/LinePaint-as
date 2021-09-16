using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LinePaint
{

    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private CameraZoom gameCamera;
        [SerializeField] private Cell blockPrefab;
        [SerializeField] private BrushController brush; //追加
        [SerializeField] private int width;
        [SerializeField] private int height;
        [SerializeField] private float cellSize;

        private Cell[,] cells;
        private GridScript gridScript;
        private SwipeController swipeController;
        private BrushController currentBrush; //追加

        private void Start()
        {
            swipeController = new SwipeController();
            swipeController.SetLevelManager(this);

            gridScript = new GridScript();
            gridScript.Initialize(width, height, cellSize);
            cells = new Cell[width, height];

            CreateGrid(Vector3.zero);

            currentBrush = Instantiate(brush, gridScript.GetCellWorldPosition(0, 0), Quaternion.identity); //追加
            currentBrush.coords = new Vector2Int(0, 0); //追加

            gameCamera.ZoomPerspectiveCamera(width, height);

        }

        private void CreateGrid(Vector3 originPos)
        {
            for (int x = 0; x < gridScript.GridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridScript.GridArray.GetLength(1); y++)
                {
                    cells[x, y] = CreateCell(x, y, originPos);
                }
            }
        }

        private Cell CreateCell(int x, int y, Vector3 originPos)
        {
            Cell cell = Instantiate(blockPrefab);
            cell.coords = new Vector2Int(x, y);
            cell.transform.localScale = new Vector3(cellSize, 0.25f, cellSize);
            cell.transform.position = originPos + gridScript.GetCellWorldPosition(x, y);
            return cell;
        }

        //MoveBrushの中身を追加
        public void MoveBrush(Swipe direction)
        {
            
            Vector2Int newCoords = gridScript.GetCellXYBySwipe(currentBrush.coords.x, currentBrush.coords.y, direction);

            if (newCoords != new Vector2Int(-1, -1))
            {
                Vector3 finalPos = gridScript.GetCellWorldPosition(newCoords.x, newCoords.y);

                currentBrush.transform.position = finalPos;
                currentBrush.coords = newCoords;
            }
        }

        private void Update()
        {
            if (swipeController != null)
            {
                swipeController.OnUpdate();
            }
        }
    }
}
