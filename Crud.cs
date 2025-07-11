using crudapplication.Models;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.Data.SqlClient;

namespace crudapplication
{
    public class Crud
    {
        static string constring = Connectionstring.getconstring;


        public static List<Books> getallbook()
        {
            List<Books> list = new List<Books>();
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("select * from books", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Books books = new Books()
                        {
                            isbn = reader["isbn"].ToString() ?? "",
                            title = reader["Title"].ToString() ?? "",
                            qunatity = Convert.ToInt32(reader["quantity"]),
                            author = reader["Author"].ToString() ?? "",
                            category = reader["Category"].ToString() ?? "",
                            language = reader["language"].ToString() ?? ""
                        };

                        list.Add(books);
                    }

                }

            }
            return list;
        }

        public static void addnewbook(Books book)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO books (isbn, title, quantity, author, category, language) VALUES (@isbn, @title, @quantity, @author, @category, @language)", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@isbn", book.isbn);
                    cmd.Parameters.AddWithValue("@title", book.title);
                    cmd.Parameters.AddWithValue("@quantity", book.qunatity);
                    cmd.Parameters.AddWithValue("@author", book.author);
                    cmd.Parameters.AddWithValue("@category", book.category);
                    cmd.Parameters.AddWithValue("@language", book.language);
                    cmd.ExecuteNonQuery();

                }
            }
        }


        public static void deletebook(string? isbn)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("delete from books where isbn=@isbn", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@isbn", isbn);
                    cmd.ExecuteNonQuery();
                }
            }
        }

            public static Books getbookbyisbn(string? isbn)
            {
            Books books = new Books();
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("select * from books where isbn = @isbn", con))
                {
                    cmd.Parameters.AddWithValue("@isbn", isbn);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        books.isbn = reader["isbn"].ToString() ?? "";
                        books.title = reader["Title"].ToString() ?? "";
                        books.qunatity = Convert.ToInt32(reader["quantity"]);
                        books.author = reader["Author"].ToString() ?? "";
                        books.category = reader["Category"].ToString() ?? "";
                        books.language = reader["language"].ToString() ?? "";

                    }
                }
            }
            return books;
        }



        public static void UpdateBook(Books book)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE books SET title = @title, quantity = @quantity, author = @author, category = @category, language = @language WHERE isbn = @isbn", con))
                {
                    cmd.Parameters.AddWithValue("@isbn", book.isbn);
                    cmd.Parameters.AddWithValue("@title", book.title);
                    cmd.Parameters.AddWithValue("@quantity",book.qunatity);
                    cmd.Parameters.AddWithValue("@author", book.author);
                    cmd.Parameters.AddWithValue("@category",book.category);
                    cmd.Parameters.AddWithValue("@language", book.language);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}



