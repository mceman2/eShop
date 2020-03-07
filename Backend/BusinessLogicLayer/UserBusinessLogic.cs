using DataAccessLayer;
using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.Interfaces;
using APShopDTO;

namespace BusinessLogicLayer
{
    public class UserBusinessLogic: IUserBusinessLogic
    {
        private readonly IUserManager _userManager;

        public UserBusinessLogic(IUserManager IUM)
        {
            _userManager = IUM;
        }

        public bool CheckIfUserExists(string username)
        {
            return _userManager.CheckIfUserExists(username);
        }
        public bool CheckIfUserExists(int userId)
        {
            return _userManager.CheckIfUserExists(userId);
        }
    }
}
