using Chess.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenLegalMoves : LegalMoves
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.name == "Queen")
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

    // Implement the abstract method to calculate legal moves for the queen
    protected override void CalculateLegalMoves(ChessPlayerPlacementHandler piece)
    {
        int row = piece.getRow();
        int column = piece.getColumn();

        // Define row and column offsets for all 8 directions
        int[] rowOffsets = { 1, -1, 0, 0, 1, 1, -1, -1 };
        int[] columnOffsets = { 0, 0, 1, -1, 1, -1, 1, -1 };

        // Loop through each direction and highlight the legal moves
        for (int i = 0; i < rowOffsets.Length; i++)
        {
            HighlightLegalMoves(row, column, rowOffsets[i], columnOffsets[i], piece);
        }
    }

    // Implement the abstract method to highlight legal moves in a given direction
    protected override void HighlightLegalMoves(int row, int column, int rowOffset, int columnOffset, ChessPlayerPlacementHandler piece)
    {
        string nextPosition = (row + rowOffset).ToString() + "#" + (column + columnOffset).ToString();

        // Move in the direction while within board limits and no obstruction
        while ((row + rowOffset) >= 0 && (row + rowOffset) <= 7 && (column + columnOffset) >= 0 && (column + columnOffset) <= 7 && !piece.HasPosition(nextPosition))
        {
            ChessBoardPlacementHandler.Instance.Highlight(row + rowOffset, column + columnOffset);

            // Move further in the same direction
            rowOffset += (rowOffset > 0) ? 1 : (rowOffset < 0) ? -1 : 0;
            columnOffset += (columnOffset > 0) ? 1 : (columnOffset < 0) ? -1 : 0;

            nextPosition = (row + rowOffset).ToString() + "#" + (column + columnOffset).ToString();
        }
    }
}
