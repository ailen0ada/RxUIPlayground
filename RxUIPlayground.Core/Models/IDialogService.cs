using System;

namespace RxUIPlayground.Core.Models
{
    public interface IDialogService
    {
        void Notify(string msg, string title);
    }
}

