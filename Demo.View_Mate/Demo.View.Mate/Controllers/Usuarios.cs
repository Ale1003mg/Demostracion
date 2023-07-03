using Demo.View.Mate.Proxys;
using Demo.view_Mante.Dto.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;

namespace Demo.View.Mate.Controllers
{
    public class Usuarios : Controller
    {
        private readonly IP_Usuarios _usuarios;

        public Usuarios(IP_Usuarios usuarios)
        { 
        _usuarios = usuarios;
        }


        public async Task<IActionResult> Index()
        {
            var datos=await _usuarios.Getall_Usuario();
            return View(datos);
        }


        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Dto_Usuarios dto_Usuarios)
        {
            //dto_Usuarios.U_Contrasena = Encript.GetSHA256(dto_Usuarios.U_Contrasena);
            dto_Usuarios.accion = 1;
            var estado = await _usuarios.Mante_Usuario_Sistema(dto_Usuarios);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var usu = await _usuarios.GetID_Usuario_Sistema(id);
            return View(usu);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Dto_Usuarios dto_Usuarios)
        {
          //dto_Usuarios.U_Contrasena = Encript.GetSHA256(dto_Usuarios.U_Contrasena);
            dto_Usuarios.accion = 2;
            var estado = await _usuarios.Mante_Usuario_Sistema(dto_Usuarios);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> desactivar(int id)
        {
            var usu = await _usuarios.GetID_Usuario_Sistema(id);
            usu.accion = 3;//desctivar
            var estado = await _usuarios.Mante_Usuario_Sistema(usu);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            var usu = await _usuarios.GetID_Usuario_Sistema(id);
            usu.accion = 4;//desctivar
            var estado = await _usuarios.Mante_Usuario_Sistema(usu);
            return RedirectToAction(nameof(Index));
        }
    }
}
