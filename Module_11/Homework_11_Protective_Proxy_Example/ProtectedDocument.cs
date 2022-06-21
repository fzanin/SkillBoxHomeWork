using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11_Protective_Proxy_Example
{
    public class ProtectedDocument : Document
    {

        public ProtectedDocument(string name, string content) : base (name, content)
        {

        }

        //public override void UpdateName(string newName, User user)
        //{
        //    if (user.Role != Roles.Author)
        //    {
        //        throw new UnauthorizedAccessException("Cannot update name unless in Author role.");
        //    }
        //    base.UpdateName(newName, user);
        //}


    }
}
