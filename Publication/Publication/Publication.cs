using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum PublicationType { Misc, Book, Magazine, Article };

public abstract class Publication
{
    private bool published = false;
    private DateTime datePublished;
    private int totalPages;

    public string Publisher { get; }
    public string Title { get; }
    public PublicationType Type { get; }
    public string CopyrightName { get; private set; }
    public int CopyrightDate { get; private set; }  // int as only year value
    public int Pages
    {
        get { return totalPages; }
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("The number of pages must be greater than zero.");
            totalPages = value;
        }
    }

    /// <summary>
    /// Constructor for Publication; Checks for non-empty title and publisher
    /// </summary>
    /// <param name="title">Publication's Title</param>
    /// <param name="publisher">Publication's Publisher</param>
    /// <param name="type">Type of publication eg. book, magazine etc</param>
    public Publication(string title, string publisher, PublicationType type)
    {
        if (String.IsNullOrWhiteSpace(publisher))
            throw new ArgumentException("The publisher is required.");
        Publisher = publisher;

        if (String.IsNullOrWhiteSpace(title))
            throw new ArgumentException("The title is required.");
        Title = title;

        Type = type;
    }

    /// <summary>
    /// Getter for publication date - returns "NYP" if not published
    /// </summary>
    /// <returns>Date published (as string - short date format) or "NYP" if not published</returns>
    public string GetPublicationDate()
    {
        if (!published)
            return "NYP";                           // Presumably stands for "Not Yet Published"
        else
            return datePublished.ToString("d");     // Date of publishing as short date formatted string
    }

    /// <summary>
    /// Changes status of Publication to "published" and set publication date
    /// </summary>
    /// <param name="datePublished">Date publication was published</param>
    public void Publish(DateTime datePublished)
    {
        published = true;
        this.datePublished = datePublished;
    }

    /// <summary>
    /// Set copyright details
    /// </summary>
    /// <param name="copyrightName">Name of copyright holder</param>
    /// <param name="copyrightDate">Date of copyright (year value only)</param>
    public void Copyright(string copyrightName, int copyrightDate)
    {
        if (String.IsNullOrWhiteSpace(copyrightName))
            throw new ArgumentException("The name of the copyright holder is required.");
        CopyrightName = copyrightName;

        int currentYear = DateTime.Now.Year;
        if (copyrightDate < currentYear - 10 || copyrightDate > currentYear + 2)
            throw new ArgumentOutOfRangeException($"The copyright year must be between {currentYear - 10} and {currentYear + 1}");
        CopyrightDate = copyrightDate;
    }

    /// <summary>
    /// Override for ToString() method so Publication is represented by Title when goes to string
    /// </summary>
    /// <returns>The title of the publication</returns>
    public override string ToString() => Title;
}