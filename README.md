# ChessAssignment_IDZDigital


The Movement Scripts are Located inside the Scripts->LegalMoves directory
Following are the LegalMoves Classes


In my implementation, I applied object-oriented programming (OOP) principles by using abstraction, inheritance, and polymorphism to design the LegalMoves class, which serves as a blueprint for different chess pieces. Here's a description of all the classes you implemented, highlighting how the OOP concept of legal moves is applied:

1. LegalMoves Class (Abstract Class)
Purpose: This is the base abstract class that defines the common behavior of calculating and highlighting legal moves for all chess pieces. It encapsulates the shared logic for movement and forces derived classes to implement specific movement behavior.
Key Concepts:
Abstraction: It declares abstract methods CalculateLegalMoves and HighlightLegalMoves without providing specific implementations, allowing derived classes to define these methods according to the movement rules of each chess piece.
Polymorphism: The abstract methods enable flexibility for different pieces (e.g., Rook, Knight) to implement unique behavior while sharing the same interface for calculating and highlighting moves.
Abstract Methods:

CalculateLegalMoves(ChessPlayerPlacementHandler piece): Forces derived classes to calculate legal moves based on the rules for that specific piece.

HighlightLegalMoves(int row, int column, int rowOffset, int columnOffset, ChessPlayerPlacementHandler piece): Defines the logic to highlight moves in a given direction and must be implemented by each chess piece class.


2. RookLegalMoves Class (Derived Class)
Purpose: This class inherits from LegalMoves and implements the legal movement behavior for the rook piece, which moves in straight lines (horizontally and vertically).
OOP Concepts Applied:
Inheritance: RookLegalMoves inherits from LegalMoves, allowing it to share the common interface and structure for legal move calculations while adding specific behavior for the rook.
Encapsulation: The calculation of rook moves is encapsulated within the RookLegalMoves class, abstracting the complexity from the rest of the system.
Polymorphism: It provides a unique implementation for CalculateLegalMoves and HighlightLegalMoves specific to the rook's movement, while still adhering to the structure of the LegalMoves class.


4. KnightLegalMoves Class (Derived Class)
Purpose: This class implements the movement rules for the knight, which moves in an "L" shape (2 squares in one direction and 1 square perpendicular).
OOP Concepts Applied:
Inheritance: Inherits from LegalMoves, using its abstract methods while providing the knight-specific movement logic.
Polymorphism: The knight moves differently from other pieces, and its CalculateLegalMoves method defines how to iterate over all possible L-shaped moves. The HighlightLegalMoves method checks if the knight’s moves are legal according to board boundaries and piece positions.
Encapsulation: The knight’s movement logic is encapsulated in this class, ensuring that each piece's logic is isolated.


6. BishopLegalMoves Class (Derived Class)
Purpose: This class defines the diagonal movement behavior of the bishop. Bishops can move diagonally any number of squares.
OOP Concepts Applied:
Inheritance: Inherits from LegalMoves, allowing it to reuse the abstract methods for legal move calculation while implementing the specific logic for diagonal movement.
Polymorphism: The bishop's CalculateLegalMoves method computes diagonal moves using offsets, and the HighlightLegalMoves method checks the validity of each move.
Encapsulation: The movement logic for the bishop is contained in this class, providing a clear separation of responsibilities.


8. QueenLegalMoves Class (Derived Class)
Purpose: The queen can move in both straight lines (like the rook) and diagonally (like the bishop). This class combines the movement logic of both the rook and the bishop.
OOP Concepts Applied:
Inheritance: Inherits from LegalMoves, leveraging the abstract methods to define the queen’s more complex movement, which is a combination of rook and bishop moves.
Polymorphism: CalculateLegalMoves combines the directional logic from both the rook and the bishop by iterating through all directions (vertical, horizontal, diagonal). The HighlightLegalMoves method handles the movement in any direction based on board limits.
Encapsulation: The combined movement logic for the queen is encapsulated here, allowing it to be maintained separately from other pieces while reusing common behaviors.


10. KingLegalMoves Class (Derived Class)
Purpose: The king moves one square in any direction (horizontal, vertical, diagonal). This class implements the king’s movement logic.
OOP Concepts Applied:
Inheritance: Inherits from LegalMoves, making use of the common structure for calculating and highlighting moves.
Polymorphism: The CalculateLegalMoves method implements the logic to move the king one square in any direction, and the HighlightLegalMoves method ensures the king's moves stay within the bounds and aren't blocked by other pieces.
Encapsulation: The movement logic specific to the king is contained within this class.



How OOP Principles Were Applied:
Abstraction: The LegalMoves abstract class provides a generic interface for calculating and highlighting legal moves without exposing the internal implementation details for each piece. Each derived class implements its own version of these methods based on the movement rules of the piece.

Inheritance: All specific chess piece classes (RookLegalMoves, KnightLegalMoves, etc.) inherit from the LegalMoves class. This allows common behavior to be shared across all pieces, reducing code duplication and improving maintainability.

Polymorphism: By implementing the abstract methods in different ways for each chess piece, you ensure that the game engine can calculate and highlight legal moves in a piece-specific manner while using a common interface. The CalculateLegalMoves method behaves differently for each piece but is always called in the same way.

Encapsulation: The movement logic for each piece is encapsulated within its own class. This ensures that the internal details of how each piece moves are hidden from other parts of the program, promoting modularity and ease of maintenance.

This approach not only adheres to the OOP principles but also provides a clean, scalable, and maintainable codebase, as adding new pieces or modifying existing ones requires minimal changes and does not affect the overall structure of the program.
