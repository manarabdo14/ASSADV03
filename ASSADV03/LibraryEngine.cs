using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSADV03
{
    public delegate string BookDelegate(Book B);

    public class LibraryEngine
    {
        public static void ProcessBooks(List<Book> bList, BookDelegate fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
        public static void ProcessBooks(List<Book> bList, Func<Book, string> fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
        //public static void ProcessBooks(List<Book> bList)
        //{
        //    Func<Book, string> getISBN = delegate (Book B) {
        //        return B.ISBN;
        //    };

        //    foreach (Book B in bList)
        //    {
        //        Console.WriteLine(getISBN(B));
        //    }
        //}

        public static void ProcessBooks(List<Book> bList)
        {
            Func<Book, string> getPublicationDate = (B) => B.PublicationDate.ToShortDateString();

            foreach (Book B in bList)
            {
                Console.WriteLine(getPublicationDate(B));
            }
        }
    }

}
