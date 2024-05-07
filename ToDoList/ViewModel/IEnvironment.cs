using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.ViewModel
{
    public interface IEnvironment
    {
        void SetStatusBarColor(Microsoft.Maui.Graphics.Color color, bool darkStatusBarTint);
    }
}
