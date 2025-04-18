﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BibliotecaAPI.Entidades;
using BibliotecaAPI.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NSubstitute;

namespace BibliotecaAPITests.PruebasUnitarias.Servicios
{
    [TestClass]
    public  class ServicioUsuariosPruebas
    {
        private UserManager<Usuario> userManager = null!;
        private IHttpContextAccessor contextAccessor = null!;
        private ServicioUsuarios servicioUsuarios = null!;

        [TestInitialize]
        public void Setup()
        {
            userManager = Substitute.For<UserManager<Usuario>>(
                Substitute.For<IUserStore<Usuario>>(), null, null, null, null, null, null, null, null);

            contextAccessor = Substitute.For<IHttpContextAccessor>();
            servicioUsuarios = new ServicioUsuarios(userManager, contextAccessor);
        }

        [TestMethod]
        public async Task ObtenerUsuario_RetornarNulo_CuandoNoHayClaimEmail()
        {
            // Preparación
            var httpContext = new DefaultHttpContext();
            contextAccessor.HttpContext.Returns(httpContext);

            // Prueba
            var usuario = await servicioUsuarios.ObtenerUsuario();

            // Verificación
            Assert.IsNull(usuario);
        }

        [TestMethod]
        public async Task ObtenerUsuario_RetornarUsuario_CuandoHayClaimEmail()
        {
            // Preparación
            var email = "prueba@hotmail.com";
            var usuarioEsperado = new Usuario { Email = email };

            userManager.FindByEmailAsync(email)!.Returns(Task.FromResult(usuarioEsperado));

            var claims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim("email", email)
            }));

            var httpContext = new DefaultHttpContext() { User = claims };
            contextAccessor.HttpContext.Returns(httpContext);

            // Prueba
            var usuario = await servicioUsuarios.ObtenerUsuario();

            // Verificación
            Assert.IsNotNull(usuario);
            Assert.AreEqual(expected: email, actual: usuario.Email);
        }

        [TestMethod]
        public async Task ObtenerUsuario_RetornarNulo_CuandoUsuarioNoExiste()
        {
            // Preparación
            var email = "prueba@hotmail.com";
            var usuarioEsperado = new Usuario { Email = email };

            userManager.FindByEmailAsync(email)!.Returns(Task.FromResult<Usuario>(null!));

            var claims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim("email", email)
            }));

            var httpContext = new DefaultHttpContext() { User = claims };
            contextAccessor.HttpContext.Returns(httpContext);

            // Prueba
            var usuario = await servicioUsuarios.ObtenerUsuario();

            // Verificación
            Assert.IsNull(usuario);
        }
    }
}
