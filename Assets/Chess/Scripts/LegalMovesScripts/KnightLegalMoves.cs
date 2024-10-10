using Chess.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightLegalMoves : LegalMoves
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.name == "Knight")
            {
                ChessBoardPlacementHandler.Instance.ClearHighlights();
                ChessPlayerPlacementHandler piece = hit.collider.GetComponent<ChessPlayerPlacementHandler>();
                CalculateLegalMoves(piece);
            }
            else if (hit.collider == null)
            {
                ChessBoardPlacementHandler.Instance.ClearHighlights();
            }
        }
    }

    // Implement the abstract method to calculate legal moves for the knight
    protected override void CalculateLegalMoves(ChessPlayerPlacementHandler piece)
    {
        int row = piece.getRow();
        int column = piece.getColumn();

        // Knight moves in L-shape, defined by these offsets
        int[] rowOffsets = { 2, 2, -1, 1, -1, 1, -2, -2 };
        int[] columnOffsets = { -1, 1, 2, 2, -2, -2, -1, 1 };

        // Loop through all the L-shape movements
        for (int i = 0; i < rowOffsets.Length; i++)
        {
            HighlightLegalMoves(row, column, rowOffsets[i], columnOffsets[i], piece);
        }
    }

    // Implement the abstract method to highlight legal moves for the knight
    protected override void HighlightLegalMoves(int row, int column, int rowOffset, int columnOffset, ChessPlayerPlacementHandler piece)
    {
        string nextPosition = (row + rowOffset).ToString() + "#" + (column + columnOffset).ToString();

        // Validate if the move is within board limits and not blocked by the player's own piece
        if ((row + rowOffset) >= 0 && (row + rowOffset) <= 7 && (column + columnOffset) >= 0 && (column + columnOffset) <= 7 && !piece.HasPosition(nextPosition))
        {
            ChessBoardPlacementHandler.Instance.Highlight(row + rowOffset, column + columnOffset);
        }
    }
}
