using AppInven.Modelo.dao;
using AppInven.Modelo.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInven.Controlador
{
    public class MenuControlador
    {
        public event EventHandler<formMenu> btnGuardarMenu;
        
        public void StartProcess(formMenu formMenu)
        {
            try
            {
                OnProcessCompleted(formMenu);
            }
            catch (Exception ex)
            {
                OnProcessCompleted(formMenu);
            }
        }

        protected virtual void OnProcessCompleted(formMenu IsSuccessful)
        {
            btnGuardarMenu?.Invoke(this, IsSuccessful);
        }




    }
}
