﻿using System.Collections.Generic;
using AnotherWEBAPI.Models;

namespace AnotherWEBAPI.Data
{
    public interface IAccountRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserAccount> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserAccount GetUserAccount(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        UserAccount Add(UserAccount item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Remove(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(UserAccount item);

    }
}