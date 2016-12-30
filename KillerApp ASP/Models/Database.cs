using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KillerApp_ASP.Models
{
    public class Database
    {
        private readonly string connectie = "Server=mssql.fhict.local;Database=dbi299244;User Id=dbi299244;Password=Schrader01;";

        public List<Band> ListBands()
        {
            List<Band> bands = new List<Band>();
            using (SqlConnection conn = new SqlConnection(connectie))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT ID, Naam, OpgerichtJaartal FROM Band;";
                            cmd.Connection = conn;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string naam = reader.GetString(1);
                                    int jaar;
                                    if (reader.IsDBNull(2))
                                    {
                                        jaar = 0;
                                    }
                                    else
                                    {
                                        jaar = reader.GetInt32(2);
                                    }
                                    bands.Add(new Band(naam, jaar));
                                }
                                return bands;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exceptions.DataException(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return null;
        }

        public List<Lied> ListLiedjes()
        {
            List<Lied> liedjes = new List<Lied>();
            using (SqlConnection conn = new SqlConnection(connectie))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT L.ID, L.Titel, L.Duur, L.GenreID, B.ID, B.Naam, B.OpgerichtJaartal, A.Titel, A.Uitgiftejaar, A.ID, A.Single FROM Lied L LEFT JOIN Band B on B.ID = L.BandID LEFT JOIN Album A on A.ID = L.AlbumID;";
                            cmd.Connection = conn;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    string titel = reader.GetString(1);
                                    int duur = reader.GetInt32(2);
                                    int Bid = reader.GetInt32(4);
                                    string Bnaam = reader.GetString(5);
                                    int BJaar;
                                    if (reader.IsDBNull(6))
                                    {
                                        BJaar = 0;
                                    }
                                    else
                                    {
                                        BJaar = reader.GetInt32(6);
                                    }
                                    int Aid = reader.GetInt32(9);
                                    string ATitel = reader.GetString(7);
                                    int AJaar = reader.GetInt32(8);
                                    bool ASingle;
                                    if (reader.GetString(10) == "Single")
                                    {
                                        ASingle = true;
                                    }
                                    else 
                                    {
                                        ASingle = false;
                                    }
                                    Genre genre = (Genre)Enum.Parse(typeof(Genre), reader.GetString(3));
                                    Band band = new Band(Bnaam, BJaar);
                                    Album album = new Album(Aid, ATitel, AJaar, ASingle);

                                    liedjes.Add(new Lied(id, titel, duur, genre, band, album));
                                }
                                return liedjes;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exceptions.DataException(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return null;
        }

        public List<Album> ListAlbums()
        {
            List<Album> albums = new List<Album>();
            using (SqlConnection conn = new SqlConnection(connectie))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT ID, Titel, Uitgiftejaar, Single FROM Album;";
                            cmd.Connection = conn;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string titel = reader.GetString(1);
                                    int jaar = reader.GetInt32(2);
                                    bool single;
                                    if (reader.GetString(3) == "Single")
                                    {
                                        single = true;
                                    }
                                    else if (reader.GetString(3) == "Album")
                                    {
                                        single = false;
                                    }
                                    else
                                    {
                                        single = false;
                                    }

                                    albums.Add(new Album(titel, jaar, single));
                                }
                                return albums;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exceptions.DataException(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return null;
        }

        public List<Playlist> ListPlaylists()
        {
            List<Playlist> playlists = new List<Playlist>();
            using (SqlConnection conn = new SqlConnection(connectie))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT P.ID, P.Naam, P.Afspeelduur, G.Naam FROM Playlist P LEFT JOIN Gebruiker G on G.ID = P.Maker";
                            cmd.Connection = conn;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    string naam = reader.GetString(1);
                                    int duur = reader.GetInt32(2);
                                    string Gnaam = reader.GetString(3);

                                    playlists.Add(new Playlist(id, naam, duur, Gnaam));
                                }
                                return playlists;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exceptions.DataException(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return null;
        }
        public Lied GetLiedById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectie))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT ID, Titel, Duur, BandID, GenreID, AlbumID FROM Lied WHERE ID = @id";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@id", id);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                int _id = reader.GetInt32(0);
                                string titel = reader.GetString(1);
                                int duur = reader.GetInt32(2);
                                Genre genre = (Genre)Enum.Parse(typeof(Genre), reader.GetString(4));
                                Band band = new Band(reader.GetInt32(3));
                                Album album = new Album(reader.GetInt32(5));
                                return new Lied(_id, titel, duur, genre, band, album);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exceptions.DataException(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return null;
        }
    }
}