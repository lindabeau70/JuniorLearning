#### [Tetris](index.md 'index')
### [Tetris.Model](Tetris_Model.md 'Tetris.Model')
## CellCollection Class
Will be used for both the Grid and for individual tetrominos  
Grid - only cells occupied are included in CellCollection  
Tetrominos - has the current cells for tetromino  
```csharp
public class CellCollection
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CellCollection  

| Methods | |
| :--- | :--- |
| [Add(int, int)](Tetris_Model_CellCollection_Add(int_int).md 'Tetris.Model.CellCollection.Add(int, int)') | To add a cell to the collection<br/> |
| [CollapseRows(List&lt;int&gt;)](Tetris_Model_CellCollection_CollapseRows(System_Collections_Generic_List_int_).md 'Tetris.Model.CellCollection.CollapseRows(System.Collections.Generic.List&lt;int&gt;)') | Remove 'passed' rows and move higher cells down to fill<br/> |
| [Contains(int, int)](Tetris_Model_CellCollection_Contains(int_int).md 'Tetris.Model.CellCollection.Contains(int, int)') | Checks if cell at given coords is occupied<br/> |
| [GetAll()](Tetris_Model_CellCollection_GetAll().md 'Tetris.Model.CellCollection.GetAll()') | To extract list of all occupied cells<br/>This is particularly relevant when adding tetromino to grid <br/>- to extract tetromino cells for adding to grid<br/> |
| [GetCssClass(int, int)](Tetris_Model_CellCollection_GetCssClass(int_int).md 'Tetris.Model.CellCollection.GetCssClass(int, int)') | Gets the CSS class of a cell<br/> |
| [HasColumn(int)](Tetris_Model_CellCollection_HasColumn(int).md 'Tetris.Model.CellCollection.HasColumn(int)') | Checks if any occupied cells in given column<br/> |
| [HasRow(int)](Tetris_Model_CellCollection_HasRow(int).md 'Tetris.Model.CellCollection.HasRow(int)') | Checks if any occupied cells in given row<br/> |
| [SetCssClass(int, string)](Tetris_Model_CellCollection_SetCssClass(int_string).md 'Tetris.Model.CellCollection.SetCssClass(int, string)') | Reassigning css class on a row<br/>Relevant for making completed row "flash" prior to removal<br/> |
