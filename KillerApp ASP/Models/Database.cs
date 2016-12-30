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
                            cmd.CommandText = "SELECT ID Naam, OpgerichtJaartal FROM Band;";
                            cmd.Connection = conn;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string naam = reader.GetString(0);
                                    int jaar = reader.GetInt32(1);
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
                            cmd.CommandText = "SELECT ID Titel, Duur, Genre, Album FROM Lied;";
                            cmd.Connection = conn;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string titel = reader.GetString(1);
                                    int duur = reader.GetInt32(2);
                                    Band band = new Band(reader.GetString(3), 0);
                                    Genre genre = (Genre)Enum.Parse(typeof(Genre), reader.GetString(4));
                                    Album album = new Album(reader.GetString(5), 0, false);

                                    liedjes.Add(new Lied(titel, duur, genre, band, album));
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
                                    bool single = reader.GetBoolean(3);

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
                            cmd.CommandText = "SELECT ID, Naam, Afspeelduur FROM Afspeellijst";
                            cmd.Connection = conn;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string naam = reader.GetString(1);
                                    int duur = reader.GetInt32(2);

                                    playlists.Add(new Playlist(naam, duur));
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
    }
}