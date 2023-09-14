// Book deve estar no arquivo src/TrybeLibrary/TrybeLibrary.cs e conter um membro do tipo BookType

// O Enum BookTypes deve fazer parte do namespace LibraryTypes, você irá precisar utilizar este namespace para criar um membro desse tipo.

// A struct Book deve pertencer ao namespace TrybeLibrary

namespace LibraryTypes;

    public struct Book
    {
        public BookTypes BookType;

        public Book(BookTypes bookType)
        {
            BookType = bookType;
        }
    }
