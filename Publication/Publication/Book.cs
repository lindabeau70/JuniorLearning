using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Sealed class Book derived from Publication - Book cannot be used as base for another class
/// </summary>
public sealed class Book : Publication
{
    public string ISBN { get; }
    public string Author { get; }
    public Decimal Price { get; private set; }
    public string Currency { get; private set; } // A three digit ISO currency symbol

    /// <summary>
    /// Constructor for Book with 3 parameters - calls 4 parameter constructor with isbn as empty string
    /// </summary>
    /// <param name="title">Title of book</param>
    /// <param name="author">Author of book</param>
    /// <param name="publisher">Publisher of book</param>
    public Book(string title, string author, string publisher) : this(title, String.Empty, author, publisher) { }

    /// <summary>
    /// Constructor for Book with 4 parameters
    /// </summary>
    /// <param name="title">Title of book</param>
    /// <param name="isbn">ISBN of book</param>
    /// <param name="author">Author of book</param>
    /// <param name="publisher">Publisher of book</param>
    public Book(string title, string isbn, string author, string publisher) : base(title, publisher, PublicationType.Book)
    {
        // isbn must be 10 or 13 character numeric string (numbers only, no "-" characters)
        if (!String.IsNullOrEmpty(isbn))
        {
            if (!(isbn.Length == 10 || isbn.Length == 13)) // determine if ISBN length correct
                throw new ArgumentException("The ISBN must be a 10 or 13 character numeric string.");
            ulong nISBN = 0;
            if (!UInt64.TryParse(isbn, out nISBN))
                throw new ArgumentException("The ISBN can consist of numeric characters only.");
        }
        ISBN = isbn;
        Author = author;
    }

    /// <summary>
    /// Setter for Price.  Returns old price
    /// </summary>
    /// <param name="price">New price to be set</param>
    /// <param name="currency">New 3 digit ISO currency symbol</param>
    /// <returns>Old price</returns>
    public Decimal SetPrice(Decimal price, string currency)
    {
        if (price < 0)
            throw new ArgumentOutOfRangeException("The price cannot be negative.");
        Decimal oldValue = Price;
        Price = price;

        if (currency.Length != 3)
            throw new ArgumentException("The ISO currency symbol is a 3-character string.");
        Currency = currency;

        return oldValue;
    }

    /// <summary>
    /// Override Equals method so that it compares Book objects on their ISBN rather than being the same instance/reference.
    /// </summary>
    /// <param name="obj">Reference to object to be compared to this Book instance</param>
    /// <returns>True if ISBNs match, otherwise false</returns>
    public override bool Equals(object obj)
    {
        Book book = obj as Book;   // Don't know what this means.... is it casting it to a Book object?
        if (book == null)
            return false;
        else
            return ISBN == book.ISBN;

    }

    /// <summary>
    /// Override for GetHashCode() method so it hashes on ISBN rather than object
    /// </summary>
    /// <returns>The hash of the ISBN</returns>
    /// Interesting consideration:  What about empty string value for ISBN??  
    /// Would they all hash to same?  - That wouldn't be helpful...
    public override int GetHashCode() => ISBN.GetHashCode();

    /// <summary>
    /// Override for ToString() method so it gives Author, Title 
    /// Or if no Author; just Title
    /// </summary>
    /// <returns>Author, Title in string or when no Author, just the Title</returns>
    public override string ToString() => $"{(String.IsNullOrEmpty(Author) ? "" : Author + ", ")}{Title}";
}
