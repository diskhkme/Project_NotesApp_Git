﻿using NotesApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotesApp.ViewModel.Commands
{
    public class RegisterCommand : ICommand
    {
        public LoginVM VM { get; set; }
        public event EventHandler CanExecuteChanged;

        public RegisterCommand(LoginVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            var user = parameter as User;

            //if(user == null)
            //{
            //    return false;
            //}
            //if (string.IsNullOrEmpty(user.Username))
            //{
            //    //유저 이름 입력이 없으면 Excute 불가
            //    return false;
            //}
            //if (string.IsNullOrEmpty(user.Password))
            //{
            //    //유저 비번 입력이 없으면 Excute 불가
            //    return false;
            //}
            //if (string.IsNullOrEmpty(user.Email))
            //{
            //    return false;
            //}
            //if (string.IsNullOrEmpty(user.Lastname))
            //{
            //    return false;
            //}
            //if (string.IsNullOrEmpty(user.Name))
            //{
            //    return false;
            //}

            return true;
        }

        public void Execute(object parameter)
        {
            VM.Register();
        }
    }
}
