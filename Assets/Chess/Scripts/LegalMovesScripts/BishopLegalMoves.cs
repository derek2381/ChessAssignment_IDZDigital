using Chess.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopLegalMoves : LegalMoves
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.name == "Bishop")
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

    // Implement the abstract method to calculate legal moves for the bishop
    protected override void CalculateLegalMoves(ChessPlayerPlacementHandler piece)
    {
        int row = piece.getRow();
        int column = piece.getColumn();

        // Bishop moves diagonally, so we define four directions
        int[] rowOffsets = { 1, -1, -1, 1 };
        int[] columnOffsets = { 1, 1, -1, -1 };

        // Loop through each diagonal direction and highlight the legal moves
        for (int i = 0; i < rowOffsets.Length; i++)
        {
            HighlightLegalMoves(row, column, rowOffsets[i], columnOffsets[i], piece);
        }
    }

    // Implement the abstract method to highlight legal moves in a given diagonal direction
    protected override void HighlightLegalMoves(int row, int column, int rowOffset, int columnOffset, ChessPlayerPlacementHandler piece)
    {
        string nextPosition = (row + rowOffset).ToString() + "#" + (column + columnOffset).ToString();

        // Move diagonally while within board limits and no obstruction
        while ((row + rowOffset) <= 7 && (row + rowOffset) >= 0 && (column + columnOffset) <= 7 && (column + columnOffset) >= 0 && !piece.HasPosition(nextPosition))
        {
            ChessBoardPlacementHandler.Instance.Highlight(row + rowOffset, column + columnOffset);

            // Move further in the same diagonal direction
            row += rowOffset;
            column += columnOffset;

            nextPosition = (row + rowOffset).ToString() + "#" + (column + columnOffset).ToString();
        }
    }
}
