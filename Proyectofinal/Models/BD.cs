using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Proyectofinal.Models
{
    public class BD
    {
        public static SqlConnection SQL = new SqlConnection("Server=resumamosdbserver.database.windows.net;Database=resumamos;User ID=aguskryss;Password=Alberbenda123;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;");
         public static SqlConnection Conectar()
        {
            SQL.Open();
            return SQL;
        }

        public static SqlConnection Desconectar()
        {
            SQL.Close();
            return SQL;
        }
        public static Usuarios ValidarLoginUsuario(string Username, string Pass)
        {
            Usuarios user = new Usuarios();

            // Busco en la base de datos si existe un usuario con ese username y password
            //Si lo encuentra (Read = true) llenas el objeto user con lo que encontro.
            // devuelvo user

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Usuarios WHERE Username ='" + Username + "' and Contrasena = '" + Pass + "'"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read() == true)
            {
                user.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                user.Username = dataReader["Username"].ToString();
                user.Contrasena = dataReader["Contrasena"].ToString();
                user.Nombre = dataReader["Nombre"].ToString();
                user.Apellido = dataReader["Apellido"].ToString();
                user.Mail = dataReader["Mail"].ToString();
                user.Admin = Convert.ToBoolean(dataReader["Admin"]);
                user.Creditos = Convert.ToInt32(dataReader["Creditos"]);
                user.Escuela= Convert.ToInt32(dataReader["FkEscuela"]);
                user.Puntuacion = Convert.ToDouble(dataReader["PuntuacionUs"]);
            }
            else
            {
                user.IdUsuario = -1;
            }
            dataReader.Close();
            Desconectar();
            return user;
        }
        public static List<Resumenes> TraerResumenes(int idRes)//Cuando es -1 trae todo, sino trae esa
        {

            List<Resumenes> ListaDeResumenes = new List<Resumenes>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            if (idRes != -1)
            {
                command.CommandText = "SELECT* FROM Resumenes where Aprobado = 1 and IdResumen =" + idRes; //Consulta
            }
            else
            {
                command.CommandText = "SELECT* FROM Resumenes where Aprobado = 1 order by Puntuacion DESC"; //Consulta
            }
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                int idres = Convert.ToInt32(dataReader["IdResumen"]);
                string Nom = dataReader["Nombre"].ToString();
                int fkMat = Convert.ToInt32(dataReader["FkMateria"]);
                int fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
                int punt = Convert.ToInt32(dataReader["Puntuacion"]);
                int ano = Convert.ToInt32(dataReader["Anio"]);
                string ft = dataReader["Archivo"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                DateTime fecha = Convert.ToDateTime(dataReader["Fecha"]);
                Boolean ap = Convert.ToBoolean(dataReader["Aprobado"]);
                string des = dataReader["Descripcion"].ToString();

                Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc,ap,fecha,des);
                ListaDeResumenes.Add(resu);
            }
            dataReader.Close();
            Desconectar();
            return ListaDeResumenes;

        }
        public static List<Resumenes> TraerResum()//Cuando es -1 trae todo, sino trae esa
        {

            List<Resumenes> ListaDeResumenes = new List<Resumenes>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT* FROM Resumenes where Aprobado = 1 order by Puntuacion DESC"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                int idres = Convert.ToInt32(dataReader["IdResumen"]);
                string Nom = dataReader["Nombre"].ToString();
                int fkMat = Convert.ToInt32(dataReader["FkMateria"]);
                int fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
                int punt = Convert.ToInt32(dataReader["Puntuacion"]);
                int ano = Convert.ToInt32(dataReader["Anio"]);
                string ft = dataReader["Archivo"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                DateTime fecha = Convert.ToDateTime(dataReader["Fecha"]);
                Boolean ap = Convert.ToBoolean(dataReader["Aprobado"]);
                string des = dataReader["Descripcion"].ToString();

                Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc, ap, fecha, des);
                ListaDeResumenes.Add(resu);
            }
            dataReader.Close();
            Desconectar();
            return ListaDeResumenes;

        }
        public static int TraerCantidadResumenesAprobados()
        {

            int ret = 0;

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT count(IdResumen) as cant FROM Resumenes where Aprobado=1"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                ret = Convert.ToInt32(dataReader["cant"]);
            }
            dataReader.Close();
            Desconectar();
            return ret;

        }
        public static int TraerCantidadResumenesSinAprobar()
        {

            int ret = 0;

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT count(IdResumen) as cant FROM Resumenes where Aprobado=0"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                ret = Convert.ToInt32(dataReader["cant"]);
            }
            dataReader.Close();
            Desconectar();
            return ret;

        }
        public static int TraerCantidadResumenesLibrosVend()
        {

            int ret = 0;

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT count(IdLibro) as cant FROM Libros where FkComprador>0"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                ret = Convert.ToInt32(dataReader["cant"]);
            }
            dataReader.Close();
            Desconectar();
            return ret;

        }
        public static int TraerCantidadUsuarios()
        {

            int ret = 0;

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT count(IdUsuario) as cant FROM Usuarios"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                ret = Convert.ToInt32(dataReader["cant"]);
            }
            dataReader.Close();
            Desconectar();
            return ret;

        }

        public static int TraerCantidadLibrosAprobados()
        {

            int ret = 0;

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT count(IdLibro) as cant FROM Libros where Aprobado=1"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                ret = Convert.ToInt32(dataReader["cant"]);
            }
            dataReader.Close();
            Desconectar();
            return ret;

        }
        public static int TraerCantidadLibrosSinAprobar()
        {

            int ret = 0;

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT count(IdLibro) as cant FROM Libros where Aprobado=0"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                ret = Convert.ToInt32(dataReader["cant"]);
            }
            dataReader.Close();
            Desconectar();
            return ret;

        }
        public static Resumenes TraerResumen(int idRes)
        {
            Resumenes resumen=new Resumenes();
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT* FROM Resumenes where IdResumen =" + idRes; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                int idres = Convert.ToInt32(dataReader["IdResumen"]);
                string Nom = dataReader["Nombre"].ToString();
                int fkMat = Convert.ToInt32(dataReader["FkMateria"]);
                int fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
                int punt = Convert.ToInt32(dataReader["Puntuacion"]);
                int ano = Convert.ToInt32(dataReader["Anio"]);
                string ft = dataReader["Archivo"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                DateTime fecha = Convert.ToDateTime(dataReader["Fecha"]);
                Boolean ap = Convert.ToBoolean(dataReader["Aprobado"]);
                string des = dataReader["Descripcion"].ToString();
                Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc, ap, fecha,des);

                resumen = resu;
            }
            dataReader.Close();
            Desconectar();
            return resumen;
        }
        public static void EliminarResumen(int id)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM Resumenes WHERE IdResumen =" + id; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }
        public static void EliminarLibro(int id)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM Libros WHERE IdLibro =" + id; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }

        public static void InsertarResumen(Resumenes res)
        {
            int verd;
            if (res.Aprobado == false)
            {
                verd = 0;
            }
            else
            {
                verd = 1;
            }




            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT into Resumenes(Nombre, FkMateria ,FkUsuario,Puntuacion,Anio,Archivo,FkEscuela,Fecha,Aprobado,Descripcion ) values ('" + res.Nombre + "'," + res.FkMateria + "," + res.FkUsuario + "," + res.Puntuacion + "," + res.Ano + ",'" + res.NombreImagen + "'," + res.FkEscuela + ",'"+res.Fecha+ "',"+verd+",'"+res.Descripcion+"')"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }

        public static void InsertarUsuario(Usuarios usu)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            if (usu.NombreImagen == null)
            {
                command.CommandText = "INSERT into Usuarios (Username, Contrasena , Nombre , Apellido ,Mail,Admin,PuntuacionUs,FkEscuela,Creditos) values ('" + usu.Username + "','" + usu.Contrasena + "','" + usu.Nombre + "','" + usu.Apellido + "','" + usu.Mail + "',0,0," + usu.Escuela + ",0 )"; //Consulta
            }
            else
            {
                command.CommandText = "INSERT into Usuarios (Username, Contrasena , Nombre , Apellido ,Mail,Admin,PuntuacionUs,FkEscuela,Creditos,FotoPerfil) values ('" + usu.Username + "','" + usu.Contrasena + "','" + usu.Nombre + "','" + usu.Apellido + "','" + usu.Mail + "',0,0," + usu.Escuela + ",0, '"+usu.NombreImagen+"')"; //Consulta
            }
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }
        public static void ModificarResumen(Resumenes resu)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "UPDATE Resumenes SET Nombre = '" + resu.Nombre + "', FkEscuela="+resu.FkEscuela+" , Descripcion='"+resu.Descripcion+ "', Anio=" + resu.Ano+ ", Archivo='"+resu.NombreImagen+"' WHERE IdResumen = " + resu.IdResumen; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }
        public static void ModificarLibro(Libro li)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "UPDATE Libros SET Nombre = '" + li.Nombre + "',Precio="+li.Precio+",FkMateria="+li.FkMateria+",Editorial='"+li.Editorial+"',Lugar='"+li.Lugar+"',NombreImagen='"+li.NombreImagen+"',FkAno="+li.FkAno+",Division='"+li.Division+"',FkEscuela="+li.FkEscuela+",Descripcion='"+li.Descripcion+"',Telefono="+li.Telefono+",LinkMp='' WHERE IdLibro = " + li.IdLibro; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }

        public static void ModificarLibroBack(Libro li)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "UPDATE Libros SET Nombre = '" + li.Nombre + "',Precio=" + li.Precio + ",FkMateria=" + li.FkMateria + ",Editorial='" + li.Editorial + "',Lugar='" + li.Lugar + "',NombreImagen='" + li.NombreImagen + "',FkAno=" + li.FkAno + ",Division='" + li.Division + "',FkEscuela=" + li.FkEscuela + ",Descripcion='" + li.Descripcion + "',Telefono=" + li.Telefono + ",LinkMp='"+li.LinkMP+"' WHERE IdLibro = " + li.IdLibro; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }

        public static List<Escuela> TraerEscuelas()
        {

            List<Escuela> ListaDeEscuela = new List<Escuela>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT* FROM Escuelas"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                int idesc = Convert.ToInt32(dataReader["IdEscuela"]);
                string Nom = dataReader["NombreEscuela"].ToString();
                Escuela escu = new Escuela(idesc, Nom);
                ListaDeEscuela.Add(escu);
            }
            dataReader.Close();
            Desconectar();

            return ListaDeEscuela;
        }
        public static List<Materia> TraerMateria()
        {

            List<Materia> ListaDeMaterias = new List<Materia>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT* FROM Materias"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                int idmate = Convert.ToInt32(dataReader["IdMateria"]);
                string NomMa = dataReader["NombreMateria"].ToString();
                Materia mat = new Materia(idmate, NomMa);
                ListaDeMaterias.Add(mat);
            }
            dataReader.Close();
            Desconectar();

            return ListaDeMaterias;
        }

        public static Año TraerAñoXid(int id)
        {
            Conectar();
            Año a = new Año();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Ano WHERE ano=" + id; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                a.a= Convert.ToInt32(dataReader["ano"]);
                a.escri = dataReader["escri"].ToString();
            }
            dataReader.Close();
            Desconectar();
            return a;
        }
        public static Materia TraerMateriaxId(int id)
        {
            Conectar();
            Materia mat = new Materia();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Materias WHERE IdMateria=" + id; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                mat.IdMateria = Convert.ToInt32(dataReader["IdMateria"]);
                mat.NombreMateria = dataReader["NombreMateria"].ToString();
                
            }
            dataReader.Close();
            Desconectar();

            return mat;
        }

        public static Escuela TraerEscuelaxId(int id)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Escuelas WHERE IdEscuela=" + id.ToString(); //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Escuela esc = new Escuela();
            while (dataReader.Read())
            {
                int idE = Convert.ToInt32(dataReader["IdEscuela"]);
                string Nom = dataReader["NombreEscuela"].ToString();
                esc = new Escuela(idE, Nom);
            }
            dataReader.Close();
            Desconectar();

            return esc;
        }
        public static List<Resumenes> TraerResumenesXAno(int Ano, string txt)//Cuando es -1 trae todo, sino trae esa
        {

            List<Resumenes> ListaDeResumenes = new List<Resumenes>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT* FROM Resumenes where Aprobado = 1 and Anio = " + Ano + " order by Puntuacion DESC"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                int idres = Convert.ToInt32(dataReader["IdResumen"]);
                string Nom = dataReader["Nombre"].ToString();
                int fkMat = Convert.ToInt32(dataReader["FkMateria"]);
                int fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
                int punt = Convert.ToInt32(dataReader["Puntuacion"]);
                int ano = Convert.ToInt32(dataReader["Anio"]);
                string ft = dataReader["Archivo"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                DateTime fecha = Convert.ToDateTime(dataReader["Fecha"]);
                Boolean ap = Convert.ToBoolean(dataReader["Aprobado"]);
                string des = dataReader["Descripcion"].ToString();

                Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc, ap, fecha,des);
                ListaDeResumenes.Add(resu);
            }
            dataReader.Close();
            Desconectar();

            return ListaDeResumenes;
        }
        public static List<Resumenes> TraerResumenesXMat(int Mat)//Cuando es -1 trae todo, sino trae esa
        {

            List<Resumenes> ListaDeResumenes = new List<Resumenes>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT* FROM Resumenes where Aprobado = 1 and FkMateria = " + Mat + " order by Puntuacion DESC"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                int idres = Convert.ToInt32(dataReader["IdResumen"]);
                string Nom = dataReader["Nombre"].ToString();
                int fkMat = Convert.ToInt32(dataReader["FkMateria"]);
                int fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
                int punt = Convert.ToInt32(dataReader["Puntuacion"]);
                int ano = Convert.ToInt32(dataReader["Anio"]);
                string ft = dataReader["Archivo"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                DateTime fecha = Convert.ToDateTime(dataReader["Fecha"]);
                Boolean ap = Convert.ToBoolean(dataReader["Aprobado"]);
                string des = dataReader["Descripcion"].ToString();

                Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc, ap, fecha,des);
                ListaDeResumenes.Add(resu);
            }
            dataReader.Close();
            Desconectar();

            return ListaDeResumenes;
        }
        public static List<Resumenes> TraerResumenesXEsc(int Esc)//Cuando es -1 trae todo, sino trae esa
        {

            List<Resumenes> ListaDeResumenes = new List<Resumenes>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT TOP 16 * FROM Resumenes where Aprobado = 1 and FkEscuela = " + Esc + " order by Puntuacion DESC"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                int idres = Convert.ToInt32(dataReader["IdResumen"]);
                string Nom = dataReader["Nombre"].ToString();
                int fkMat = Convert.ToInt32(dataReader["FkMateria"]);
                int fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
                int punt = Convert.ToInt32(dataReader["Puntuacion"]);
                int ano = Convert.ToInt32(dataReader["Anio"]);
                string ft = dataReader["Archivo"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                DateTime fecha = Convert.ToDateTime(dataReader["Fecha"]);
                Boolean ap = Convert.ToBoolean(dataReader["Aprobado"]);
                string des = dataReader["Descripcion"].ToString();
                Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc, ap, fecha,des);
                ListaDeResumenes.Add(resu);
            }
            dataReader.Close();
            Desconectar();
            return ListaDeResumenes;
        }


        public static int TraerIdResumenXNombre(string nom,int idUs, string nomimg, int ano, DateTime fecha)
        {
           
            int id=-1,year = fecha.Year, month=fecha.Month, day=fecha.Day;
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * from Resumenes where Nombre='"+nom+ "' and FkUsuario="+idUs+" and Archivo='"+nomimg+"' and Anio="+ano+" and Fecha='"+year+"-"+month+"-"+day+"'"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                 id = Convert.ToInt32(dataReader["IdResumen"]);
            }
            dataReader.Close();
            Desconectar();
            return id;
        }

        public static List<Resumenes> TraerResumenesXPunt()//Cuando es -1 trae todo, sino trae esa
        {

            List<Resumenes> ListaDeResumenes = new List<Resumenes>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = " SELECT TOP 16 * FROM Resumenes where Aprobado = 1 ORDER BY Puntuacion DESC"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                int idres = Convert.ToInt32(dataReader["IdResumen"]);
                string Nom = dataReader["Nombre"].ToString();
                int fkMat = Convert.ToInt32(dataReader["FkMateria"]);
                int fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
                int punt = Convert.ToInt32(dataReader["Puntuacion"]);
                int ano = Convert.ToInt32(dataReader["Anio"]);
                string ft = dataReader["Archivo"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                DateTime fecha = Convert.ToDateTime(dataReader["Fecha"]);
                Boolean ap = Convert.ToBoolean(dataReader["Aprobado"]);
                string des = dataReader["Descripcion"].ToString();

                Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc, ap, fecha,des);
                ListaDeResumenes.Add(resu);
            }
            dataReader.Close();
            Desconectar();
            return ListaDeResumenes;
        }

     


        public static void PuntuarResumen(int id) 
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = " UPDATE Resumenes set Puntuacion = (SELECT Puntuacion FROM Resumenes where IdResumen = " + id + " ) + 1 where IdResumen = " + id; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }

        public static void DespuntuarResumen(int id) 
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = " UPDATE Resumenes set Puntuacion = (SELECT Puntuacion FROM Resumenes where IdResumen = " + id + " ) - 1 where IdResumen = " + id; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }
        public static Usuarios TraerAutorResumen(int idRes)
        {
            Usuarios us = new Usuarios();
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * from Usuarios inner join Resumenes on FkUsuario = IdUsuario where IdResumen =  " + idRes; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                us.Apellido = dataReader["Apellido"].ToString();
                us.Nombre = dataReader["Nombre"].ToString();
                us.Puntuacion = Convert.ToDouble(dataReader["PuntuacionUs"]);
            }
            dataReader.Close();
            Desconectar();
            return us;
        }

        public static void AprobarResumen (int id)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "UPDATE Resumenes SET Aprobado = 1 where IdResumen ="+ id; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }

        public static string TraerNombreEscuelaxId(int id)
        {
            string Nom="";
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Escuelas WHERE IdEscuela=" + id; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
     
                Nom = dataReader["NombreEscuela"].ToString();
                
            }
            dataReader.Close();
            Desconectar();

            return Nom;
        }

        public static List<Resumenes> Buscador(string busqueda,int id)// lo usamos para el buscador
        {
            List<Resumenes> ListaResu = new List<Resumenes>();
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            if (id == -1)
            {
                command.CommandText = "SELECT * FROM Resumenes where Aprobado = 1 and Nombre like '%" + busqueda + "%' order by Puntuacion desc"; 
            }
            else
            {
                command.CommandText = "SELECT * FROM Resumenes  inner join Escuelas on FkEscuela = IdEscuela where  Aprobado = 1 and Nombre like '%" + busqueda + "%' AND IdEscuela = " + id+ "order by Puntuacion desc";
            }
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                
                int idres = Convert.ToInt32(dataReader["IdResumen"]);
                string Nom = dataReader["Nombre"].ToString();
                int fkMat = Convert.ToInt32(dataReader["FkMateria"]);
                int fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
                int punt = Convert.ToInt32(dataReader["Puntuacion"]);
                int ano = Convert.ToInt32(dataReader["Anio"]);
                string ft = dataReader["Archivo"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                DateTime fecha = Convert.ToDateTime(dataReader["Fecha"]);
                Boolean ap = Convert.ToBoolean(dataReader["Aprobado"]);
                string des = dataReader["Descripcion"].ToString();

                Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc, ap, fecha,des);
                ListaResu.Add(resu);
            }
            dataReader.Close();
            //Hasta aca buscamos x titulo, ahora buscamos x Tags
            command.CommandType = System.Data.CommandType.Text;
            string bus = "";
            for(int i=0; i < busqueda.Length; i++)
            {
                if(busqueda.Substring(i,1)!=" ")
                {
                    bus += busqueda.Substring(i, 1);
                }
            }
            if (id != -1)
            {
                command.CommandText = "SELECT * from Resumenes inner join TagsXResumen on Resumenes.IdResumen=TagsXResumen.FkResumen  inner join Tags on Tags.IdTag=TagsXResumen.FkTag  inner join Escuelas on IdEscuela=FkEscuela where Tags.Tag='" + bus + "' and FkEscuela=" + id + " order by Puntuacion desc";
            }
            else
            {
                command.CommandText = " SELECT * from Resumenes inner join TagsXResumen on Resumenes.IdResumen = TagsXResumen.FkResumen  inner join Tags on Tags.IdTag = TagsXResumen.FkTag  where Tags.Tag = '"+bus+"' order by Puntuacion desc";

            }
            SqlDataReader dataReader1 = command.ExecuteReader();
            while (dataReader1.Read())
            {
                bool esta = false;

                int idres = Convert.ToInt32(dataReader1["IdResumen"]);

                foreach (Resumenes res in ListaResu)
                {
                    if (idres == res.IdResumen)
                    {
                        esta = true;
                    }
                }
                    if (esta == false)
                    {
                        string Nom = dataReader1["Nombre"].ToString();
                        int fkMat = Convert.ToInt32(dataReader1["FkMateria"]);
                        int fkUsu = Convert.ToInt32(dataReader1["FkUsuario"]);
                        int punt = Convert.ToInt32(dataReader1["Puntuacion"]);
                        int ano = Convert.ToInt32(dataReader1["Anio"]);
                        string ft = dataReader1["Archivo"].ToString();
                        int fkesc = Convert.ToInt32(dataReader1["FkEscuela"]);
                        DateTime fecha = Convert.ToDateTime(dataReader1["Fecha"]);
                        Boolean ap = Convert.ToBoolean(dataReader1["Aprobado"]);
                        string des = dataReader1["Descripcion"].ToString();

                        Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc, ap, fecha,des);
                        ListaResu.Add(resu);
                    }
                
            }
            dataReader1.Close();
            Desconectar();
            return ListaResu;
        }
        public static List<Año> TraerAños()
        {
            List<Año> lis = new List<Año>();
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * from Ano";
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Año a = new Año();
                a.a= Convert.ToInt32(dataReader["ano"]);
                a.escri= dataReader["escri"].ToString();
                lis.Add(a);
            }
            dataReader.Close();
            Desconectar();
            return lis;
        }

        public static void InsertarTagXRes(int fkTag, int fkRes)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "Insert into TagsXResumen (FkResumen,FkTag) values ("+fkRes+","+fkTag+")"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }

        public static void InsertarTag(string tag)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "Insert into Tags (Tag) values ('"+tag+"')"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }
        public static bool EstaElTag(string tag)//busca si esta el tag, si lo encuentra devuelve true, si no devuelve false
        {
            Conectar();
            bool esta;
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * from Tags where Tag ='"+tag+"'";
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                esta = true;
            }
            else
            {
                esta = false;
            }
            dataReader.Close();
            Desconectar();
            return esta;
        }

        public static Tag BuscarTag(string tag)
        {
            Conectar();
            Tag retorno = new Tag();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * from Tags where Tag ='" + tag + "'";
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                retorno.IdTag = Convert.ToInt32(dataReader["IdTag"]);
                retorno.NombreTag = dataReader["Tag"].ToString();
            }
            dataReader.Close();
            Desconectar();
            return retorno;
        }

        public static Guardado TraerResGuardado(int idRes,int idUsu)
        {
            Guardado g = new Guardado();
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * from Guardados where FkResumen="+idRes+" and FkUsuario="+idUsu;
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                g.fkRes = Convert.ToInt32(dataReader["FkResumen"]);
                g.fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
            }
            dataReader.Close();
            Desconectar();
            return g;
        }
        public static GuardadoLib TraerLibGuardado(int idRes, int idUsu)
        {
            GuardadoLib g = new GuardadoLib();
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * from GuardadoLi where FkLibro=" + idRes + " and FkUsuario=" + idUsu;
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                g.fkLib = Convert.ToInt32(dataReader["FkLibro"]);
                g.fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
            }
            dataReader.Close();
            Desconectar();
            return g;
        }

        public static void EliminarGuardado(int idRes, int idUs)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM Guardados WHERE FkResumen =" + idRes+" and FkUsuario ="+idUs; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }
        public static void AgregarGuardado (int idRes,int idUs)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT into Guardados(FkResumen,FkUsuario) values ("+idRes+","+idUs+")"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }
        public static void AgregarGuardadoLib(int idRes, int idUs)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT into GuardadoLi(FkLibro,FkUsuario) values (" + idRes + "," + idUs + ")"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }
        public static void EliminarGuardadoLib(int idRes, int idUs)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM GuardadoLi WHERE FkLibro =" + idRes + " and FkUsuario =" + idUs; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }

        public static void AgregarVoto(int res, int us)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT into VotosXUsuario(FkResumen,FkUsuario) values (" + res + "," + us + ")"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }

        public static void EliminarVoto(int res, int us)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE from VotosXUsuario where FkResumen="+res+" and FkUsuario="+us; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }
        public static bool VerSiVoto(int res, int us)
        {
            Conectar();
            bool esta;
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * from VotosXUsuario where FkUsuario =" + us + " and FkResumen ="+res;
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                esta = true;
            }
            else
            {
                esta = false;
            }
            dataReader.Close();
            Desconectar();
            return esta;
        }

        public static void AgregarComentario (Comentario com)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT into Comentarios(Contenido,FkResumen,FkUsuario,Fecha)values('" +com.Contenido+"',"+com.FkResumen+","+com.FkUsuario+",'"+com.Fecha.Year+"-"+com.Fecha.Month+"-"+com.Fecha.Day+"')"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }
        public static List<Comentario> TraerComentarios(int idRes)
        {
            List<Comentario> listaComents = new List<Comentario>();
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * From Comentarios where FkResumen=" + idRes+"order by Fecha desc"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Comentario com = new Comentario();
                com.Contenido = dataReader["Contenido"].ToString();
                com.FkResumen = Convert.ToInt32(dataReader["FkResumen"]);
                com.FkUsuario = Convert.ToInt32(dataReader["FkUsuario"]);
                com.IdComentario= Convert.ToInt32(dataReader["IdComentario"]);
                com.Fecha= Convert.ToDateTime(dataReader["Fecha"]);
                listaComents.Add(com);
            }
            dataReader.Close();
            Desconectar();
            return listaComents;
        }
        public static string TraerNombreUsuario(int idUs)
        {
            string nombre = "";
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * From Usuarios where IdUsuario=" + idUs; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                string n= dataReader["Nombre"].ToString();
                string a= dataReader["Apellido"].ToString();
                nombre = n + " " + a;
            }
            dataReader.Close();
            Desconectar();
            return nombre;
        }
        public static List<int> TraerIdDeResumenesGuardados (int idUs)
        {
            List<int> listaids = new List<int>();
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * From Guardados where FkUsuario=" + idUs; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                int id=-1;
                id= Convert.ToInt32(dataReader["FkResumen"]);
                listaids.Add(id);
            }
            dataReader.Close();
            Desconectar();
            return listaids;
        }
        public static List<int> TraerIdDeLibroGuardados(int idUs)
        {
            List<int> listaids = new List<int>();
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * From GuardadoLi where FkUsuario=" + idUs; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                int id = -1;
                id = Convert.ToInt32(dataReader["FkLibro"]);
                listaids.Add(id);
            }
            dataReader.Close();
            Desconectar();
            return listaids;
        }

        public static List<int> TraerIdTagsXResumen(int id)
        {
            List<int> lista = new List<int>();
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = " SELECT * FROM TagsXResumen where FkResumen=" + id; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                int i =Convert.ToInt32(dataReader["FkTag"]);
                lista.Add(i);
            }
            dataReader.Close();
            Desconectar();
            return lista;
        }

        public static string TraerTagXid(int id)
        {
            string tag="";
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = " SELECT * FROM Tags where IdTag=" + id; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                tag= dataReader["Tag"].ToString();
            }
            dataReader.Close();
            Desconectar();
            return tag;
        }
        public static List<Resumenes> TraerResumenesDelUsuario(int idUs)
        {
            List<Resumenes> ListaDeResumenes = new List<Resumenes>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = " SELECT * FROM Resumenes where FkUsuario="+idUs; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                int idres = Convert.ToInt32(dataReader["IdResumen"]);
                string Nom = dataReader["Nombre"].ToString();
                int fkMat = Convert.ToInt32(dataReader["FkMateria"]);
                int fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
                int punt = Convert.ToInt32(dataReader["Puntuacion"]);
                int ano = Convert.ToInt32(dataReader["Anio"]);
                string ft = dataReader["Archivo"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                DateTime fecha = Convert.ToDateTime(dataReader["Fecha"]);
                Boolean ap = Convert.ToBoolean(dataReader["Aprobado"]);
                string des = dataReader["Descripcion"].ToString();

                Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc, ap, fecha, des);
                ListaDeResumenes.Add(resu);
            }
            dataReader.Close();
            Desconectar();
            return ListaDeResumenes;
        }
        public static List<Libro> TraerLibroDelUsuario(int idUs)
        {
            List<Libro> ListaDeResumenes = new List<Libro>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = " SELECT * FROM Libros where FkVendedor=" + idUs; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                int idli = Convert.ToInt32(dataReader["IdLibro"]);
                string Nom = dataReader["Nombre"].ToString();
                int pre = Convert.ToInt32(dataReader["Precio"]);
                int fkven = Convert.ToInt32(dataReader["FkVendedor"]);
                int fkma = Convert.ToInt32(dataReader["FkMateria"]);
                string edi = dataReader["Editorial"].ToString();
                string lu = dataReader["Lugar"].ToString();
                string im = dataReader["NombreImagen"].ToString();
                int fka = Convert.ToInt32(dataReader["FkAno"]);
                Boolean ap = Convert.ToBoolean(dataReader["Aprobado"]);
                string div = dataReader["Division"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                int fkcom = Convert.ToInt32(dataReader["FkComprador"]);
                string des = dataReader["Descripcion"].ToString();
                int tel = Convert.ToInt32(dataReader["Telefono"]);
                string mp = dataReader["LinkMP"].ToString();

                Libro resu = new Libro(idli, Nom, pre, fkven, fkma, edi, lu, im, fka, ap, div, fkesc, fkcom, des, tel, mp);
                ListaDeResumenes.Add(resu);
            }
            dataReader.Close();
            Desconectar();
            return ListaDeResumenes;
        }

        public static Usuarios TraerUsuario(int idUs)
        {
            Usuarios usu = new Usuarios();
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * From Usuarios where IdUsuario=" + idUs; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                usu.IdUsuario= Convert.ToInt32(dataReader["IdUsuario"]);
                usu.Nombre = dataReader["Nombre"].ToString();
                usu.Apellido = dataReader["Apellido"].ToString();
                usu.Admin= Convert.ToBoolean(dataReader["Admin"]);
                usu.NombreImagen= dataReader["FotoPerfil"].ToString();
                usu.Creditos= Convert.ToInt32(dataReader["Creditos"]);
                usu.Escuela= Convert.ToInt32(dataReader["FkEscuela"]);
                usu.Puntuacion= Convert.ToInt32(dataReader["PuntuacionUs"]);
                usu.Mail= dataReader["Mail"].ToString();
                usu.Username= dataReader["Username"].ToString();
            }
            dataReader.Close();
            Desconectar();
            return usu;
        }
        public static void ModificarPerfil (Usuarios us)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            if (us.NombreImagen == null)
            {//cdo no cambia la ft
                command.CommandText = "UPDATE Usuarios SET Username='"+us.Username+"', Mail='"+us.Mail+"', Nombre='"+us.Nombre+"',  Apellido='"+us.Apellido+"', FkEscuela="+us.Escuela+"  where IdUsuario="+us.IdUsuario; //Consulta
            }
            else
            {//cdo si cambia la ft
                command.CommandText = "UPDATE Usuarios SET Username='" + us.Username + "', Mail='" + us.Mail + "', Nombre='" + us.Nombre + "',  Apellido='" + us.Apellido + "', FkEscuela=" + us.Escuela + ", FotoPerfil='" + us.NombreImagen + "'  where IdUsuario=" + us.IdUsuario; //Consulta
            }
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }

      public static List<Denuncia> TraerDenuncias()
        {
            List<Denuncia> listaDenuncias = new List<Denuncia>();
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT* FROM Denuncias order by FkTipoDeDenuncia DESC"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Denuncia den = new Denuncia();
                den.IdDenuncia= Convert.ToInt32(dataReader["IdDenuncia"]);
                den.FkUsuario= Convert.ToInt32(dataReader["FkUsuario"]);
                den.FkResumen= Convert.ToInt32(dataReader["FkResumen"]);
                den.FkMotivo= Convert.ToInt32(dataReader["FkTipoDeDenuncia"]);
                listaDenuncias.Add(den);

            }
            dataReader.Close();
            Desconectar();
            return listaDenuncias;
        }

        public static Denuncia TraerDenunciaEspe(int id)
        {
            Denuncia den = new Denuncia();
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT* FROM Denuncias WHERE IdDenuncia ="+id; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                den.IdDenuncia = Convert.ToInt32(dataReader["IdDenuncia"]);
                den.FkUsuario = Convert.ToInt32(dataReader["FkUsuario"]);
                den.FkResumen = Convert.ToInt32(dataReader["FkResumen"]);
                den.FkMotivo = Convert.ToInt32(dataReader["FkTipoDeDenuncia"]);

            }
            dataReader.Close();
            Desconectar();
            return den;
        }

        public static Motivo TraerMotivoEspe(int id)
        {
            Motivo Etlis = new Motivo();
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT* FROM TiposDeDenuncia where IdTipoDenuncia="+id; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Etlis.IdMotivo = Convert.ToInt32(dataReader["IdTipoDenuncia"]);
                Etlis.Moti= dataReader["TipoDenuncia"].ToString();
            }
            dataReader.Close();
            Desconectar();
            return Etlis;
        }

        public static List<Motivo> TraerMotivos()
        {
            List<Motivo> Diegote = new List<Motivo>();          
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT* FROM TiposDeDenuncia"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Motivo Etlis = new Motivo();
                Etlis.IdMotivo = Convert.ToInt32(dataReader["IdTipoDenuncia"]);
                Etlis.Moti = dataReader["TipoDenuncia"].ToString();
                Diegote.Add(Etlis);
            }
            dataReader.Close();
            Desconectar();
            return Diegote;
        }
        public static void AgregarDenuncia (ComentariosYDenuncias com)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = " INSERT into Denuncias (FkResumen,FkTipoDeDenuncia,FkUsuario) values ("+com.FkResumen+","+com.FkMotivo+","+com.FkUsuario+")"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }
        public static List<Resumenes> TraerResumenesSinAprobar()
        {
            List<Resumenes> ListaDeResumenes = new List<Resumenes>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT* FROM Resumenes where Aprobado = 0"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                int idres = Convert.ToInt32(dataReader["IdResumen"]);
                string Nom = dataReader["Nombre"].ToString();
                int fkMat = Convert.ToInt32(dataReader["FkMateria"]);
                int fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
                int punt = Convert.ToInt32(dataReader["Puntuacion"]);
                int ano = Convert.ToInt32(dataReader["Anio"]);
                string ft = dataReader["Archivo"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                DateTime fecha = Convert.ToDateTime(dataReader["Fecha"]);
                Boolean ap = Convert.ToBoolean(dataReader["Aprobado"]);
                string des = dataReader["Descripcion"].ToString();

                Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc, ap, fecha, des);
                ListaDeResumenes.Add(resu);
            }
            dataReader.Close();
            Desconectar();
            return ListaDeResumenes;
        }

        public static void BorrarDenuncia (int id)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM Denuncias where IdDenuncia="+id; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }
        public static void BorrarMateria(int id)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM Materias where IdMateria=" + id; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }

        public static void BorrarEscuela(int id)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM Escuelas where IdEscuela=" + id; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }

        public static bool VerContraVieja(string s, int id)
        {
            bool retorno = false;
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Usuarios WHERE IdUsuario =" + id +" and Contrasena ='"+s+"'"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                retorno = true;
            }
            dataReader.Close();
            Desconectar();
            return retorno;
        }

        public static void CambiarContra (Contra c)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "UPDATE Usuarios set Contrasena = '"+ c.Contra1+ "' where IdUsuario =" +c.idUsuario; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }

        public static bool ValidarUsuarioExistente(string us)
        {
            bool retorno = false;
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Usuarios WHERE Username ='"+us + "'"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                retorno = true;
            }
            dataReader.Close();
            Desconectar();
            return retorno;
        }

        public static string TraerContra (int id)
        {
            string retorno = "";
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT Contrasena FROM Usuarios WHERE IdUsuario="+id; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                retorno = dataReader["Contrasena"].ToString();
            }
            dataReader.Close();
            Desconectar();
            return retorno;
        }

        public static List<Resumenes> BuscadorXEsc(string busqueda, int id)// lo usamos para el buscador
        {
            List<Resumenes> ListaResu = new List<Resumenes>();
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Resumenes  inner join Escuelas on FkEscuela = IdEscuela where  Aprobado = 1 and Nombre like '%" + busqueda + "%' AND IdEscuela = " + id + "order by Puntuacion desc";
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                int idres = Convert.ToInt32(dataReader["IdResumen"]);
                string Nom = dataReader["Nombre"].ToString();
                int fkMat = Convert.ToInt32(dataReader["FkMateria"]);
                int fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
                int punt = Convert.ToInt32(dataReader["Puntuacion"]);
                int ano = Convert.ToInt32(dataReader["Anio"]);
                string ft = dataReader["Archivo"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                DateTime fecha = Convert.ToDateTime(dataReader["Fecha"]);
                Boolean ap = Convert.ToBoolean(dataReader["Aprobado"]);
                string des = dataReader["Descripcion"].ToString();

                Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc, ap, fecha, des);
                ListaResu.Add(resu);
            }
            dataReader.Close();
            //Hasta aca buscamos x titulo, ahora buscamos x Tags
            command.CommandType = System.Data.CommandType.Text;
            string bus = "";
            for (int i = 0; i < busqueda.Length; i++)
            {
                if (busqueda.Substring(i, 1) != " ")
                {
                    bus += busqueda.Substring(i, 1);
                }
            }
            command.CommandText = " SELECT * from Resumenes inner join TagsXResumen on Resumenes.IdResumen = TagsXResumen.FkResumen  inner join Tags on Tags.IdTag = TagsXResumen.FkTag  where Tags.Tag = '" + bus + "' and Resumenes.FkEscuela="+id+" order by Puntuacion desc";
            SqlDataReader dataReader1 = command.ExecuteReader();
            while (dataReader1.Read())
            {
                bool esta = false;

                int idres = Convert.ToInt32(dataReader1["IdResumen"]);

                foreach (Resumenes res in ListaResu)
                {
                    if (idres == res.IdResumen)
                    {
                        esta = true;
                    }
                }
                if (esta == false)
                {
                    string Nom = dataReader1["Nombre"].ToString();
                    int fkMat = Convert.ToInt32(dataReader1["FkMateria"]);
                    int fkUsu = Convert.ToInt32(dataReader1["FkUsuario"]);
                    int punt = Convert.ToInt32(dataReader1["Puntuacion"]);
                    int ano = Convert.ToInt32(dataReader1["Anio"]);
                    string ft = dataReader1["Archivo"].ToString();
                    int fkesc = Convert.ToInt32(dataReader1["FkEscuela"]);
                    DateTime fecha = Convert.ToDateTime(dataReader1["Fecha"]);
                    Boolean ap = Convert.ToBoolean(dataReader1["Aprobado"]);
                    string des = dataReader1["Descripcion"].ToString();

                    Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc, ap, fecha, des);
                    ListaResu.Add(resu);
                }

            }
            dataReader1.Close();
            Desconectar();
            return ListaResu;
        }



        public static List<Resumenes> BuscadorXMat(string busqueda, int id)// lo usamos para el buscador
        {
            List<Resumenes> ListaResu = new List<Resumenes>();
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Resumenes  inner join Materias on FkMateria = IdMateria where  Aprobado = 1 and Nombre like '%"+busqueda+"%' AND IdMateria = "+id+" order by Puntuacion desc  ";
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                int idres = Convert.ToInt32(dataReader["IdResumen"]);
                string Nom = dataReader["Nombre"].ToString();
                int fkMat = Convert.ToInt32(dataReader["FkMateria"]);
                int fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
                int punt = Convert.ToInt32(dataReader["Puntuacion"]);
                int ano = Convert.ToInt32(dataReader["Anio"]);
                string ft = dataReader["Archivo"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                DateTime fecha = Convert.ToDateTime(dataReader["Fecha"]);
                Boolean ap = Convert.ToBoolean(dataReader["Aprobado"]);
                string des = dataReader["Descripcion"].ToString();

                Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc, ap, fecha, des);
                ListaResu.Add(resu);
            }
            dataReader.Close();
            //Hasta aca buscamos x titulo, ahora buscamos x Tags
            command.CommandType = System.Data.CommandType.Text;
            string bus = "";
            for (int i = 0; i < busqueda.Length; i++)
            {
                if (busqueda.Substring(i, 1) != " ")
                {
                    bus += busqueda.Substring(i, 1);
                }
            }
            command.CommandText = " SELECT * from Resumenes inner join TagsXResumen on Resumenes.IdResumen = TagsXResumen.FkResumen  inner join Tags on Tags.IdTag = TagsXResumen.FkTag  where Tags.Tag = '" + bus + "' AND Resumenes.FkMateria = " + id + " order by Puntuacion desc";
            SqlDataReader dataReader1 = command.ExecuteReader();
            while (dataReader1.Read())
            {
                bool esta = false;

                int idres = Convert.ToInt32(dataReader1["IdResumen"]);

                foreach (Resumenes res in ListaResu)
                {
                    if (idres == res.IdResumen)
                    {
                        esta = true;
                    }
                }
                if (esta == false)
                {
                    string Nom = dataReader1["Nombre"].ToString();
                    int fkMat = Convert.ToInt32(dataReader1["FkMateria"]);
                    int fkUsu = Convert.ToInt32(dataReader1["FkUsuario"]);
                    int punt = Convert.ToInt32(dataReader1["Puntuacion"]);
                    int ano = Convert.ToInt32(dataReader1["Anio"]);
                    string ft = dataReader1["Archivo"].ToString();
                    int fkesc = Convert.ToInt32(dataReader1["FkEscuela"]);
                    DateTime fecha = Convert.ToDateTime(dataReader1["Fecha"]);
                    Boolean ap = Convert.ToBoolean(dataReader1["Aprobado"]);
                    string des = dataReader1["Descripcion"].ToString();

                    Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc, ap, fecha, des);
                    ListaResu.Add(resu);
                }

            }
            dataReader1.Close();
            Desconectar();
            return ListaResu;
        }

        public static List<Resumenes> BuscadorXAno(string busqueda, int id)// lo usamos para el buscador
        {
            List<Resumenes> ListaResu = new List<Resumenes>();
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Resumenes  inner join Ano on Anio = ano where  Aprobado = 1 and Nombre like '%"+busqueda+"%' AND Anio = "+id+" order by Puntuacion desc";
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                int idres = Convert.ToInt32(dataReader["IdResumen"]);
                string Nom = dataReader["Nombre"].ToString();
                int fkMat = Convert.ToInt32(dataReader["FkMateria"]);
                int fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
                int punt = Convert.ToInt32(dataReader["Puntuacion"]);
                int ano = Convert.ToInt32(dataReader["Anio"]);
                string ft = dataReader["Archivo"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                DateTime fecha = Convert.ToDateTime(dataReader["Fecha"]);
                Boolean ap = Convert.ToBoolean(dataReader["Aprobado"]);
                string des = dataReader["Descripcion"].ToString();

                Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc, ap, fecha, des);
                ListaResu.Add(resu);
            }
            dataReader.Close();
            //Hasta aca buscamos x titulo, ahora buscamos x Tags
            command.CommandType = System.Data.CommandType.Text;
            string bus = "";
            for (int i = 0; i < busqueda.Length; i++)
            {
                if (busqueda.Substring(i, 1) != " ")
                {
                    bus += busqueda.Substring(i, 1);
                }
            }
            command.CommandText = " SELECT * from Resumenes inner join TagsXResumen on Resumenes.IdResumen = TagsXResumen.FkResumen  inner join Tags on Tags.IdTag = TagsXResumen.FkTag  where Tags.Tag = '" + bus + "' AND Anio = " + id + " order by Puntuacion desc";
            SqlDataReader dataReader1 = command.ExecuteReader();
            while (dataReader1.Read())
            {
                bool esta = false;

                int idres = Convert.ToInt32(dataReader1["IdResumen"]);

                foreach (Resumenes res in ListaResu)
                {
                    if (idres == res.IdResumen)
                    {
                        esta = true;
                    }
                }
                if (esta == false)
                {
                    string Nom = dataReader1["Nombre"].ToString();
                    int fkMat = Convert.ToInt32(dataReader1["FkMateria"]);
                    int fkUsu = Convert.ToInt32(dataReader1["FkUsuario"]);
                    int punt = Convert.ToInt32(dataReader1["Puntuacion"]);
                    int ano = Convert.ToInt32(dataReader1["Anio"]);
                    string ft = dataReader1["Archivo"].ToString();
                    int fkesc = Convert.ToInt32(dataReader1["FkEscuela"]);
                    DateTime fecha = Convert.ToDateTime(dataReader1["Fecha"]);
                    Boolean ap = Convert.ToBoolean(dataReader1["Aprobado"]);
                    string des = dataReader1["Descripcion"].ToString();

                    Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc, ap, fecha, des);
                    ListaResu.Add(resu);
                }

            }
            dataReader1.Close();
            Desconectar();
            return ListaResu;
        }

        public static Usuarios VerMailSiExiste(string mail)
        {
            Usuarios usu = new Usuarios(); 
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Usuarios where Mail ='" + mail + "'"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                usu.IdUsuario=Convert.ToInt32(dataReader["IdUsuario"]);
                usu.Nombre = dataReader["Nombre"].ToString();
                usu.Apellido = dataReader["Apellido"].ToString();
                usu.Admin = Convert.ToBoolean(dataReader["Admin"]);
                usu.NombreImagen = dataReader["FotoPerfil"].ToString();
                usu.Creditos = Convert.ToInt32(dataReader["Creditos"]);
                usu.Escuela = Convert.ToInt32(dataReader["FkEscuela"]);
                usu.Puntuacion = Convert.ToInt32(dataReader["PuntuacionUs"]);
                usu.Mail = dataReader["Mail"].ToString();
                usu.Username = dataReader["Username"].ToString();
            }
            dataReader.Close();
            Desconectar();
            return usu;

        }

        public static List<Libro> TraerLibros()
        {
            List<Libro> lista = new List<Libro>();
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select top 16 * from Libros where Aprobado = 1"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Libro M = new Libro();
                M.IdLibro = Convert.ToInt32(dataReader["IdLibro"]);
                M.Nombre = dataReader["Nombre"].ToString();
                M.Precio = Convert.ToDouble(dataReader["Precio"]);
                M.FkVendedor = Convert.ToInt32(dataReader["FkVendedor"]);
                M.FkAno = Convert.ToInt32(dataReader["FkAno"]);
                M.FkMateria = Convert.ToInt32(dataReader["FkMateria"]);
                M.FkEscuela = Convert.ToInt32(dataReader["FkEscuela"]);
                M.FkComprador = Convert.ToInt32(dataReader["FkComprador"]);
                M.Editorial = dataReader["Editorial"].ToString();
                M.Lugar = dataReader["Lugar"].ToString();
                M.NombreImagen = dataReader["NombreImagen"].ToString();
                M.Division = dataReader["Division"].ToString();
                M.Descripcion = dataReader["Descripcion"].ToString();
                M.Aprobado = Convert.ToBoolean(dataReader["Aprobado"]);
                M.Telefono = Convert.ToInt32(dataReader["Telefono"]);
                M.LinkMP = dataReader["LinkMP"].ToString();
                lista.Add(M);
            }
            dataReader.Close();
            Desconectar();
            return lista;
        }

        public static Libro TraerLibro(int idlibro)
        {
            Libro M = new Libro();
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Libros where IdLibro = " + idlibro; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                
                M.IdLibro = Convert.ToInt32(dataReader["IdLibro"]);
                M.Nombre = dataReader["Nombre"].ToString();
                M.Precio = Convert.ToDouble(dataReader["Precio"]);
                M.FkVendedor = Convert.ToInt32(dataReader["FkVendedor"]);
                M.FkAno = Convert.ToInt32(dataReader["FkAno"]);
                M.FkMateria = Convert.ToInt32(dataReader["FkMateria"]);
                M.FkEscuela = Convert.ToInt32(dataReader["FkEscuela"]);
                M.FkComprador = Convert.ToInt32(dataReader["FkComprador"]);
                M.Editorial = dataReader["Editorial"].ToString();
                M.Lugar = dataReader["Lugar"].ToString();
                M.NombreImagen = dataReader["NombreImagen"].ToString();
                M.Division = dataReader["Division"].ToString();
                M.Descripcion = dataReader["Descripcion"].ToString();
                M.Aprobado = Convert.ToBoolean(dataReader["Aprobado"]);
                M.Telefono = Convert.ToInt32(dataReader["Telefono"]);
                M.LinkMP = dataReader["LinkMP"].ToString();
            }
            dataReader.Close();
            Desconectar();
            return M;
        }

        public static void InsertarLibro (Libro l)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT into Libros (Nombre,Precio,FkVendedor,FkMateria,Editorial,Lugar,NombreImagen,FkAno,Aprobado,Division,FkEscuela,FkComprador,Descripcion,Telefono,LinkMP) VALUES ('"+l.Nombre+"',"+l.Precio+","+l.FkVendedor+","+l.FkMateria+",'"+l.Editorial+"','"+l.Lugar+"','"+l.NombreImagen+"'," +l.FkAno+",0,'"+l.Division+"',"+l.FkEscuela+",-1,'"+l.Descripcion+"',"+l.Telefono+",' ')"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }
        public static List<Libro> TraerBuscadorLibros (BuscadorLibros b)
        {
            List<Libro> lista = new List<Libro>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Libros where Aprobado = 1 and Nombre like '%" + b.Busueda + "%'"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Libro M = new Libro();
                M.IdLibro = Convert.ToInt32(dataReader["IdLibro"]);
                M.Nombre = dataReader["Nombre"].ToString();
                M.Precio = Convert.ToDouble(dataReader["Precio"]);
                M.FkVendedor = Convert.ToInt32(dataReader["FkVendedor"]);
                M.FkAno = Convert.ToInt32(dataReader["FkAno"]);
                M.FkMateria = Convert.ToInt32(dataReader["FkMateria"]);
                M.FkEscuela = Convert.ToInt32(dataReader["FkEscuela"]);
                M.FkComprador = Convert.ToInt32(dataReader["FkComprador"]);
                M.Editorial = dataReader["Editorial"].ToString();
                M.Lugar = dataReader["Lugar"].ToString();
                M.NombreImagen = dataReader["NombreImagen"].ToString();
                M.Division = dataReader["Division"].ToString();
                M.Descripcion = dataReader["Descripcion"].ToString();
                M.Aprobado = Convert.ToBoolean(dataReader["Aprobado"]);
                M.Telefono = Convert.ToInt32(dataReader["Telefono"]);
                M.LinkMP = dataReader["LinkMP"].ToString();
                lista.Add(M);
            }
            dataReader.Close();
            Desconectar();
            return lista;
        }
        public static List<Libro> BuscadorXEscLibro(string b, int id)
        {
            List<Libro> lista = new List<Libro>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Libros where Aprobado = 1 and FkEscuela = "+id+" and Nombre like '%" + b + "%'"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Libro M = new Libro();
                M.IdLibro = Convert.ToInt32(dataReader["IdLibro"]);
                M.Nombre = dataReader["Nombre"].ToString();
                M.Precio = Convert.ToDouble(dataReader["Precio"]);
                M.FkVendedor = Convert.ToInt32(dataReader["FkVendedor"]);
                M.FkAno = Convert.ToInt32(dataReader["FkAno"]);
                M.FkMateria = Convert.ToInt32(dataReader["FkMateria"]);
                M.FkEscuela = Convert.ToInt32(dataReader["FkEscuela"]);
                M.FkComprador = Convert.ToInt32(dataReader["FkComprador"]);
                M.Editorial = dataReader["Editorial"].ToString();
                M.Lugar = dataReader["Lugar"].ToString();
                M.NombreImagen = dataReader["NombreImagen"].ToString();
                M.Division = dataReader["Division"].ToString();
                M.Descripcion = dataReader["Descripcion"].ToString();
                M.Aprobado = Convert.ToBoolean(dataReader["Aprobado"]);
                M.Telefono = Convert.ToInt32(dataReader["Telefono"]);
                M.LinkMP = dataReader["LinkMP"].ToString();
                lista.Add(M);
            }
            dataReader.Close();
            Desconectar();
            return lista;
        }
        public static List<Libro> BuscadorXAnoLibro(string b, int id)
        {
            List<Libro> lista = new List<Libro>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Libros where Aprobado = 1 and FkAno ="+id+" and Nombre like '%" + b + "%'"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Libro M = new Libro();
                M.IdLibro = Convert.ToInt32(dataReader["IdLibro"]);
                M.Nombre = dataReader["Nombre"].ToString();
                M.Precio = Convert.ToDouble(dataReader["Precio"]);
                M.FkVendedor = Convert.ToInt32(dataReader["FkVendedor"]);
                M.FkAno = Convert.ToInt32(dataReader["FkAno"]);
                M.FkMateria = Convert.ToInt32(dataReader["FkMateria"]);
                M.FkEscuela = Convert.ToInt32(dataReader["FkEscuela"]);
                M.FkComprador = Convert.ToInt32(dataReader["FkComprador"]);
                M.Editorial = dataReader["Editorial"].ToString();
                M.Lugar = dataReader["Lugar"].ToString();
                M.NombreImagen = dataReader["NombreImagen"].ToString();
                M.Division = dataReader["Division"].ToString();
                M.Descripcion = dataReader["Descripcion"].ToString();
                M.Aprobado = Convert.ToBoolean(dataReader["Aprobado"]);
                M.Telefono = Convert.ToInt32(dataReader["Telefono"]);
                M.LinkMP = dataReader["LinkMP"].ToString();
                lista.Add(M);
            }
            dataReader.Close();
            Desconectar();
            return lista;
        }
        public static List<Libro> BuscadorXMatLibro(string b, int id)
        {
            List<Libro> lista = new List<Libro>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Libros where Aprobado = 1 and FkMateria ="+id+" and Nombre like '%" + b + "%'"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Libro M = new Libro();
                M.IdLibro = Convert.ToInt32(dataReader["IdLibro"]);
                M.Nombre = dataReader["Nombre"].ToString();
                M.Precio = Convert.ToDouble(dataReader["Precio"]);
                M.FkVendedor = Convert.ToInt32(dataReader["FkVendedor"]);
                M.FkAno = Convert.ToInt32(dataReader["FkAno"]);
                M.FkMateria = Convert.ToInt32(dataReader["FkMateria"]);
                M.FkEscuela = Convert.ToInt32(dataReader["FkEscuela"]);
                M.FkComprador = Convert.ToInt32(dataReader["FkComprador"]);
                M.Editorial = dataReader["Editorial"].ToString();
                M.Lugar = dataReader["Lugar"].ToString();
                M.NombreImagen = dataReader["NombreImagen"].ToString();
                M.Division = dataReader["Division"].ToString();
                M.Descripcion = dataReader["Descripcion"].ToString();
                M.Aprobado = Convert.ToBoolean(dataReader["Aprobado"]);
                M.Telefono = Convert.ToInt32(dataReader["Telefono"]);
                M.LinkMP = dataReader["LinkMP"].ToString();
                lista.Add(M);
            }
            dataReader.Close();
            Desconectar();
            return lista;
        }

        public static void InsertarMateria(string s)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT into Materias (NombreMateria) Values ('"+s+"')"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }
        public static void InsertarEscuela(string s)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT into Escuelas (NombreEscuela) Values ('" + s + "')"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }
           public static List<Resumenes> MasResumenes(int cant)
        {

            List<Resumenes> ListaDeResumenes = new List<Resumenes>();
            int cantidad = cant * 16;
            cantidad += 16;
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = " SELECT TOP " + cantidad + " * FROM Resumenes where Aprobado = 1 ORDER BY Puntuacion DESC"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                int idres = Convert.ToInt32(dataReader["IdResumen"]);
                string Nom = dataReader["Nombre"].ToString();
                int fkMat = Convert.ToInt32(dataReader["FkMateria"]);
                int fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
                int punt = Convert.ToInt32(dataReader["Puntuacion"]);
                int ano = Convert.ToInt32(dataReader["Anio"]);
                string ft = dataReader["Archivo"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                DateTime fecha = Convert.ToDateTime(dataReader["Fecha"]);
                Boolean ap = Convert.ToBoolean(dataReader["Aprobado"]);
                string des = dataReader["Descripcion"].ToString();

                Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc, ap, fecha, des);
                ListaDeResumenes.Add(resu);
            }
            dataReader.Close();
            Desconectar();
            int resta = cant * 16;

            ListaDeResumenes.RemoveRange(0, resta);

            return ListaDeResumenes;
        }
        public static List<Resumenes> MasResumenesEsc(int cant,int idEsc)
        {

            List<Resumenes> ListaDeResumenes = new List<Resumenes>();
            int cantidad = cant * 16;
            cantidad += 16;
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = " SELECT TOP " + cantidad + " * FROM Resumenes where Aprobado = 1 and FkEscuela = "+idEsc+"  ORDER BY Puntuacion DESC"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                int idres = Convert.ToInt32(dataReader["IdResumen"]);
                string Nom = dataReader["Nombre"].ToString();
                int fkMat = Convert.ToInt32(dataReader["FkMateria"]);
                int fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
                int punt = Convert.ToInt32(dataReader["Puntuacion"]);
                int ano = Convert.ToInt32(dataReader["Anio"]);
                string ft = dataReader["Archivo"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                DateTime fecha = Convert.ToDateTime(dataReader["Fecha"]);
                Boolean ap = Convert.ToBoolean(dataReader["Aprobado"]);
                string des = dataReader["Descripcion"].ToString();

                Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc, ap, fecha, des);
                ListaDeResumenes.Add(resu);
            }
            dataReader.Close();
            Desconectar();
            int resta = cant * 16;

            ListaDeResumenes.RemoveRange(0, resta);

            return ListaDeResumenes;
        }
        public static List<Resumenes> TraerPaginaAnteriorEsc(int cant,int idEsc)
        {


            List<Resumenes> ListaDeResumenes = new List<Resumenes>();
            int cantidad = cant * 16;
            cantidad -= 16;
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = " SELECT TOP " + cantidad + " * FROM Resumenes where Aprobado = 1 and FkEscuela = "+idEsc+" ORDER BY Puntuacion DESC"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                int idres = Convert.ToInt32(dataReader["IdResumen"]);
                string Nom = dataReader["Nombre"].ToString();
                int fkMat = Convert.ToInt32(dataReader["FkMateria"]);
                int fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
                int punt = Convert.ToInt32(dataReader["Puntuacion"]);
                int ano = Convert.ToInt32(dataReader["Anio"]);
                string ft = dataReader["Archivo"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                DateTime fecha = Convert.ToDateTime(dataReader["Fecha"]);
                Boolean ap = Convert.ToBoolean(dataReader["Aprobado"]);
                string des = dataReader["Descripcion"].ToString();

                Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc, ap, fecha, des);
                ListaDeResumenes.Add(resu);
            }
            dataReader.Close();
            Desconectar();
            int resta = cant - 2;
            resta = resta * 16;
            if (resta != 0)
            {
                ListaDeResumenes.RemoveRange(0, resta);
            }

            return ListaDeResumenes;
        }
        public static List<Resumenes> TraerPaginaAnterior(int cant)
        {


            List<Resumenes> ListaDeResumenes = new List<Resumenes>();
            int cantidad = cant * 16;
            cantidad -= 16;
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = " SELECT TOP " + cantidad + " * FROM Resumenes where Aprobado = 1 ORDER BY Puntuacion DESC"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                int idres = Convert.ToInt32(dataReader["IdResumen"]);
                string Nom = dataReader["Nombre"].ToString();
                int fkMat = Convert.ToInt32(dataReader["FkMateria"]);
                int fkUsu = Convert.ToInt32(dataReader["FkUsuario"]);
                int punt = Convert.ToInt32(dataReader["Puntuacion"]);
                int ano = Convert.ToInt32(dataReader["Anio"]);
                string ft = dataReader["Archivo"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                DateTime fecha = Convert.ToDateTime(dataReader["Fecha"]);
                Boolean ap = Convert.ToBoolean(dataReader["Aprobado"]);
                string des = dataReader["Descripcion"].ToString();

                Resumenes resu = new Resumenes(idres, Nom, fkMat, fkUsu, punt, ano, ft, fkesc, ap, fecha, des);
                ListaDeResumenes.Add(resu);
            }
            dataReader.Close();
            Desconectar();
            int resta = cant -2;
            resta = resta * 16;
            if (resta != 0)
            {
                ListaDeResumenes.RemoveRange(0, resta);
            }

            return ListaDeResumenes;
        }

        public static List<Libro> TraerPaginaAnteriorLibros(int cant)
        {


            List<Libro> ListaDeLibros = new List<Libro>();
            int cantidad = cant * 16;
            cantidad -= 16;
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = " SELECT TOP " + cantidad + " * FROM Libros where Aprobado = 1"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                Libro M = new Libro();
                M.IdLibro = Convert.ToInt32(dataReader["IdLibro"]);
                M.Nombre = dataReader["Nombre"].ToString();
                M.Precio = Convert.ToDouble(dataReader["Precio"]);
                M.FkVendedor = Convert.ToInt32(dataReader["FkVendedor"]);
                M.FkAno = Convert.ToInt32(dataReader["FkAno"]);
                M.FkMateria = Convert.ToInt32(dataReader["FkMateria"]);
                M.FkEscuela = Convert.ToInt32(dataReader["FkEscuela"]);
                M.FkComprador = Convert.ToInt32(dataReader["FkComprador"]);
                M.Editorial = dataReader["Editorial"].ToString();
                M.Lugar = dataReader["Lugar"].ToString();
                M.NombreImagen = dataReader["NombreImagen"].ToString();
                M.Division = dataReader["Division"].ToString();
                M.Descripcion = dataReader["Descripcion"].ToString();
                M.Aprobado = Convert.ToBoolean(dataReader["Aprobado"]);
                M.Telefono = Convert.ToInt32(dataReader["Telefono"]);
                M.LinkMP = dataReader["LinkMP"].ToString();
                ListaDeLibros.Add(M);
            }
            dataReader.Close();
            Desconectar();
            int resta = cant - 2;
            resta = resta * 16;
            if (resta != 0)
            {
                ListaDeLibros.RemoveRange(0, resta);
            }

            return ListaDeLibros;
        }
        public static List<Libro> TraerMasLibros(int cant)
        {
            List<Libro> lista = new List<Libro>();
            int cantidad = cant * 16;
            cantidad += 16;
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select top "+cantidad+" * from Libros where Aprobado = 1"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Libro M = new Libro();
                M.IdLibro = Convert.ToInt32(dataReader["IdLibro"]);
                M.Nombre = dataReader["Nombre"].ToString();
                M.Precio = Convert.ToDouble(dataReader["Precio"]);
                M.FkVendedor = Convert.ToInt32(dataReader["FkVendedor"]);
                M.FkAno = Convert.ToInt32(dataReader["FkAno"]);
                M.FkMateria = Convert.ToInt32(dataReader["FkMateria"]);
                M.FkEscuela = Convert.ToInt32(dataReader["FkEscuela"]);
                M.FkComprador = Convert.ToInt32(dataReader["FkComprador"]);
                M.Editorial = dataReader["Editorial"].ToString();
                M.Lugar = dataReader["Lugar"].ToString();
                M.NombreImagen = dataReader["NombreImagen"].ToString();
                M.Division = dataReader["Division"].ToString();
                M.Descripcion = dataReader["Descripcion"].ToString();
                M.Aprobado = Convert.ToBoolean(dataReader["Aprobado"]);
                M.Telefono = Convert.ToInt32(dataReader["Telefono"]);
                M.LinkMP = dataReader["LinkMP"].ToString();
                lista.Add(M);
            }
            dataReader.Close();
            Desconectar();
            int resta = cant * 16;
            lista.RemoveRange(0, resta);
            return lista;
        }

        public static void AprobarLibro(int id)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "UPDATE Libros SET Aprobado = 1 where IdLibro =" + id; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }



        public static List<Libro> TraerLibrosSinAprobar()
        {
            List<Libro> ListaDeLibros = new List<Libro>();

            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT* FROM Libros where Aprobado = 0"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {

                int idli = Convert.ToInt32(dataReader["IdLibro"]);
                string Nom = dataReader["Nombre"].ToString();
                int pre = Convert.ToInt32(dataReader["Precio"]);
                int fkven = Convert.ToInt32(dataReader["FkVendedor"]);
                int fkma = Convert.ToInt32(dataReader["FkMateria"]);
                string edi = dataReader["Editorial"].ToString();
                string lu = dataReader["Lugar"].ToString();
                string im = dataReader["NombreImagen"].ToString();
                int fka = Convert.ToInt32(dataReader["FkAno"]);
                Boolean ap = Convert.ToBoolean(dataReader["Aprobado"]);
                string div = dataReader["Division"].ToString();
                int fkesc = Convert.ToInt32(dataReader["FkEscuela"]);
                int fkcom = Convert.ToInt32(dataReader["FkComprador"]);
                string des = dataReader["Descripcion"].ToString();
                int tel = Convert.ToInt32(dataReader["Telefono"]);
                string mp = dataReader["LinkMP"].ToString();

                Libro resu = new Libro(idli, Nom, pre, fkven, fkma, edi, lu, im, fka, ap, div, fkesc, fkcom, des, tel,mp);
                ListaDeLibros.Add(resu);
            }
            dataReader.Close();
            Desconectar();
            return ListaDeLibros;
        }

        public static Codigo CodigoAlAzar()
        {
            Random random = new Random();
            int i=random.Next(1, 12);
            Codigo c = new Codigo();
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Codigo where IdCodigo = "+i; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                c.Codi= dataReader["Codigo"].ToString();
                c.Id= Convert.ToInt32(dataReader["IdCodigo"]);
            }
            dataReader.Close();
            Desconectar();
            return c;
        }
        public static void InsertarCodigoYUsuario(int idCodigo, int idUs)
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "insert into UsuarioXCodigo(FkCodigo,FkUsuario)values("+idCodigo+","+idUs+")"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }

        public static int TraerIdCodigo (string s)
        {
            int i=-1;
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from Codigo where Codigo='"+s+"'"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                i= Convert.ToInt32(dataReader["IdCodigo"]);
            }
            dataReader.Close();
            Desconectar();
            return i;
        }
        public static Boolean VerSiEstaElCodigo (int idUs, string Codigo)
        {
            Boolean retorno=false;
            int c = TraerIdCodigo(Codigo);
            if (c != -1)
            {
                Conectar();
                SqlCommand command = SQL.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select* from UsuarioXCodigo where FkCodigo = "+c+" and FkUsuario = " + idUs; //Consulta
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    retorno = true;
                }
                dataReader.Close();
                Desconectar();
            }
            return retorno;
        }


        public static void EliminarTodosLosResumenesSinAprobar()
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM Resumenes WHERE Aprobado = 0"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }
        public static void EliminarTodosLosLibrosSinAprobar()
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM Libros WHERE Aprobado = 0"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }
        public static void AprobarTodosLosLibros()
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "UPDATE Libros SET Aprobado = 1"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }

        public static void AprobarTodosLosResumenes()
        {
            Conectar();
            SqlCommand command = SQL.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "UPDATE Resumenes SET Aprobado = 1"; //Consulta
            SqlDataReader dataReader = command.ExecuteReader();
            Desconectar();
        }


    }


}
   