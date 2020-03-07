using APShopDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public interface IUserBusinessLogic
    {
        bool CheckIfUserExists(string username);
        bool CheckIfUserExists(int userId);
    }
}
