using Microsoft.EntityFrameworkCore;
using ProyectoFinal23AM.Context;
using ProyectoFinal23AM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoFinal23AM.Services
{
    public class UsuarioServices
    {
		//CREACION DEL CRUD
        public void AddUser(Usuario request)
        {
			try
			{
				if (request != null)
				{
					using (var _context = new ApplicationDbContext())
					//LOS CORCHETES REPRESENTAN EL ABRIR Y CERRAR LA BASE DE DATOS
					{
						Usuario res = new Usuario();
						res.Nombre = request.Nombre;
						res.UserName = request.UserName;
						res.Password = request.Password;
						res.FkRol = request.FkRol;
						_context.Usuarios.Add(res);
						_context.SaveChanges();
					}
				}
			}
			catch (Exception ex)
			{

				throw new Exception("ERROR: " + ex.Message);
			}
        }
		public List<Usuario> GetUsuarios()
		{
			try
			{
				using(var _context = new ApplicationDbContext())
				{
					List<Usuario> usuarios = _context.Usuarios.Include(x => x.Roles).ToList();
					//List<Usuario> usuarios = new List<Usuario>();
					//usuarios = _context.Usuarios.ToList();
					return usuarios;

				}
			}
			catch (Exception ex)
			{

				throw new Exception("ERROR: " + ex.Message);
			}
		}
		public List<Rol> GetRoles()
		{
			try
			{
				using (var _context = new ApplicationDbContext())
				{
					List<Rol> roles = _context.Roles.ToList();
					return roles;
				}
			}
			catch (Exception ex)
			{

				throw new Exception("ERROR: " + ex.Message);
			}
		}
        public void UpdateUser(Usuario request)
        {
            try
            {

                using (var _context = new ApplicationDbContext())
                {
                    Usuario update = _context.Usuarios.Find(request.PkUsuario);
                    Usuario res = new Usuario();


                    update.Nombre = request.Nombre;
                    update.UserName = request.UserName;
                    update.Password = request.Password;
					update.FkRol = request.FkRol;

                    _context.Usuarios.Update(update);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
        public void DeleteUser(int UserId)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Usuario usuario = _context.Usuarios.Find(UserId);
                    if (usuario != null)
                    {
                        _context.Remove(usuario);
                        _context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("NO HAY REGISTRO");
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("ERROR: " + ex.Message);
            }
        }
		public Usuario Login(string Username, string Password)
		{
			try
			{
                using (var _context = new ApplicationDbContext())
                {
					var usuario = _context.Usuarios.Include(y => y.Roles).FirstOrDefault(x => x.UserName == Username && x.Password == Password);
					return usuario;
                }
            }
			catch (Exception ex)
			{

				throw new Exception("ERROR: " + ex.Message);
			}
		}
    }
}
