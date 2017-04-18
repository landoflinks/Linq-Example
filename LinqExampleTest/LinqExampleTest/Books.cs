using System;

public class Books
{
    public string book;
    public string genre;
    public string author;
    public int releaseYear;

	public Books()
	{
        book = "none";
        genre = "none";
        author = "none";
        releaseYear = 0;
	}

    public Books(string novel, string setGenre, string writer)
    {
        book = novel;
        genre = setGenre;
        author = writer;
        releaseYear = 0;
    }

    public Books(string novel, string setGenre, string writer, int year)
    {
        book = novel;
        genre = setGenre;
        author = writer;
        releaseYear = year;
    }
}
