using Chess.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingLegalMoves : LegalMoves
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.name == "King")
            {
                ChessPlayerPlacementHandler piece = hit.collider.GetComponent<ChessPlayerPlacementHandler>();
                ChessBoardPlacementHandler.Instance.ClearHighlights();

                CalculateLegalMoves(piece);
            }
            else if (hit.collider == null)
            {
                ChessBoardPlacementHandler.Instance.ClearHighlights();
            }
        }
    }

    // Implement the abstract method to calculate legal moves
    protected override void CalculateLegalMoves(ChessPlayerPlacementHandler piece)
    {
        int row = piece.getRow();
        int column = piece.getColumn();

        int[] rowOffsets = { 1, 1, 0, -1, -1, -1, 0, 1 };
        int[] columnOffsets = { 0, 1, 1, 1, 0, -1, -1, -1 };

        for (int i = 0; i < rowOffsets.Length; i++)
        {
            HighlightLegalMoves(row, column, rowOffsets[i], columnOffsets[i], piece);
        }
    }

    // Implement the abstract method to highlight legal moves
    protected override void HighlightLegalMoves(int row, int column, int rowOffset, int columnOffset, ChessPlayerPlacementHandler piece)
    {
        string nextPosition = (row + rowOffset).ToString() + "#" + (column + columnOffset).ToString();

        if ((row + rowOffset) >= 0 && (row + rowOffset) <= 7 && (column + columnOffset) <= 7 && (column + columnOffset) >= 0 && !piece.HasPosition(nextPosition))
        {
            ChessBoardPlacementHandler.Instance.Highlight((row + rowOffset), (column + columnOffset));
            nextPosition = (row + rowOffset).ToString() + "#" + (column + columnOffset).ToString();
        }
    }
}
