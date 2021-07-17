#### [Tetris](index.md 'index')
### [Tetris.Model.Tetrominos](Tetris_Model_Tetrominos.md 'Tetris.Model.Tetrominos')
## Tetromino Class
```csharp
public class Tetromino
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Tetromino  

Derived  
&#8627; [Block](Tetris_Model_Tetrominos_Block.md 'Tetris.Model.Tetrominos.Block')  
&#8627; [LeftZigZag](Tetris_Model_Tetrominos_LeftZigZag.md 'Tetris.Model.Tetrominos.LeftZigZag')  
&#8627; [LShaped](Tetris_Model_Tetrominos_LShaped.md 'Tetris.Model.Tetrominos.LShaped')  
&#8627; [ReverseLShaped](Tetris_Model_Tetrominos_ReverseLShaped.md 'Tetris.Model.Tetrominos.ReverseLShaped')  
&#8627; [RightZigZag](Tetris_Model_Tetrominos_RightZigZag.md 'Tetris.Model.Tetrominos.RightZigZag')  
&#8627; [TShaped](Tetris_Model_Tetrominos_TShaped.md 'Tetris.Model.Tetrominos.TShaped')  

| Constructors | |
| :--- | :--- |
| [Tetromino(Grid)](Tetris_Model_Tetrominos_Tetromino_Tetromino(Tetris_Model_Grid).md 'Tetris.Model.Tetrominos.Tetromino.Tetromino(Tetris.Model.Grid)') | Base constructor for tetromino<br/> |

| Methods | |
| :--- | :--- |
| [CanMove()](Tetris_Model_Tetrominos_Tetromino_CanMove().md 'Tetris.Model.Tetrominos.Tetromino.CanMove()') | Returns whether the tetromino has any options to move<br/> |
| [CanMoveDown()](Tetris_Model_Tetrominos_Tetromino_CanMoveDown().md 'Tetris.Model.Tetrominos.Tetromino.CanMoveDown()') | Checks if space below for tetromino to move down<br/> |
| [CanMoveLeft()](Tetris_Model_Tetrominos_Tetromino_CanMoveLeft().md 'Tetris.Model.Tetrominos.Tetromino.CanMoveLeft()') | Checks if tetromino has space to move left<br/> |
| [CanMoveRight()](Tetris_Model_Tetrominos_Tetromino_CanMoveRight().md 'Tetris.Model.Tetrominos.Tetromino.CanMoveRight()') | Checks if tetromino has space to move right<br/> |
| [Drop()](Tetris_Model_Tetrominos_Tetromino_Drop().md 'Tetris.Model.Tetrominos.Tetromino.Drop()') | Makes the tetromino drop all the way<br/> |
| [MoveDown()](Tetris_Model_Tetrominos_Tetromino_MoveDown().md 'Tetris.Model.Tetrominos.Tetromino.MoveDown()') | Moves the tetromino down a space (if able)<br/> |
| [MoveLeft()](Tetris_Model_Tetrominos_Tetromino_MoveLeft().md 'Tetris.Model.Tetrominos.Tetromino.MoveLeft()') | Method to move tetromino left (if able)<br/> |
| [MoveRight()](Tetris_Model_Tetrominos_Tetromino_MoveRight().md 'Tetris.Model.Tetrominos.Tetromino.MoveRight()') | Method to move tetromino right (if able)<br/> |
| [Rotate()](Tetris_Model_Tetrominos_Tetromino_Rotate().md 'Tetris.Model.Tetrominos.Tetromino.Rotate()') | Rotate the tetromino clockwise around the centre piece<br/> |
