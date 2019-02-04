using NotesApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotesApp.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        public LoginVM VM { get; set; }

        public event EventHandler CanExecuteChanged;

        public LoginCommand(LoginVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            var user = parameter as User;
            if(string.IsNullOrEmpty(user.Username))
            {
                //유저 이름 입력이 없으면 Excute 불가
                return false;
            }
            if (string.IsNullOrEmpty(user.Password))
            {
                //유저 비번 입력이 없으면 Excute 불가
                return false;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            VM.Login();
        }
    }
}
